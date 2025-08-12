
Imports Excel
'Imports BL
'Imports AsianERPBL.ModGeneral
'Imports AsianERPBL.Account
Imports System.Data
Imports AccountingBL
Imports System.Data.OleDb

Public Class clsReportDesigner
    'Private objDBOperation As DB.DBOperation

    'Public objUserDetails As ObjUser
    'Private objRepCenter As New clsRepCenter
    Dim dsResult As New DataSet
    Dim ALPARVAL As New ArrayList
    Dim dv As New DataView
    Public inwt As Boolean = True
    Public outwt As Boolean = True
    Public item As Boolean = True
    Public recpur As Boolean = True
    Public grosswt As Boolean = True
    Public nettwt As Boolean = True
    Public lotno As Boolean = True
    Public smplwt As Boolean = True
    Public issupur As Boolean = True
    Public fine As Boolean = True
    Public partno As Boolean = True
    Public process As Boolean = True

    Public Sub New()
        Try
            'objDBOperation = New DB.DBOperation
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region " INTERNAL MANAGEMENT DECLARATIONS ............. "


#Region "Private Declarations..."
    Private objColumn As New Hashtable
    Private objSheet As Excel.Worksheet
    Private objExcel As Excel.Application
    Private objBook As Excel.Workbook
    'Private objUser As New clsUser
    Private RowIndex As Integer
    Private currentColumn As String
    Private _Report_Title As String
    Private _SaveFilePath As String
    Private _PreviewOption As Integer
#End Region

    Public Sub New(ByVal Report_Title As String, ByVal SaveFilePath As String, ByVal PreivewOption As Integer)
        Try
            _Report_Title = Report_Title
            _SaveFilePath = SaveFilePath
            _PreviewOption = PreivewOption
            Try
                'For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                '    MsgBox(proc.)
                'Next
            Catch ex As Exception

            End Try
            ' try{
            '    foreach (Process thisproc in Process.GetProcessesByName(processName)) {
            'if(!thisproc.CloseMainWindow()){
            '//If closing is not successful or no desktop window handle, then force termination.
            'thisproc.Kill();
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SetWorkSheet()
        Try
            objExcel = New Excel.Application
            If Not objExcel Is Nothing Then
                objBook = objExcel.Workbooks.Add
                objSheet = DirectCast(objBook.ActiveSheet, Excel.Worksheet)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Quit()
        Try
            objSheet = Nothing
            objBook.Close()
            ReleaseObject(objBook)
            objExcel.Quit()
            ReleaseObject(objExcel)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReleaseObject(ByVal o As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

    Private Sub SaveAndClose()
        Try
            objExcel.AlertBeforeOverwriting = False
            objExcel.DisplayAlerts = False

            'CHECKING WHETHER FILE EXISTIS OR NOT IF NOT THEN THIS CODE GIVES ERROR SKIP IT
            If System.IO.File.Exists(_SaveFilePath) Then
                Dim workbook As String = _SaveFilePath
                Interaction.GetObject(workbook).close(False)
                GC.Collect()
            End If
            objSheet.SaveAs(_SaveFilePath)



            If _PreviewOption = 1 Then 'Open In Web Browser                
                objBook.WebPagePreview()
            ElseIf _PreviewOption = 2 Then 'Open In Excel                
                objExcel.Visible = True
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Try
                If _PreviewOption <> 2 Then Quit()
            Catch ex As Exception
            End Try
        End Try
    End Sub

    Private Sub SetColumn(ByVal Key As String, ByVal ForColumn As String)
        Try
            objColumn.Add(Key, ForColumn)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReSetColumn()
        Try
            objColumn.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private ReadOnly Property Column(ByVal Key As String) As String
        Get
            Try
                Return objColumn.Item(Key).ToString
            Catch ex As Exception
                Throw ex
            End Try
        End Get
    End Property

    Private ReadOnly Property Range(ByVal Key As String) As String
        Get
            Try
                Return objColumn.Item(Key).ToString & RowIndex.ToString
            Catch ex As Exception
                Throw ex
            End Try
        End Get
    End Property

    Private Sub Write(ByVal Text As Object, ByVal Range As String, ByVal Align As XlHAlign, _
        Optional ByVal ToRange As String = Nothing, Optional ByVal FontBold As Boolean = False, _
        Optional ByVal FontSize As Int16 = 9, Optional ByVal WrapText As Boolean = False, Optional ByVal _
fontItalic As Boolean = False)
        Try
            objSheet.Range(Range).FormulaR1C1 = Text
            'objSheet.Range(Range).BorderAround()
            If Not ToRange Is Nothing Then
                objSheet.Range(Range, ToRange).Merge()
                'objSheet.Range(Range, ToRange).BorderAround()
            End If
            objSheet.Range(Range).HorizontalAlignment = Align
            If FontBold Then objSheet.Range(Range).Font.Bold = True
            If FontSize > 0 Then objSheet.Range(Range).Font.Size = FontSize
            If WrapText Then objSheet.Range(Range).WrapText = True
            If fontItalic Then objSheet.Range(Range).Font.Italic = True


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FORMULA(ByVal Text As Object, ByVal Range As String, ByVal Align As XlHAlign, _
       Optional ByVal ToRange As String = Nothing, Optional ByVal FontBold As Boolean = False, _
       Optional ByVal FontSize As Int16 = 9, Optional ByVal WrapText As Boolean = False, Optional ByVal _
fontItalic As Boolean = False)
        Try
            objSheet.Range(Range).Formula = Text
            'objSheet.Range(Range).BorderAround()
            If Not ToRange Is Nothing Then
                objSheet.Range(Range, ToRange).Merge()
                'objSheet.Range(Range, ToRange).BorderAround()
            End If
            objSheet.Range(Range).HorizontalAlignment = Align
            If FontBold Then objSheet.Range(Range).Font.Bold = True
            If FontSize > 0 Then objSheet.Range(Range).Font.Size = FontSize
            If WrapText Then objSheet.Range(Range).WrapText = True
            If fontItalic Then objSheet.Range(Range).Font.Italic = True


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LOCKCELLS(ByVal VALUE As Boolean, ByVal Range As String, Optional ByVal ToRange As String = Nothing)
        Try
            If Not ToRange Is Nothing Then
                objSheet.Range(Range, ToRange).Locked = VALUE
            Else
                objSheet.Range(Range).Locked = VALUE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SetBorder(ByVal RowIndex As Integer, Optional ByVal Range As String = Nothing, Optional ByVal ToRange As String = Nothing)

        Dim intI As Integer = 0
        ''RowIndex = 0
        'obj()
        'objSheet.Selec
        'objExcel.Selection("A1:N17").ToString()
        objSheet.Range(Range, ToRange).Select()
        objSheet.Range(Range, ToRange).BorderAround(, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, )
        'For intI = 1 To RowIndex
        '    objSheet.Range(Range, ToRange).Select()
        '    objSheet.Range(Range, ToRange).BorderAround(, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, )
        '    intI += 1
        'Next
    End Sub

    Private Sub SetColumnWidth(ByVal Range As String, ByVal width As Integer)
        'objSheet.Range(Range).BorderAround()
        objSheet.Range(Range).ColumnWidth = width
        '  = objSheet.Range(Range).Select()
        'objSheet.Range(Range).EditionOptions(XlEditionType.xlPublisher, XlEditionOptionsOption.xlAutomaticUpdate, , , XlPictureAppearance.xlScreen, XlPictureAppearance.xlScreen)
    End Sub

    Private Function NextColumn() As String
        Dim nxtColumn As String = String.Empty
        Try
            Dim i As Integer = 0
            Dim length As Integer = currentColumn.Length
            For i = length - 1 To 0 Step -1
                If Not (currentColumn(i).ToString.ToUpper = "Z") Then
                    Dim substr As String = String.Empty
                    If i > 0 Then
                        substr = currentColumn.Substring(0, i)
                    End If
                    nxtColumn = Convert.ToString(Convert.ToChar(Convert.ToInt32(currentColumn(i)) + 1)) & nxtColumn
                    nxtColumn = substr & nxtColumn
                    Exit For
                ElseIf currentColumn(i).ToString.ToUpper = "Z" Then
                    nxtColumn = "A" & nxtColumn
                End If
                If i = 0 Then
                    If Convert.ToString(currentColumn(i)).ToUpper = "Z" Then
                        nxtColumn = "A" & nxtColumn
                    End If
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
        currentColumn = nxtColumn
        Return nxtColumn
    End Function

    Private Sub MeargeCell(ByVal StartCol As String, ByVal StartRow As String, ByVal EndCol As String, ByVal EndRow As String)
        Try

            'objSheet.Range(StartCol & StartRow & ":" & EndCol & EndRow).Merge()
            objSheet.Range(StartCol, EndCol).Merge()

            'With objSheet.Selection                
            '    .WrapText = False
            '    .Orientation = 0
            '    .AddIndent = False
            '    .IndentLevel = 0
            '    .ShrinkToFit = False                
            '    .MergeCells = True
            'End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "PARTY ACCOUNTS REPORT"

    Public Function PARTY_ACCOUNTS_EXCEL(ByVal PARTYNAME As String, ByVal NARR As Boolean, ByVal ITEMCODE As Boolean, ByVal PURITY As Boolean, ByVal BULLION As Boolean, ByVal WAST As Boolean, ByVal GROSS As Boolean, ByVal NETT As Boolean, ByVal AMT As Boolean, ByVal FROMDATE As Date, ByVal DATECHECK As Boolean, Optional ByVal CONDITION As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 9)
            Next

            SetColumnWidth("A1", 10)
            SetColumnWidth("B1", 9)
            SetColumnWidth("C1", 13)
            SetColumnWidth("D1", 6)
            SetColumnWidth("E1", 8)
            SetColumnWidth("F1", 6)

            SetColumnWidth("J1", 10)
            SetColumnWidth("K1", 9)
            SetColumnWidth("L1", 13)
            SetColumnWidth("M1", 6)
            SetColumnWidth("N1", 8)
            SetColumnWidth("O1", 6)

            If NARR = False Then
                SetColumnWidth("C1", 0)
                SetColumnWidth("L1", 0)
            End If
            If ITEMCODE = False Then
                SetColumnWidth("B1", 0)
                SetColumnWidth("K1", 0)
            End If
            If WAST = False Then
                SetColumnWidth("D1", 0)
                SetColumnWidth("M1", 0)
            End If
            If PURITY = False Then
                SetColumnWidth("E1", 0)
                SetColumnWidth("N1", 0)
            End If
            If BULLION = False Then
                SetColumnWidth("F1", 0)
                SetColumnWidth("O1", 0)
            End If
            If GROSS = False Then
                SetColumnWidth("G1", 0)
                SetColumnWidth("P1", 0)
            End If
            If NETT = False Then
                SetColumnWidth("H1", 0)
                SetColumnWidth("Q1", 0)
            End If
            If AMT = False Then
                SetColumnWidth("I1", 0)
                SetColumnWidth("R1", 0)
            End If


            ''''''''''Report Title
            'CMPNAME
            RowIndex = 2
            Write(tempcmpname, Range("1"), XlHAlign.xlHAlignCenter, Range("18"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("18"))

            'PARTY NAME
            RowIndex += 1
            Write("Ledger Accounts (" & PARTYNAME & ")", Range("1"), XlHAlign.xlHAlignCenter, Range("18"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("18"))

            'RECEIPT/JAMA
            RowIndex += 1
            Write("Receipt/Jama", Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 9)
            SetBorder(RowIndex, Range("1"), Range("9"))
            Write("Issue/Naame", Range("10"), XlHAlign.xlHAlignCenter, Range("18"), True, 9)
            SetBorder(RowIndex, Range("10"), Range("18"))


            'COLUMNS NAME
            RowIndex += 1
            Write("Date", Range("1"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Item", Range("2"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Narr", Range("3"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Wst", Range("4"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Pur.", Range("5"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Bull.", Range("6"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Gross Wt.", Range("7"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Nett Wt.", Range("8"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Amt.", Range("9"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("1"), Range("9"))

            Write("Date", Range("10"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Item", Range("11"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Narr", Range("12"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Wst", Range("13"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Pur.", Range("14"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Bull.", Range("15"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Gross Wt.", Range("16"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Nett Wt.", Range("17"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Amt.", Range("18"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("10"), Range("18"))


            'FREEZE TOP 6 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 6, objColumn.Item("18").ToString & 6).Select()
            objSheet.Range(objColumn.Item("1").ToString & 6, objColumn.Item("18").ToString & 6).Application.ActiveWindow.FreezePanes = True


            '************************** START OF OPENING CODE ***************************************
            'GET OPENING JAMA OR ISSUE
            Dim OPJAMA As Double = 0.0
            Dim OPJAMAAMT As Double = 0.0
            Dim OPBALANCE As Double = 0.0
            Dim OPBALANCEAMT As Double = 0.0

            'GET SETTLEMENT DATE FIRST
            Dim SETTLEMENTDATE As Date
            Dim tempcmd As New OleDbCommand(" Select LEDGER_SETTLEMENT AS SETTLEMENTDATE FROM LEDGERMASTER WHERE LEDGERMASTER.LEDGER_CODE = '" & PARTYNAME & "'", tempconn)
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            dr = tempcmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                If IsDBNull(dr("SETTLEMENTDATE")) = False Then SETTLEMENTDATE = dr("SETTLEMENTDATE") Else SETTLEMENTDATE = "01/01/2016"
            End If

            If DATECHECK = False Then FROMDATE = SETTLEMENTDATE

            If SETTLEMENTDATE < FROMDATE Then
                tempcmd = New OleDbCommand(" Select IIF(ISNULL(Sum(account_nettwt)) = TRUE , 0, Sum(account_nettwt) ) AS Nettwt, IIF(ISNULL(Sum(account_AMOUNT) ) = TRUE , 0, Sum(account_AMOUNT) ) AS Amt FROM ACCOUNTMAST WHERE ACCOUNTMAST.ACCOUNT_LEDGERCODE = '" & PARTYNAME & "' AND ACCOUNTMAST.ACCOUNT_DATE < #" & Format(FROMDATE, "MM/dd/yyyy") & "# and account_balorjamaorpaid = 'Jama'", tempconn)
            Else
                tempcmd = New OleDbCommand(" Select IIF(ISNULL(Sum(account_nettwt)) = TRUE , 0, Sum(account_nettwt) ) AS Nettwt, IIF(ISNULL(Sum(account_AMOUNT) ) = TRUE , 0, Sum(account_AMOUNT) ) AS Amt FROM ACCOUNTMAST WHERE ACCOUNTMAST.ACCOUNT_LEDGERCODE = '" & PARTYNAME & "' AND ACCOUNTMAST.ACCOUNT_DATE <= #" & Format(SETTLEMENTDATE, "MM/dd/yyyy") & "# and account_balorjamaorpaid = 'Jama'", tempconn)
            End If
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            dr = tempcmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                OPJAMA = dr("NETTWT")
                OPJAMAAMT = dr("AMT")
            End If


            If SETTLEMENTDATE < FROMDATE Then
                tempcmd = New OleDbCommand(" Select IIF(ISNULL(Sum(account_nettwt)) = TRUE , 0, Sum(account_nettwt) ) AS Nettwt, IIF(ISNULL(Sum(account_AMOUNT) ) = TRUE , 0, Sum(account_AMOUNT) ) AS Amt FROM ACCOUNTMAST WHERE ACCOUNTMAST.ACCOUNT_LEDGERCODE = '" & PARTYNAME & "' AND ACCOUNTMAST.ACCOUNT_DATE < #" & Format(FROMDATE, "MM/dd/yyyy") & "# and account_balorjamaorpaid = 'Balance'", tempconn)
            Else
                tempcmd = New OleDbCommand(" Select IIF(ISNULL(Sum(account_nettwt)) = TRUE , 0, Sum(account_nettwt) ) AS Nettwt, IIF(ISNULL(Sum(account_AMOUNT) ) = TRUE , 0, Sum(account_AMOUNT) ) AS Amt FROM ACCOUNTMAST WHERE ACCOUNTMAST.ACCOUNT_LEDGERCODE = '" & PARTYNAME & "' AND ACCOUNTMAST.ACCOUNT_DATE <= #" & Format(SETTLEMENTDATE, "MM/dd/yyyy") & "# and account_balorjamaorpaid = 'Balance'", tempconn)
            End If
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            dr = tempcmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                OPBALANCE = dr("NETTWT")
                OPBALANCEAMT = dr("AMT")
            End If

            'get PARTYOPENING AMT
            tempcmd = New OleDbCommand(" Select IIF(LEDGER_DRCRRS = 'Cr.' , LEDGER_OPBALRS, 0 ) AS OPBALDR, IIF(LEDGER_DRCRRS = 'Dr.' , LEDGER_OPBALRS, 0 ) AS OPBALCR FROM LEDGERMASTER WHERE LEDGERMASTER.LEDGER_CODE = '" & PARTYNAME & "'", tempconn)
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            dr = tempcmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                OPJAMAAMT = OPJAMAAMT + dr("OPBALDR")
                OPBALANCEAMT = OPBALANCEAMT + dr("OPBALCR")
            End If


            'get PARTYOPENING BALANCE
            tempcmd = New OleDbCommand(" Select IIF(LEDGER_DRCRWT = 'Cr.' , LEDGER_OPBALWT, 0 ) AS OPBALDR, IIF(LEDGER_DRCRWT = 'Dr.' , LEDGER_OPBALWT, 0 ) AS OPBALCR FROM LEDGERMASTER WHERE LEDGERMASTER.LEDGER_CODE = '" & PARTYNAME & "'", tempconn)
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            dr = tempcmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                OPJAMA = OPJAMA + dr("OPBALDR")
                OPBALANCE = OPBALANCE + dr("OPBALCR")
            End If


            'WRITE OP BAL
            If OPJAMA > OPBALANCE Then
                RowIndex = 6
                Write("Opening", Range("1"), XlHAlign.xlHAlignRight, Range("7"), False, 9)
                Write(Format(Val(OPJAMA - OPBALANCE), "0.000"), Range("8"), XlHAlign.xlHAlignRight, , False, 9)
            Else
                RowIndex = 6
                Write("Opening", Range("10"), XlHAlign.xlHAlignRight, Range("16"), False, 9)
                Write(Format(Val(OPBALANCE - OPJAMA), "0.000"), Range("17"), XlHAlign.xlHAlignRight, , False, 9)
            End If

            'WRITE OPAMT
            If OPJAMAAMT > OPBALANCEAMT Then
                RowIndex = 6
                Write("Opening", Range("1"), XlHAlign.xlHAlignRight, Range("7"), False, 9)
                Write(Format(Val(OPJAMAAMT - OPBALANCEAMT), "0.000"), Range("9"), XlHAlign.xlHAlignRight, , False, 9)
            Else
                RowIndex = 6
                Write("Opening", Range("10"), XlHAlign.xlHAlignRight, Range("16"), False, 9)
                Write(Format(Val(OPBALANCEAMT - OPJAMAAMT), "0.000"), Range("18"), XlHAlign.xlHAlignRight, , False, 9)
            End If
            '************************** END OF OPENING CODE ***************************************


            'JAMA
            Dim dtjama As New System.Data.DataTable
            tempcmd = New OleDbCommand(" SELECT ACCOUNTMAST.account_date AS AccDate, ACCOUNTMAST.item_code AS ItemCode, ACCOUNTMAST.account_narration AS Narr, ACCOUNTMAST.account_bullion AS Bullion, ACCOUNTMAST.account_wastage AS Wastage, ACCOUNTMAST.account_purity AS Purity, Sum(ACCOUNTMAST.account_grosswt) AS Grosswt, Sum(ACCOUNTMAST.account_nettwt) AS Nettwt, Sum(ACCOUNTMAST.account_amount) AS Amt FROM ACCOUNTMAST " & CONDITION & " and account_balorjamaorpaid = 'Jama' GROUP BY ACCOUNTMAST.account_date, ACCOUNTMAST.item_code, ACCOUNTMAST.account_narration, ACCOUNTMAST.account_bullion, ACCOUNTMAST.account_wastage, ACCOUNTMAST.account_purity, ACCOUNTMAST.ACCOUNT_VOUCHERID ORDER BY account_date ", tempconn)
            da = New System.Data.OleDb.OleDbDataAdapter(tempcmd)
            da.Fill(dtjama)
            If dtjama.Rows.Count > 0 Then
                Dim JSTARTROW As Integer = RowIndex
                For Each DRJAMA As System.Data.DataRow In dtjama.Rows
                    RowIndex += 1
                    Write(DRJAMA("AccDate"), Range("1"), XlHAlign.xlHAlignCenter, , False, 9)
                    Write(DRJAMA("ItemCode"), Range("2"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(DRJAMA("Narr"), Range("3"), XlHAlign.xlHAlignLeft, , False, 9, True)
                    Write(DRJAMA("Wastage"), Range("4"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DRJAMA("Purity"), Range("5"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DRJAMA("Bullion"), Range("6"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DRJAMA("Grosswt"), Range("7"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DRJAMA("Nettwt"), Range("8"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DRJAMA("Amt"), Range("9"), XlHAlign.xlHAlignRight, , False, 9)
                Next
            End If
            Dim JENDROW As Integer = RowIndex



            'ISSUE
            Dim dtISSUE As New System.Data.DataTable
            tempcmd = New OleDbCommand(" SELECT ACCOUNTMAST.account_date AS AccDate, ACCOUNTMAST.item_code AS ItemCode, ACCOUNTMAST.account_narration AS Narr, ACCOUNTMAST.account_bullion AS Bullion, ACCOUNTMAST.account_wastage AS Wastage, ACCOUNTMAST.account_purity AS Purity, Sum(ACCOUNTMAST.account_grosswt) AS Grosswt, Sum(ACCOUNTMAST.account_nettwt) AS Nettwt, Sum(ACCOUNTMAST.account_amount) AS Amt FROM ACCOUNTMAST " & CONDITION & " and account_balorjamaorpaid = 'Balance' GROUP BY ACCOUNTMAST.account_date, ACCOUNTMAST.item_code, ACCOUNTMAST.account_narration, ACCOUNTMAST.account_bullion, ACCOUNTMAST.account_wastage, ACCOUNTMAST.account_purity, ACCOUNTMAST.ACCOUNT_VOUCHERID ORDER BY account_date", tempconn)
            da = New System.Data.OleDb.OleDbDataAdapter(tempcmd)
            da.Fill(dtISSUE)
            If dtISSUE.Rows.Count > 0 Then
                RowIndex = 6
                For Each DRISSUE As System.Data.DataRow In dtISSUE.Rows
                    RowIndex += 1
                    Write(DRISSUE("AccDate"), Range("10"), XlHAlign.xlHAlignCenter, , False, 9)
                    Write(DRISSUE("ItemCode"), Range("11"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(DRISSUE("Narr"), Range("12"), XlHAlign.xlHAlignLeft, , False, 9, True)
                    Write(DRISSUE("Wastage"), Range("13"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DRISSUE("Purity"), Range("14"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DRISSUE("Bullion"), Range("15"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DRISSUE("Grosswt"), Range("16"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DRISSUE("Nettwt"), Range("17"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DRISSUE("Amt"), Range("18"), XlHAlign.xlHAlignRight, , False, 9)
                Next
            End If
            If RowIndex < JENDROW Then RowIndex = JENDROW

            SetBorder(RowIndex, objColumn.Item("1").ToString & 6, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 6, objColumn.Item("18").ToString & RowIndex)




            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("3"), True, 10)
            Write("Total :", Range("10"), XlHAlign.xlHAlignRight, Range("12"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("3"))
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, Range("12"))


            objSheet.Range(objColumn.Item("4").ToString & 7, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("7").ToString & 7, objColumn.Item("7").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("8").ToString & 7, objColumn.Item("8").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("13").ToString & 7, objColumn.Item("13").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("16").ToString & 7, objColumn.Item("16").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("17").ToString & 7, objColumn.Item("17").ToString & RowIndex).NumberFormat = "0.000"



            'TO AVOID ERROR IF NO RECORDS
            If RowIndex > 7 Then
                For i As Integer = 4 To 18
                    If i <> 10 And i <> 11 And i <> 12 Then
                        If i <> 5 And i <> 14 Then FORMULA("=SUM(" & objColumn.Item(i.ToString).ToString & 6 & ":" & objColumn.Item(i.ToString).ToString & RowIndex - 1 & ")", Range(i.ToString), XlHAlign.xlHAlignRight, , True, 10)
                    End If
                Next
            End If
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, Range("9"))
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, Range("18"))



            RowIndex += 2
            'Write("Balance Gross :", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 10)
            FORMULA("=""Balance Gross : "" &  ROUND((" & objColumn.Item("7").ToString & RowIndex - 2 & "-" & objColumn.Item("16").ToString & RowIndex - 2 & "),3)", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 9)
            'objSheet.Range(objColumn.Item("3").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.000"


            RowIndex += 1
            'Write("Balance Nett :", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 10)
            FORMULA("=""Balance Nett : "" &  ROUND((" & objColumn.Item("8").ToString & RowIndex - 3 & "-" & objColumn.Item("17").ToString & RowIndex - 3 & "),3)", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 9)
            'objSheet.Range(objColumn.Item("3").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.000"


            RowIndex += 1
            'Write("Balance Amount :", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 10)
            FORMULA("=""Balance Amount : "" &  ROUND((" & objColumn.Item("9").ToString & RowIndex - 4 & "-" & objColumn.Item("18").ToString & RowIndex - 4 & "),2)", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 10)
            'objSheet.Range(objColumn.Item("3").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.000"




            objBook.Application.ActiveWindow.Zoom = 100

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .TopMargin = 20
                .LeftMargin = 20
                .RightMargin = 20
                .BottomMargin = 20
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function PARTY_DETAILACCOUNTS_EXCEL(ByVal PARTYNAME As String, ByVal NARR As Boolean, ByVal ITEMCODE As Boolean, ByVal PURITY As Boolean, ByVal BULLION As Boolean, ByVal WAST As Boolean, ByVal GROSS As Boolean, ByVal NETT As Boolean, ByVal AMT As Boolean, ByVal FROMDATE As Date, ByVal DATECHECK As Boolean, Optional ByVal CONDITION As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 9)
            Next

            SetColumnWidth("A1", 10)
            SetColumnWidth("B1", 9)
            SetColumnWidth("C1", 13)
            SetColumnWidth("D1", 6)
            SetColumnWidth("E1", 8)
            SetColumnWidth("F1", 6)

            SetColumnWidth("J1", 10)
            SetColumnWidth("K1", 9)
            SetColumnWidth("L1", 13)
            SetColumnWidth("M1", 6)
            SetColumnWidth("N1", 8)
            SetColumnWidth("O1", 6)

            If NARR = False Then
                SetColumnWidth("C1", 0)
                SetColumnWidth("L1", 0)
            End If
            If ITEMCODE = False Then
                SetColumnWidth("B1", 0)
                SetColumnWidth("K1", 0)
            End If
            If WAST = False Then
                SetColumnWidth("D1", 0)
                SetColumnWidth("M1", 0)
            End If
            If PURITY = False Then
                SetColumnWidth("E1", 0)
                SetColumnWidth("N1", 0)
            End If
            If BULLION = False Then
                SetColumnWidth("F1", 0)
                SetColumnWidth("O1", 0)
            End If
            If GROSS = False Then
                SetColumnWidth("G1", 0)
                SetColumnWidth("P1", 0)
            End If
            If NETT = False Then
                SetColumnWidth("H1", 0)
                SetColumnWidth("Q1", 0)
            End If
            If AMT = False Then
                SetColumnWidth("I1", 0)
                SetColumnWidth("R1", 0)
            End If


            ''''''''''Report Title
            'CMPNAME
            RowIndex = 2
            Write(tempcmpname, Range("1"), XlHAlign.xlHAlignCenter, Range("18"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("18"))

            'PARTY NAME
            RowIndex += 1
            Write("Ledger Accounts (" & PARTYNAME & ")", Range("1"), XlHAlign.xlHAlignCenter, Range("18"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("18"))

            'RECEIPT/JAMA
            RowIndex += 1
            Write("Receipt/Jama", Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 9)
            SetBorder(RowIndex, Range("1"), Range("9"))
            Write("Issue/Naame", Range("10"), XlHAlign.xlHAlignCenter, Range("18"), True, 9)
            SetBorder(RowIndex, Range("10"), Range("18"))


            'COLUMNS NAME
            RowIndex += 1
            Write("Date", Range("1"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Item", Range("2"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Narr", Range("3"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Wst", Range("4"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Pur.", Range("5"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Bull.", Range("6"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Gross Wt.", Range("7"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Nett Wt.", Range("8"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Amt.", Range("9"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("1"), Range("9"))

            Write("Date", Range("10"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Item", Range("11"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Narr", Range("12"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Wst", Range("13"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Pur.", Range("14"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Bull.", Range("15"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Gross Wt.", Range("16"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Nett Wt.", Range("17"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Amt.", Range("18"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("10"), Range("18"))


            'FREEZE TOP 6 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 6, objColumn.Item("18").ToString & 6).Select()
            objSheet.Range(objColumn.Item("1").ToString & 6, objColumn.Item("18").ToString & 6).Application.ActiveWindow.FreezePanes = True


            '************************** START OF OPENING CODE ***************************************
            'GET OPENING JAMA OR ISSUE
            Dim OPJAMA As Double = 0.0
            Dim OPJAMAAMT As Double = 0.0
            Dim OPBALANCE As Double = 0.0
            Dim OPBALANCEAMT As Double = 0.0

            'GET SETTLEMENT DATE FIRST
            Dim SETTLEMENTDATE As Date
            Dim tempcmd As New OleDbCommand(" Select LEDGER_SETTLEMENT AS SETTLEMENTDATE FROM LEDGERMASTER WHERE LEDGERMASTER.LEDGER_CODE = '" & PARTYNAME & "'", tempconn)
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            dr = tempcmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                If IsDBNull(dr("SETTLEMENTDATE")) = False Then SETTLEMENTDATE = dr("SETTLEMENTDATE") Else SETTLEMENTDATE = "01/01/2016"
            End If

            If DATECHECK = False Then FROMDATE = SETTLEMENTDATE

            If SETTLEMENTDATE < FROMDATE Then
                tempcmd = New OleDbCommand(" Select IIF(ISNULL(Sum(account_nettwt)) = TRUE , 0, Sum(account_nettwt) ) AS Nettwt, IIF(ISNULL(Sum(account_AMOUNT) ) = TRUE , 0, Sum(account_AMOUNT) ) AS Amt FROM ACCOUNTMAST WHERE ACCOUNTMAST.ACCOUNT_LEDGERCODE = '" & PARTYNAME & "' AND ACCOUNTMAST.ACCOUNT_DATE < #" & Format(FROMDATE, "MM/dd/yyyy") & "# and account_balorjamaorpaid = 'Jama'", tempconn)
            Else
                tempcmd = New OleDbCommand(" Select IIF(ISNULL(Sum(account_nettwt)) = TRUE , 0, Sum(account_nettwt) ) AS Nettwt, IIF(ISNULL(Sum(account_AMOUNT) ) = TRUE , 0, Sum(account_AMOUNT) ) AS Amt FROM ACCOUNTMAST WHERE ACCOUNTMAST.ACCOUNT_LEDGERCODE = '" & PARTYNAME & "' AND ACCOUNTMAST.ACCOUNT_DATE <= #" & Format(SETTLEMENTDATE, "MM/dd/yyyy") & "# and account_balorjamaorpaid = 'Jama'", tempconn)
            End If
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            dr = tempcmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                OPJAMA = dr("NETTWT")
                OPJAMAAMT = dr("AMT")
            End If


            If SETTLEMENTDATE < FROMDATE Then
                tempcmd = New OleDbCommand(" Select IIF(ISNULL(Sum(account_nettwt)) = TRUE , 0, Sum(account_nettwt) ) AS Nettwt, IIF(ISNULL(Sum(account_AMOUNT) ) = TRUE , 0, Sum(account_AMOUNT) ) AS Amt FROM ACCOUNTMAST WHERE ACCOUNTMAST.ACCOUNT_LEDGERCODE = '" & PARTYNAME & "' AND ACCOUNTMAST.ACCOUNT_DATE < #" & Format(FROMDATE, "MM/dd/yyyy") & "# and account_balorjamaorpaid = 'Balance'", tempconn)
            Else
                tempcmd = New OleDbCommand(" Select IIF(ISNULL(Sum(account_nettwt)) = TRUE , 0, Sum(account_nettwt) ) AS Nettwt, IIF(ISNULL(Sum(account_AMOUNT) ) = TRUE , 0, Sum(account_AMOUNT) ) AS Amt FROM ACCOUNTMAST WHERE ACCOUNTMAST.ACCOUNT_LEDGERCODE = '" & PARTYNAME & "' AND ACCOUNTMAST.ACCOUNT_DATE <= #" & Format(SETTLEMENTDATE, "MM/dd/yyyy") & "# and account_balorjamaorpaid = 'Balance'", tempconn)
            End If
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            dr = tempcmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                OPBALANCE = dr("NETTWT")
                OPBALANCEAMT = dr("AMT")
            End If

            'get PARTYOPENING AMT
            tempcmd = New OleDbCommand(" Select IIF(LEDGER_DRCRRS = 'Cr.' , LEDGER_OPBALRS, 0 ) AS OPBALDR, IIF(LEDGER_DRCRRS = 'Dr.' , LEDGER_OPBALRS, 0 ) AS OPBALCR FROM LEDGERMASTER WHERE LEDGERMASTER.LEDGER_CODE = '" & PARTYNAME & "'", tempconn)
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            dr = tempcmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                OPJAMAAMT = OPJAMAAMT + dr("OPBALDR")
                OPBALANCEAMT = OPBALANCEAMT + dr("OPBALCR")
            End If


            'get PARTYOPENING BALANCE
            tempcmd = New OleDbCommand(" Select IIF(LEDGER_DRCRWT = 'Cr.' , LEDGER_OPBALWT, 0 ) AS OPBALDR, IIF(LEDGER_DRCRWT = 'Dr.' , LEDGER_OPBALWT, 0 ) AS OPBALCR FROM LEDGERMASTER WHERE LEDGERMASTER.LEDGER_CODE = '" & PARTYNAME & "'", tempconn)
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            dr = tempcmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                OPJAMA = OPJAMA + dr("OPBALDR")
                OPBALANCE = OPBALANCE + dr("OPBALCR")
            End If


            'WRITE OP BAL
            If OPJAMA > OPBALANCE Then
                RowIndex = 6
                Write("Opening", Range("1"), XlHAlign.xlHAlignRight, Range("7"), False, 9)
                Write(Format(Val(OPJAMA - OPBALANCE), "0.000"), Range("8"), XlHAlign.xlHAlignRight, , False, 9)
            Else
                RowIndex = 6
                Write("Opening", Range("10"), XlHAlign.xlHAlignRight, Range("16"), False, 9)
                Write(Format(Val(OPBALANCE - OPJAMA), "0.000"), Range("17"), XlHAlign.xlHAlignRight, , False, 9)
            End If

            'WRITE OPAMT
            If OPJAMAAMT > OPBALANCEAMT Then
                RowIndex = 6
                Write("Opening", Range("1"), XlHAlign.xlHAlignRight, Range("7"), False, 9)
                Write(Format(Val(OPJAMAAMT - OPBALANCEAMT), "0.000"), Range("9"), XlHAlign.xlHAlignRight, , False, 9)
            Else
                RowIndex = 6
                Write("Opening", Range("10"), XlHAlign.xlHAlignRight, Range("16"), False, 9)
                Write(Format(Val(OPBALANCEAMT - OPJAMAAMT), "0.000"), Range("18"), XlHAlign.xlHAlignRight, , False, 9)
            End If
            '************************** END OF OPENING CODE ***************************************


            'JAMA
            Dim dtjama As New System.Data.DataTable
            tempcmd = New OleDbCommand(" SELECT LEDGERDETAILVIEW.account_date AS AccDate, LEDGERDETAILVIEW.item_code AS ItemCode, LEDGERDETAILVIEW.account_ITEMDESC AS Narr, LEDGERDETAILVIEW.account_bullion AS Bullion, LEDGERDETAILVIEW.account_wastage AS Wastage, LEDGERDETAILVIEW.account_purity AS Purity, LEDGERDETAILVIEW.account_grosswt AS Grosswt, LEDGERDETAILVIEW.account_nettwt AS Nettwt, LEDGERDETAILVIEW.account_amount AS Amt FROM LEDGERDETAILVIEW " & CONDITION & " and account_balorjamaorpaid = 'Jama' ORDER BY LEDGERDETAILVIEW.account_date ", tempconn)
            da = New System.Data.OleDb.OleDbDataAdapter(tempcmd)
            da.Fill(dtjama)
            If dtjama.Rows.Count > 0 Then
                Dim JSTARTROW As Integer = RowIndex
                For Each DRJAMA As System.Data.DataRow In dtjama.Rows
                    RowIndex += 1
                    Write(DRJAMA("AccDate"), Range("1"), XlHAlign.xlHAlignCenter, , False, 9)
                    Write(DRJAMA("ItemCode"), Range("2"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(DRJAMA("Narr"), Range("3"), XlHAlign.xlHAlignLeft, , False, 9, True)
                    Write(DRJAMA("Wastage"), Range("4"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DRJAMA("Purity"), Range("5"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DRJAMA("Bullion"), Range("6"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DRJAMA("Grosswt"), Range("7"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DRJAMA("Nettwt"), Range("8"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DRJAMA("Amt"), Range("9"), XlHAlign.xlHAlignRight, , False, 9)
                Next
            End If
            Dim JENDROW As Integer = RowIndex



            'ISSUE
            Dim dtISSUE As New System.Data.DataTable
            tempcmd = New OleDbCommand(" SELECT LEDGERDETAILVIEW.account_date AS AccDate, LEDGERDETAILVIEW.item_code AS ItemCode, LEDGERDETAILVIEW.account_ITEMDESC AS Narr, LEDGERDETAILVIEW.account_bullion AS Bullion, LEDGERDETAILVIEW.account_wastage AS Wastage, LEDGERDETAILVIEW.account_purity AS Purity, LEDGERDETAILVIEW.account_grosswt AS Grosswt, LEDGERDETAILVIEW.account_nettwt AS Nettwt, LEDGERDETAILVIEW.account_amount AS Amt FROM LEDGERDETAILVIEW " & CONDITION & " and account_balorjamaorpaid = 'Balance' ORDER BY LEDGERDETAILVIEW.account_date", tempconn)
            da = New System.Data.OleDb.OleDbDataAdapter(tempcmd)
            da.Fill(dtISSUE)
            If dtISSUE.Rows.Count > 0 Then
                RowIndex = 6
                For Each DRISSUE As System.Data.DataRow In dtISSUE.Rows
                    RowIndex += 1
                    Write(DRISSUE("AccDate"), Range("10"), XlHAlign.xlHAlignCenter, , False, 9)
                    Write(DRISSUE("ItemCode"), Range("11"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(DRISSUE("Narr"), Range("12"), XlHAlign.xlHAlignLeft, , False, 9, True)
                    Write(DRISSUE("Wastage"), Range("13"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DRISSUE("Purity"), Range("14"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DRISSUE("Bullion"), Range("15"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DRISSUE("Grosswt"), Range("16"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DRISSUE("Nettwt"), Range("17"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DRISSUE("Amt"), Range("18"), XlHAlign.xlHAlignRight, , False, 9)
                Next
            End If
            If RowIndex < JENDROW Then RowIndex = JENDROW

            SetBorder(RowIndex, objColumn.Item("1").ToString & 6, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 6, objColumn.Item("18").ToString & RowIndex)




            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("3"), True, 10)
            Write("Total :", Range("10"), XlHAlign.xlHAlignRight, Range("12"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("3"))
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, Range("12"))


            objSheet.Range(objColumn.Item("4").ToString & 7, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("7").ToString & 7, objColumn.Item("7").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("8").ToString & 7, objColumn.Item("8").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("13").ToString & 7, objColumn.Item("13").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("16").ToString & 7, objColumn.Item("16").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("17").ToString & 7, objColumn.Item("17").ToString & RowIndex).NumberFormat = "0.000"



            'TO AVOID ERROR IF NO RECORDS
            If RowIndex > 7 Then
                For i As Integer = 4 To 18
                    If i <> 10 And i <> 11 And i <> 12 Then
                        If i <> 5 And i <> 14 Then FORMULA("=SUM(" & objColumn.Item(i.ToString).ToString & 6 & ":" & objColumn.Item(i.ToString).ToString & RowIndex - 1 & ")", Range(i.ToString), XlHAlign.xlHAlignRight, , True, 10)
                    End If
                Next
            End If
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, Range("9"))
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, Range("18"))



            RowIndex += 2
            'Write("Balance Gross :", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 10)
            FORMULA("=""Balance Gross : "" &  ROUND((" & objColumn.Item("7").ToString & RowIndex - 2 & "-" & objColumn.Item("16").ToString & RowIndex - 2 & "),3)", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 9)
            'objSheet.Range(objColumn.Item("3").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.000"


            RowIndex += 1
            'Write("Balance Nett :", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 10)
            FORMULA("=""Balance Nett : "" &  ROUND((" & objColumn.Item("8").ToString & RowIndex - 3 & "-" & objColumn.Item("17").ToString & RowIndex - 3 & "),3)", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 9)
            'objSheet.Range(objColumn.Item("3").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.000"


            RowIndex += 1
            'Write("Balance Amount :", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 10)
            FORMULA("=""Balance Amount : "" &  ROUND((" & objColumn.Item("9").ToString & RowIndex - 4 & "-" & objColumn.Item("18").ToString & RowIndex - 4 & "),2)", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 10)
            'objSheet.Range(objColumn.Item("3").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.000"




            objBook.Application.ActiveWindow.Zoom = 100

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .TopMargin = 20
                .LeftMargin = 20
                .RightMargin = 20
                .BottomMargin = 20
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function ALL_PARTY_ACCOUNTS_EXCEL(ByVal PARTYNAME As String, ByVal NARR As Boolean, ByVal ITEMCODE As Boolean, ByVal PURITY As Boolean, ByVal BULLION As Boolean, ByVal WAST As Boolean, ByVal GROSS As Boolean, ByVal NETT As Boolean, ByVal AMT As Boolean, Optional ByVal CONDITION As String = "") As Object
        Try

            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next

            Dim tempcmd As New OleDbCommand(" Select DISTINCT ACCOUNT_LEDGERCODE AS PARTYNAME  FROM ACCOUNTMAST", tempconn)
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            Dim DA As New OleDbDataAdapter(tempcmd)
            Dim DTPARTY As New System.Data.DataTable
            DA.Fill(DTPARTY)
            If DTPARTY.Rows.Count > 0 Then

                For Each DRPARTY As System.Data.DataRow In DTPARTY.Rows

                    PARTYNAME = DRPARTY("PARTYNAME")

                    SetWorkSheet()



                    RowIndex = 1
                    For i As Integer = 1 To 26
                        SetColumnWidth(Range(i), 9)
                    Next

                    SetColumnWidth("A1", 10)
                    SetColumnWidth("B1", 9)
                    SetColumnWidth("C1", 13)
                    SetColumnWidth("D1", 6)
                    SetColumnWidth("E1", 8)
                    SetColumnWidth("F1", 6)

                    SetColumnWidth("J1", 10)
                    SetColumnWidth("K1", 9)
                    SetColumnWidth("L1", 13)
                    SetColumnWidth("M1", 6)
                    SetColumnWidth("N1", 8)
                    SetColumnWidth("O1", 6)

                    If NARR = False Then
                        SetColumnWidth("C1", 0)
                        SetColumnWidth("L1", 0)
                    End If
                    If ITEMCODE = False Then
                        SetColumnWidth("B1", 0)
                        SetColumnWidth("K1", 0)
                    End If
                    If WAST = False Then
                        SetColumnWidth("D1", 0)
                        SetColumnWidth("M1", 0)
                    End If
                    If PURITY = False Then
                        SetColumnWidth("E1", 0)
                        SetColumnWidth("N1", 0)
                    End If
                    If BULLION = False Then
                        SetColumnWidth("F1", 0)
                        SetColumnWidth("O1", 0)
                    End If
                    If GROSS = False Then
                        SetColumnWidth("G1", 0)
                        SetColumnWidth("P1", 0)
                    End If
                    If NETT = False Then
                        SetColumnWidth("H1", 0)
                        SetColumnWidth("Q1", 0)
                    End If
                    If AMT = False Then
                        SetColumnWidth("I1", 0)
                        SetColumnWidth("R1", 0)
                    End If


                    ''''''''''Report Title
                    'CMPNAME
                    RowIndex = 2
                    Write(tempcmpname, Range("1"), XlHAlign.xlHAlignCenter, Range("18"), True, 14)
                    SetBorder(RowIndex, Range("1"), Range("18"))

                    'PARTY NAME
                    RowIndex += 1
                    Write("Ledger Accounts (" & PARTYNAME & ")", Range("1"), XlHAlign.xlHAlignCenter, Range("18"), True, 10)
                    SetBorder(RowIndex, Range("1"), Range("18"))

                    'RECEIPT/JAMA
                    RowIndex += 1
                    Write("Receipt/Jama", Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 9)
                    SetBorder(RowIndex, Range("1"), Range("9"))
                    Write("Issue/Naame", Range("10"), XlHAlign.xlHAlignCenter, Range("18"), True, 9)
                    SetBorder(RowIndex, Range("10"), Range("18"))


                    'COLUMNS NAME
                    RowIndex += 1
                    Write("Date", Range("1"), XlHAlign.xlHAlignCenter, , True, 9)
                    Write("Item", Range("2"), XlHAlign.xlHAlignCenter, , True, 9)
                    Write("Narr", Range("3"), XlHAlign.xlHAlignCenter, , True, 9)
                    Write("Wst", Range("4"), XlHAlign.xlHAlignCenter, , True, 9)
                    Write("Pur.", Range("5"), XlHAlign.xlHAlignCenter, , True, 9)
                    Write("Bull.", Range("6"), XlHAlign.xlHAlignCenter, , True, 9)
                    Write("Gross Wt.", Range("7"), XlHAlign.xlHAlignCenter, , True, 9)
                    Write("Nett Wt.", Range("8"), XlHAlign.xlHAlignCenter, , True, 9)
                    Write("Amt.", Range("9"), XlHAlign.xlHAlignCenter, , True, 9)
                    SetBorder(RowIndex, Range("1"), Range("9"))

                    Write("Date", Range("10"), XlHAlign.xlHAlignCenter, , True, 9)
                    Write("Item", Range("11"), XlHAlign.xlHAlignCenter, , True, 9)
                    Write("Narr", Range("12"), XlHAlign.xlHAlignCenter, , True, 9)
                    Write("Wst", Range("13"), XlHAlign.xlHAlignCenter, , True, 9)
                    Write("Pur.", Range("14"), XlHAlign.xlHAlignCenter, , True, 9)
                    Write("Bull.", Range("15"), XlHAlign.xlHAlignCenter, , True, 9)
                    Write("Gross Wt.", Range("16"), XlHAlign.xlHAlignCenter, , True, 9)
                    Write("Nett Wt.", Range("17"), XlHAlign.xlHAlignCenter, , True, 9)
                    Write("Amt.", Range("18"), XlHAlign.xlHAlignCenter, , True, 9)
                    SetBorder(RowIndex, Range("10"), Range("18"))


                    'FREEZE TOP 6 ROWS
                    objSheet.Range(objColumn.Item("1").ToString & 6, objColumn.Item("18").ToString & 6).Select()
                    objSheet.Range(objColumn.Item("1").ToString & 6, objColumn.Item("18").ToString & 6).Application.ActiveWindow.FreezePanes = True


                    '************************** START OF OPENING CODE ***************************************
                    'GET OPENING JAMA OR ISSUE
                    Dim OPJAMA As Double = 0.0
                    Dim OPJAMAAMT As Double = 0.0
                    Dim OPBALANCE As Double = 0.0
                    Dim OPBALANCEAMT As Double = 0.0

                    'GET SETTLEMENT DATE FIRST
                    Dim SETTLEMENTDATE As Date
                    tempcmd = New OleDbCommand(" Select LEDGER_SETTLEMENT AS SETTLEMENTDATE FROM LEDGERMASTER WHERE LEDGERMASTER.LEDGER_CODE = '" & PARTYNAME & "'", tempconn)
                    If tempconn.State = ConnectionState.Open Then tempconn.Close()
                    tempconn.Open()
                    dr = tempcmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        SETTLEMENTDATE = dr("SETTLEMENTDATE")
                    End If


                    tempcmd = New OleDbCommand(" Select IIF(ISNULL(Sum(account_nettwt)) = TRUE , 0, Sum(account_nettwt) ) AS Nettwt, IIF(ISNULL(Sum(account_AMOUNT) ) = TRUE , 0, Sum(account_AMOUNT) ) AS Amt FROM ACCOUNTMAST WHERE ACCOUNTMAST.ACCOUNT_LEDGERCODE = '" & PARTYNAME & "' AND ACCOUNTMAST.ACCOUNT_DATE <= #" & Format(SETTLEMENTDATE, "MM/dd/yyyy") & "# and account_balorjamaorpaid = 'Jama'", tempconn)
                    If tempconn.State = ConnectionState.Open Then tempconn.Close()
                    tempconn.Open()
                    dr = tempcmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        OPJAMA = dr("NETTWT")
                        OPJAMAAMT = dr("AMT")
                    End If

                    tempcmd = New OleDbCommand(" Select IIF(ISNULL(Sum(account_nettwt) ) = TRUE , 0, Sum(account_nettwt) ) AS Nettwt, IIF(ISNULL(Sum(account_AMOUNT) ) = TRUE , 0, Sum(account_AMOUNT) ) AS Amt FROM ACCOUNTMAST WHERE ACCOUNTMAST.ACCOUNT_LEDGERCODE = '" & PARTYNAME & "' AND ACCOUNTMAST.ACCOUNT_DATE <= #" & Format(SETTLEMENTDATE, "MM/dd/yyyy") & "# and account_balorjamaorpaid = 'Balance'", tempconn)
                    If tempconn.State = ConnectionState.Open Then tempconn.Close()
                    tempconn.Open()
                    dr = tempcmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        OPBALANCE = dr("NETTWT")
                        OPBALANCEAMT = dr("AMT")
                    End If

                    'get PARTYOPENING AMT
                    tempcmd = New OleDbCommand(" Select IIF(LEDGER_DRCRRS = 'Cr.' , LEDGER_OPBALRS, 0 ) AS OPBALDR, IIF(LEDGER_DRCRRS = 'Dr.' , LEDGER_OPBALRS, 0 ) AS OPBALCR FROM LEDGERMASTER WHERE LEDGERMASTER.LEDGER_CODE = '" & PARTYNAME & "'", tempconn)
                    If tempconn.State = ConnectionState.Open Then tempconn.Close()
                    tempconn.Open()
                    dr = tempcmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        OPJAMAAMT = OPJAMAAMT + dr("OPBALDR")
                        OPBALANCEAMT = OPBALANCEAMT + dr("OPBALCR")
                    End If


                    'get PARTYOPENING BALANCE
                    tempcmd = New OleDbCommand(" Select IIF(LEDGER_DRCRWT = 'Cr.' , LEDGER_OPBALWT, 0 ) AS OPBALDR, IIF(LEDGER_DRCRWT = 'Dr.' , LEDGER_OPBALWT, 0 ) AS OPBALCR FROM LEDGERMASTER WHERE LEDGERMASTER.LEDGER_CODE = '" & PARTYNAME & "'", tempconn)
                    If tempconn.State = ConnectionState.Open Then tempconn.Close()
                    tempconn.Open()
                    dr = tempcmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        OPJAMA = OPJAMA + dr("OPBALDR")
                        OPBALANCE = OPBALANCE + dr("OPBALCR")
                    End If


                    'WRITE OP BAL
                    If OPJAMA > OPBALANCE Then
                        RowIndex = 6
                        Write("Opening", Range("1"), XlHAlign.xlHAlignRight, Range("7"), False, 9)
                        Write(Format(Val(OPJAMA - OPBALANCE), "0.000"), Range("8"), XlHAlign.xlHAlignRight, , False, 9)
                    Else
                        RowIndex = 6
                        Write("Opening", Range("10"), XlHAlign.xlHAlignRight, Range("16"), False, 9)
                        Write(Format(Val(OPBALANCE - OPJAMA), "0.000"), Range("17"), XlHAlign.xlHAlignRight, , False, 9)
                    End If

                    'WRITE OPAMT
                    If OPJAMAAMT > OPBALANCEAMT Then
                        RowIndex = 6
                        Write("Opening", Range("1"), XlHAlign.xlHAlignRight, Range("7"), False, 9)
                        Write(Format(Val(OPJAMAAMT - OPBALANCEAMT), "0.000"), Range("9"), XlHAlign.xlHAlignRight, , False, 9)
                    Else
                        RowIndex = 6
                        Write("Opening", Range("10"), XlHAlign.xlHAlignRight, Range("16"), False, 9)
                        Write(Format(Val(OPBALANCEAMT - OPJAMAAMT), "0.000"), Range("18"), XlHAlign.xlHAlignRight, , False, 9)
                    End If
                    '************************** END OF OPENING CODE ***************************************


                    'JAMA
                    Dim dtjama As New System.Data.DataTable
                    tempcmd = New OleDbCommand(" Select account_date as [AccDate], item_code as [ItemCode], account_narration as [Narr], account_bullion as [Bullion],  account_wastage as [Wastage], account_purity as [Purity], account_grosswt as [Grosswt], account_nettwt as [Nettwt], account_amount as [Amt] FROM ACCOUNTMAST " & CONDITION & " and account_balorjamaorpaid = 'Jama' ORDER BY account_date ", tempconn)
                    DA = New System.Data.OleDb.OleDbDataAdapter(tempcmd)
                    DA.Fill(dtjama)
                    If dtjama.Rows.Count > 0 Then
                        Dim JSTARTROW As Integer = RowIndex
                        For Each DRJAMA As System.Data.DataRow In dtjama.Rows
                            RowIndex += 1
                            Write(DRJAMA("AccDate"), Range("1"), XlHAlign.xlHAlignCenter, , False, 9)
                            Write(DRJAMA("ItemCode"), Range("2"), XlHAlign.xlHAlignLeft, , False, 9)
                            Write(DRJAMA("Narr"), Range("3"), XlHAlign.xlHAlignLeft, , False, 9, True)
                            Write(DRJAMA("Wastage"), Range("4"), XlHAlign.xlHAlignRight, , False, 9)
                            Write(DRJAMA("Purity"), Range("5"), XlHAlign.xlHAlignRight, , False, 9)
                            Write(DRJAMA("Bullion"), Range("6"), XlHAlign.xlHAlignRight, , False, 9)
                            Write(DRJAMA("Grosswt"), Range("7"), XlHAlign.xlHAlignRight, , False, 9)
                            Write(DRJAMA("Nettwt"), Range("8"), XlHAlign.xlHAlignRight, , False, 9)
                            Write(DRJAMA("Amt"), Range("9"), XlHAlign.xlHAlignRight, , False, 9)
                        Next
                    End If
                    Dim JENDROW As Integer = RowIndex



                    'ISSUE
                    Dim dtISSUE As New System.Data.DataTable
                    tempcmd = New OleDbCommand(" Select account_date as [AccDate], item_code as [ItemCode], account_narration as [Narr], account_bullion as [Bullion],  account_wastage as [Wastage], account_purity as [Purity], account_grosswt as [Grosswt], account_nettwt as [Nettwt], account_amount as [Amt] FROM ACCOUNTMAST " & CONDITION & " and account_balorjamaorpaid = 'Balance' ORDER BY account_date", tempconn)
                    DA = New System.Data.OleDb.OleDbDataAdapter(tempcmd)
                    DA.Fill(dtISSUE)
                    If dtISSUE.Rows.Count > 0 Then
                        RowIndex = 6
                        For Each DRISSUE As System.Data.DataRow In dtISSUE.Rows
                            RowIndex += 1
                            Write(DRISSUE("AccDate"), Range("10"), XlHAlign.xlHAlignCenter, , False, 9)
                            Write(DRISSUE("ItemCode"), Range("11"), XlHAlign.xlHAlignLeft, , False, 9)
                            Write(DRISSUE("Narr"), Range("12"), XlHAlign.xlHAlignLeft, , False, 9, True)
                            Write(DRISSUE("Wastage"), Range("13"), XlHAlign.xlHAlignRight, , False, 9)
                            Write(DRISSUE("Purity"), Range("14"), XlHAlign.xlHAlignRight, , False, 9)
                            Write(DRISSUE("Bullion"), Range("15"), XlHAlign.xlHAlignRight, , False, 9)
                            Write(DRISSUE("Grosswt"), Range("16"), XlHAlign.xlHAlignRight, , False, 9)
                            Write(DRISSUE("Nettwt"), Range("17"), XlHAlign.xlHAlignRight, , False, 9)
                            Write(DRISSUE("Amt"), Range("18"), XlHAlign.xlHAlignRight, , False, 9)
                        Next
                    End If
                    If RowIndex < JENDROW Then RowIndex = JENDROW

                    SetBorder(RowIndex, objColumn.Item("1").ToString & 6, objColumn.Item("9").ToString & RowIndex)
                    SetBorder(RowIndex, objColumn.Item("10").ToString & 6, objColumn.Item("18").ToString & RowIndex)




                    RowIndex += 1
                    Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("3"), True, 10)
                    Write("Total :", Range("10"), XlHAlign.xlHAlignRight, Range("12"), True, 10)
                    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("3"))
                    SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, Range("12"))


                    objSheet.Range(objColumn.Item("4").ToString & 7, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.000"
                    objSheet.Range(objColumn.Item("7").ToString & 7, objColumn.Item("7").ToString & RowIndex).NumberFormat = "0.000"
                    objSheet.Range(objColumn.Item("8").ToString & 7, objColumn.Item("8").ToString & RowIndex).NumberFormat = "0.000"
                    objSheet.Range(objColumn.Item("13").ToString & 7, objColumn.Item("13").ToString & RowIndex).NumberFormat = "0.000"
                    objSheet.Range(objColumn.Item("16").ToString & 7, objColumn.Item("16").ToString & RowIndex).NumberFormat = "0.000"
                    objSheet.Range(objColumn.Item("17").ToString & 7, objColumn.Item("17").ToString & RowIndex).NumberFormat = "0.000"



                    'TO AVOID ERROR IF NO RECORDS
                    If RowIndex > 6 Then
                        For i As Integer = 4 To 18
                            If i <> 10 And i <> 11 And i <> 12 Then
                                If i <> 5 And i <> 14 Then FORMULA("=SUM(" & objColumn.Item(i.ToString).ToString & 6 & ":" & objColumn.Item(i.ToString).ToString & RowIndex - 1 & ")", Range(i.ToString), XlHAlign.xlHAlignRight, , True, 10)
                            End If
                        Next
                    End If
                    SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, Range("9"))
                    SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, Range("18"))



                    RowIndex += 2
                    'Write("Balance Gross :", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 10)
                    FORMULA("= ""Balance Gross :"" & ROUND((" & objColumn.Item("7").ToString & RowIndex - 2 & "-" & objColumn.Item("16").ToString & RowIndex - 2 & "),3)", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 9)
                    'objSheet.Range(objColumn.Item("3").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.000"


                    RowIndex += 1
                    'Write("Balance Nett :", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 10)
                    FORMULA("= ""Balance Nett :"" & ROUND((" & objColumn.Item("8").ToString & RowIndex - 3 & "-" & objColumn.Item("17").ToString & RowIndex - 3 & "),3)", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 9)
                    'objSheet.Range(objColumn.Item("3").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.000"


                    RowIndex += 1
                    'Write("Balance Amount :", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 10)
                    FORMULA("= ""Balance Amount :"" & ROUND((" & objColumn.Item("9").ToString & RowIndex - 3 & "-" & objColumn.Item("18").ToString & RowIndex - 3 & "),2)", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 10)
                    'objSheet.Range(objColumn.Item("3").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.000"





                    objBook.Application.ActiveWindow.Zoom = 100

                    With objSheet.PageSetup
                        .Orientation = XlPageOrientation.xlPortrait
                        .TopMargin = 20
                        .LeftMargin = 20
                        .RightMargin = 20
                        .BottomMargin = 20
                        .Zoom = False
                        .FitToPagesTall = 1
                        .FitToPagesWide = 1
                    End With
                Next

            End If
            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function PARTY_DIFFDETAILS_EXCEL(ByVal PARTYNAME As String, Optional ByVal CONDITION As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 12)
            Next

            ''''''''''Report Title
            'CMPNAME
            RowIndex = 2
            Write(tempcmpname, Range("1"), XlHAlign.xlHAlignCenter, Range("7"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("7"))

            'PARTY NAME
            RowIndex += 1
            Write("Diff Report (" & PARTYNAME & ")", Range("1"), XlHAlign.xlHAlignCenter, Range("7"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("7"))

            'COLUMNS NAME
            RowIndex += 2
            Write("V. No", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Date", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("I/R", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Gross Wt.", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Nett Wt.", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Issue Wt", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Rec Wt", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, Range("1"), Range("7"))


            'FREEZE TOP 6 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 6, objColumn.Item("7").ToString & 6).Select()
            objSheet.Range(objColumn.Item("1").ToString & 6, objColumn.Item("7").ToString & 6).Application.ActiveWindow.FreezePanes = True


            Dim DT As New System.Data.DataTable
            tempcmd = New OleDbCommand(" SELECT ledgermaster.ledger_code AS NAME, vouchers.voucher_id AS VOUCHERNO, vouchers.voucher_date AS VOUCHERDATE, vouchers.voucher_type AS VOUCHERTYPE, Sum(vouchers.voucher_grosswt) AS TOTALGROSSWT, Sum(vouchers.voucher_nettwt) AS TOTALNETTWT, IIF (VOUCHERS.VOUCHER_TYPE ='I' , Sum(vouchers.VOUCHER_DIFF),0) AS ISSUEDIFF,  IIF (VOUCHERS.VOUCHER_TYPE ='R' , Sum(vouchers.VOUCHER_DIFF),0) AS RECDIFF FROM vouchers INNER JOIN ledgermaster ON vouchers.voucher_ledgerid = ledgermaster.ledger_id " & CONDITION & " GROUP BY ledgermaster.ledger_code, vouchers.voucher_date, vouchers.voucher_id, vouchers.voucher_type HAVING Sum(vouchers.VOUCHER_DIFF) <> 0  ", tempconn)
            da = New System.Data.OleDb.OleDbDataAdapter(tempcmd)
            da.Fill(DT)
            If DT.Rows.Count > 0 Then
                Dim TPARTYNAME As String = ""
                For Each DR As System.Data.DataRow In DT.Rows
                    If TPARTYNAME <> DR("NAME") Then
                        RowIndex += 2
                        Write("Name : " & DR("NAME"), Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
                        TPARTYNAME = DR("NAME")
                    End If
                    RowIndex += 1
                    Write(Val(DR("VOUCHERNO")), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(Format(Convert.ToDateTime(DR("VOUCHERDATE")).Date, "dd/MM/yyyy"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DR("VOUCHERTYPE"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(Val(DR("TOTALGROSSWT")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(Val(DR("TOTALNETTWT")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(Val(DR("ISSUEDIFF")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(Val(DR("RECDIFF")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Next
            End If

            SetBorder(RowIndex, objColumn.Item("1").ToString & 6, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 6, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 6, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 6, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 6, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 6, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 6, objColumn.Item("7").ToString & RowIndex)

            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("3"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("3"))


            objSheet.Range(objColumn.Item("4").ToString & 7, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("5").ToString & 7, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("6").ToString & 7, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("7").ToString & 7, objColumn.Item("7").ToString & RowIndex).NumberFormat = "0.000"



            'TO AVOID ERROR IF NO RECORDS
            If RowIndex > 7 Then
                For i As Integer = 4 To 7
                    FORMULA("=SUM(" & objColumn.Item(i.ToString).ToString & 6 & ":" & objColumn.Item(i.ToString).ToString & RowIndex - 1 & ")", Range(i.ToString), XlHAlign.xlHAlignRight, , True, 10)
                    SetBorder(RowIndex, objColumn.Item(i.ToString).ToString & RowIndex, Range(i.ToString))
                Next
            End If

            RowIndex += 1
            Write("Grand Total :", Range("1"), XlHAlign.xlHAlignRight, Range("3"), True, 10)
            FORMULA("=(" & objColumn.Item("6").ToString & RowIndex - 1 & "-" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, Range("7"), True, 10)
            objSheet.Range(objColumn.Item("6").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex).NumberFormat = "0.000"
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("3"))
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, Range("7"))

            objBook.Application.ActiveWindow.Zoom = 100

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .TopMargin = 20
                .LeftMargin = 20
                .RightMargin = 20
                .BottomMargin = 20
                .Zoom = False
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function PARTY_DIFFSUMM_EXCEL(ByVal PARTYNAME As String, Optional ByVal CONDITION As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 12)
            Next

            ''''''''''Report Title
            'CMPNAME
            RowIndex = 2
            Write(tempcmpname, Range("1"), XlHAlign.xlHAlignCenter, Range("7"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("7"))

            'PARTY NAME
            RowIndex += 1
            Write("Diff Report (" & PARTYNAME & ")", Range("1"), XlHAlign.xlHAlignCenter, Range("7"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("7"))

            'COLUMNS NAME
            RowIndex += 2
            Write("V. No", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Date", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("I/R", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Gross Wt.", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Nett Wt.", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Issue Wt", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Rec Wt", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, Range("1"), Range("7"))


            'FREEZE TOP 6 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 6, objColumn.Item("7").ToString & 6).Select()
            objSheet.Range(objColumn.Item("1").ToString & 6, objColumn.Item("7").ToString & 6).Application.ActiveWindow.FreezePanes = True


            Dim DT As New System.Data.DataTable
            tempcmd = New OleDbCommand(" SELECT ledgermaster.ledger_code AS NAME, vouchers.voucher_id AS VOUCHERNO, vouchers.voucher_date AS VOUCHERDATE, vouchers.voucher_type AS VOUCHERTYPE, Sum(vouchers.voucher_grosswt) AS TOTALGROSSWT, Sum(vouchers.voucher_nettwt) AS TOTALNETTWT, IIF (VOUCHERS.VOUCHER_TYPE ='I' , Sum(vouchers.VOUCHER_DIFF),0) AS ISSUEDIFF,  IIF (VOUCHERS.VOUCHER_TYPE ='R' , Sum(vouchers.VOUCHER_DIFF),0) AS RECDIFF FROM vouchers INNER JOIN ledgermaster ON vouchers.voucher_ledgerid = ledgermaster.ledger_id " & CONDITION & " GROUP BY ledgermaster.ledger_code, vouchers.voucher_date, vouchers.voucher_id, vouchers.voucher_type HAVING Sum(vouchers.VOUCHER_DIFF) <> 0  ", tempconn)
            da = New System.Data.OleDb.OleDbDataAdapter(tempcmd)
            da.Fill(DT)
            If DT.Rows.Count > 0 Then
                Dim TPARTYNAME As String = ""
                For Each DR As System.Data.DataRow In DT.Rows
                    If TPARTYNAME <> DR("NAME") Then
                        RowIndex += 2
                        Write("Name : " & DR("NAME"), Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
                        TPARTYNAME = DR("NAME")
                    End If
                    RowIndex += 1
                    Write(Val(DR("VOUCHERNO")), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(Format(Convert.ToDateTime(DR("VOUCHERDATE")).Date, "dd/MM/yyyy"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DR("VOUCHERTYPE"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(Val(DR("TOTALGROSSWT")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(Val(DR("TOTALNETTWT")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(Val(DR("ISSUEDIFF")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(Val(DR("RECDIFF")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Next
            End If

            SetBorder(RowIndex, objColumn.Item("1").ToString & 6, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 6, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 6, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 6, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 6, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 6, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 6, objColumn.Item("7").ToString & RowIndex)

            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("3"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("3"))


            objSheet.Range(objColumn.Item("4").ToString & 7, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("5").ToString & 7, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("6").ToString & 7, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("7").ToString & 7, objColumn.Item("7").ToString & RowIndex).NumberFormat = "0.000"



            'TO AVOID ERROR IF NO RECORDS
            If RowIndex > 7 Then
                For i As Integer = 4 To 7
                    FORMULA("=SUM(" & objColumn.Item(i.ToString).ToString & 6 & ":" & objColumn.Item(i.ToString).ToString & RowIndex - 1 & ")", Range(i.ToString), XlHAlign.xlHAlignRight, , True, 10)
                    SetBorder(RowIndex, objColumn.Item(i.ToString).ToString & RowIndex, Range(i.ToString))
                Next
            End If

            RowIndex += 1
            Write("Grand Total :", Range("1"), XlHAlign.xlHAlignRight, Range("3"), True, 10)
            FORMULA("=(" & objColumn.Item("6").ToString & RowIndex - 1 & "-" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, Range("7"), True, 10)
            objSheet.Range(objColumn.Item("6").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex).NumberFormat = "0.000"
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("3"))
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, Range("7"))

            objBook.Application.ActiveWindow.Zoom = 100

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .TopMargin = 20
                .LeftMargin = 20
                .RightMargin = 20
                .BottomMargin = 20
                .Zoom = False
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "KARIGAR ACCOUNTS REPORT"

    Public Function KARIGARDETAILS_REPORT_EXCEL(ByVal PARTYNAME As String, ByVal DT As System.Data.DataTable, ByVal PERIOD As String) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 9)
            Next

            ''''''''''Report Title
            'CMPNAME
            RowIndex = 2
            Write(tempcmpname, Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("8"))

            'PARTY NAME
            RowIndex += 1
            Write("Karigar Accounts (" & PARTYNAME & ")", Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("8"))

            'PERIOD
            RowIndex += 1
            Write(PERIOD, Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("8"))


            'COLUMNS NAME
            RowIndex += 1
            Write("Date", Range("1"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Item", Range("2"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Gross Wt.", Range("3"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Pur.", Range("4"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Lot No", Range("5"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Part No", Range("6"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Lab", Range("7"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Amt.", Range("8"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("1"), Range("8"))

            'FREEZE TOP 6 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 6, objColumn.Item("8").ToString & 6).Select()
            objSheet.Range(objColumn.Item("1").ToString & 6, objColumn.Item("8").ToString & 6).Application.ActiveWindow.FreezePanes = True

            Dim GM As String = ""
            If DT.Rows.Count > 0 Then
                GM = DT.Rows(0).Item("GM")  'FOR 1ST TIME
                RowIndex += 1
                Write("GM : " & GM, Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
                For Each DTROW As System.Data.DataRow In DT.Rows
                    If GM = DTROW("GM") Then
LINE1:
                        If DTROW("LOTNO") <> 0 Then RowIndex += 1
                        If DTROW("LOTNO") <> 0 Then Write(DTROW("DATE"), Range("1"), XlHAlign.xlHAlignCenter, , False, 9)
                        Write(DTROW("ITEMCODE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 9)
                        Write(DTROW("OUTPUTWT"), Range("3"), XlHAlign.xlHAlignRight, , False, 9, True)
                        Write(DTROW("FINALPERCENT"), Range("4"), XlHAlign.xlHAlignRight, , False, 9)
                        Write(DTROW("LOTNO"), Range("5"), XlHAlign.xlHAlignLeft, , False, 9)
                        If DTROW("PARTNO") <> "" Then Write("Part(" & DTROW("PARTNO") & ")", Range("6"), XlHAlign.xlHAlignLeft, , False, 9)
                        Write(DTROW("LABOUR"), Range("7"), XlHAlign.xlHAlignRight, , False, 9)
                        Write(DTROW("AMOUNT"), Range("8"), XlHAlign.xlHAlignRight, , False, 9)
                    Else
                        If DTROW("LOTNO") <> 0 Then
                            RowIndex += 2
                        Else
                            RowIndex += 1
                        End If
                        Write("GM : " & DTROW("GM"), Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
                        GM = DTROW("GM")
                        GoTo LINE1
                    End If
                Next
            End If

            SetBorder(RowIndex, objColumn.Item("1").ToString & 6, objColumn.Item("8").ToString & RowIndex)


            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("2"))
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, Range("3"))
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, Range("8"))
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, Range("8"))

            FORMULA("=SUM(" & objColumn.Item("3").ToString & 4 & ":" & objColumn.Item("3").ToString & RowIndex - 1 & ")", Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & 4 & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 10)

            objSheet.Range(objColumn.Item("3").ToString & 1, objColumn.Item("3").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("7").ToString & 1, objColumn.Item("7").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("8").ToString & 1, objColumn.Item("8").ToString & RowIndex).NumberFormat = "0.000"


            objBook.Application.ActiveWindow.Zoom = 100

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .TopMargin = 20
                .LeftMargin = 20
                .RightMargin = 20
                .BottomMargin = 20
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function KARIGARLEDGER_REPORT_EXCEL(ByVal PARTYNAME As String, ByVal DT As System.Data.DataTable, ByVal PERIOD As String) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 10)
            Next

            SetColumnWidth(Range("3"), 20)

            ''''''''''Report Title
            'CMPNAME
            RowIndex = 2
            Write(tempcmpname, Range("1"), XlHAlign.xlHAlignCenter, Range("14"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("14"))

            'PARTY NAME
            RowIndex += 1
            Write("Karigar Ledger (" & PARTYNAME & ")", Range("1"), XlHAlign.xlHAlignCenter, Range("14"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("14"))

            'PERIOD
            RowIndex += 1
            Write(PERIOD, Range("1"), XlHAlign.xlHAlignCenter, Range("14"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("14"))


            'COLUMNS NAME
            RowIndex += 1
            Write("Receipt", Range("6"), XlHAlign.xlHAlignCenter, Range("9"), True, 9)
            SetBorder(RowIndex, Range("6"), Range("9"))
            Write("Issue", Range("10"), XlHAlign.xlHAlignCenter, Range("14"), True, 9)
            SetBorder(RowIndex, Range("1"), Range("14"))
            objSheet.Range(Range("6"), Range("9")).Interior.Color = RGB(255, 204, 255)
            objSheet.Range(Range("10"), Range("14")).Interior.Color = RGB(255, 192, 0)

            RowIndex += 1
            Write("Lot No", Range("1"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("Part No", Range("2"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("2"), Range("2"))
            Write("Item Name", Range("3"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("3"), Range("3"))
            Write("Wastage", Range("4"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("4"), Range("4"))
            Write("Excess", Range("5"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("5"), Range("5"))
            Write("Date", Range("6"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("6"), Range("6"))
            Write("Pur.", Range("7"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("7"), Range("7"))
            Write("Gross Wt", Range("8"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("8"), Range("8"))
            Write("Nett Wt", Range("9"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("9"), Range("9"))
            Write("Date", Range("10"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("10"), Range("10"))
            Write("Item Name", Range("11"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("11"), Range("11"))
            Write("Pur.", Range("12"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("12"), Range("12"))
            Write("Gross Wt", Range("13"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("13"), Range("13"))
            Write("Nett Wt", Range("14"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("14"), Range("14"))
            objSheet.Range(Range("1"), Range("14")).Interior.Color = RGB(213, 228, 248)

            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 7, objColumn.Item("14").ToString & 7).Select()
            objSheet.Range(objColumn.Item("1").ToString & 7, objColumn.Item("14").ToString & 7).Application.ActiveWindow.FreezePanes = True


            Dim LASTLOTNO As Integer = 0
            Dim LASTPARTNO As String = ""
            Dim ITEMDT As New System.Data.DataTable
            For Each DTROW As System.Data.DataRow In DT.Rows
                Dim ITEMNAME As String = ""

                tempcmd = New OleDbCommand(" SELECT * FROM (SELECT (mfgmaster.mfg_lotno) as lotno, 'Part(' & mfgstock.mfg_partno & ')' AS PARTNO ,mfgstock.mfg_narration as NAME FROM mfgmaster INNER JOIN mfgstock ON mfgmaster.mfg_no = mfgstock.mfg_no UNION ALL SELECT (mfgmaster_1.mfg_lotno) AS lotno, 'Part(' & itemstock.item_partno & ')' AS PARTNO, ItemMaster.item_name AS name FROM (mfgmaster AS mfgmaster_1 INNER JOIN (itemstock LEFT JOIN ItemMaster ON itemstock.item_id = ItemMaster.item_id) ON mfgmaster_1.mfg_no = itemstock.item_no) ) AS T WHERE LOTNO = " & DTROW("LOTNO") & " AND PARTNO = '" & DTROW("PARTNO") & "'", tempconn)
                da = New OleDbDataAdapter(tempcmd)
                da.Fill(ITEMDT)
                tempconn.Close()
                da.Dispose()
                If ITEMDT.Rows.Count > 0 Then ITEMNAME = ITEMDT.Rows(0).Item("NAME")
                ITEMDT.Clear()

                'FIRST ISSUE
                If LASTLOTNO <> DTROW("LOTNO") Then
                    RowIndex += 1
                    Write(DTROW("LOTNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(DTROW("PARTNO"), Range("2"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(ITEMNAME, Range("3"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(Format(Val(DTROW("WASTAGE")), "0.000"), Range("4"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(Format(Val(DTROW("EXCESSWT")), "0.000"), Range("5"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("DATE"), Range("6"), XlHAlign.xlHAlignCenter, , False, 9)
                    Write(Format(Val(DTROW("RECPUR")), "0.00"), Range("7"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(Format(Val(DTROW("RECGROSS")), "0.000"), Range("8"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(Format(Val(DTROW("RECNETT")), "0.000"), Range("9"), XlHAlign.xlHAlignRight, , False, 9)

                    Write(DTROW("DATE"), Range("10"), XlHAlign.xlHAlignCenter, , False, 9)
                    Write(Format(Val(DTROW("ISSITEMPUR")), "0.00"), Range("12"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(Format(Val(DTROW("ISSITEMWT")), "0.000"), Range("13"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(Format(Val(DTROW("ISSITEMNETT")), "0.000"), Range("14"), XlHAlign.xlHAlignRight, , False, 9)

                    LASTLOTNO = DTROW("LOTNO")
                    LASTPARTNO = DTROW("PARTNO")
                ElseIf LASTPARTNO <> DTROW("PARTNO") Then
                    RowIndex += 1
                    Write(DTROW("PARTNO"), Range("2"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(ITEMNAME, Range("3"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(Format(Val(DTROW("WASTAGE")), "0.000"), Range("4"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(Format(Val(DTROW("EXCESSWT")), "0.000"), Range("5"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("DATE"), Range("6"), XlHAlign.xlHAlignCenter, , False, 9)
                    Write(Format(Val(DTROW("RECPUR")), "0.00"), Range("7"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(Format(Val(DTROW("RECGROSS")), "0.000"), Range("8"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(Format(Val(DTROW("RECNETT")), "0.000"), Range("9"), XlHAlign.xlHAlignRight, , False, 9)

                    Write(DTROW("DATE"), Range("10"), XlHAlign.xlHAlignCenter, , False, 9)
                    Write(Format(Val(DTROW("ISSITEMPUR")), "0.00"), Range("12"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(Format(Val(DTROW("ISSITEMWT")), "0.000"), Range("13"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(Format(Val(DTROW("ISSITEMNETT")), "0.000"), Range("14"), XlHAlign.xlHAlignRight, , False, 9)

                    LASTPARTNO = DTROW("PARTNO")
                End If

                If Val(DTROW("EXTRAITEMGROSS")) > 0 Then
                    RowIndex += 1
                    Write(DTROW("DATE"), Range("10"), XlHAlign.xlHAlignCenter, , False, 9)
                    If IsDBNull(DTROW("ITEMCODE")) = True Then Write("", Range("11"), XlHAlign.xlHAlignLeft, , False, 9) Else Write(DTROW("ITEMCODE"), Range("11"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(Format(Val(DTROW("EXTRAITEMPUR")), "0.00"), Range("12"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(Format(Val(DTROW("EXTRAITEMGROSS")), "0.000"), Range("13"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(Format(Val(DTROW("EXTRAITEMNETT")), "0.000"), Range("14"), XlHAlign.xlHAlignRight, , False, 9)
                End If

            Next

            SetBorder(RowIndex, objColumn.Item("1").ToString & 6, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 6, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 6, objColumn.Item("14").ToString & RowIndex)
            objSheet.Range(objColumn.Item("6").ToString & 7, objColumn.Item("9").ToString & RowIndex).Interior.Color = RGB(255, 204, 255)
            objSheet.Range(objColumn.Item("10").ToString & 7, objColumn.Item("14").ToString & RowIndex).Interior.Color = RGB(255, 192, 0)


            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("3"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("3"))
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, Range("4"))
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, Range("5"))
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, Range("7"))
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, Range("8"))
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, Range("9"))
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, Range("12"))
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, Range("13"))
            SetBorder(RowIndex, objColumn.Item("14").ToString & RowIndex, Range("14"))

            FORMULA("=SUM(" & objColumn.Item("4").ToString & 4 & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 4 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & 4 & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("9").ToString & 4 & ":" & objColumn.Item("9").ToString & RowIndex - 1 & ")", Range("9"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("13").ToString & 4 & ":" & objColumn.Item("13").ToString & RowIndex - 1 & ")", Range("13"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("14").ToString & 4 & ":" & objColumn.Item("14").ToString & RowIndex - 1 & ")", Range("14"), XlHAlign.xlHAlignRight, , True, 10)

            objSheet.Range(objColumn.Item("4").ToString & 1, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("5").ToString & 1, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("7").ToString & 1, objColumn.Item("7").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("8").ToString & 1, objColumn.Item("8").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("9").ToString & 1, objColumn.Item("9").ToString & RowIndex).NumberFormat = "0.000"

            objSheet.Range(objColumn.Item("12").ToString & 1, objColumn.Item("12").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("13").ToString & 1, objColumn.Item("13").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("14").ToString & 1, objColumn.Item("14").ToString & RowIndex).NumberFormat = "0.000"


            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 20
            '    .LeftMargin = 20
            '    .RightMargin = 20
            '    .BottomMargin = 20
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function SETTINGLEDGER_REPORT_EXCEL(ByVal PARTYNAME As String, ByVal DATECHECK As Boolean, ByVal FROMDATE As Date, ByVal TODATE As Date) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 9)
            Next


            ''''''''''Report Title
            'CMPNAME
            RowIndex = 2
            Write(tempcmpname, Range("1"), XlHAlign.xlHAlignCenter, Range("18"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("14"))

            'PARTY NAME
            RowIndex += 1
            Write("Karigar Accounts (" & PARTYNAME & ")", Range("1"), XlHAlign.xlHAlignCenter, Range("14"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("14"))

            'RECEIPT/JAMA
            RowIndex += 1
            Write("Receipt/Jama", Range("1"), XlHAlign.xlHAlignCenter, Range("7"), True, 9)
            SetBorder(RowIndex, Range("1"), Range("7"))
            Write("Issue/Naame", Range("8"), XlHAlign.xlHAlignCenter, Range("14"), True, 9)
            SetBorder(RowIndex, Range("8"), Range("14"))


            'COLUMNS NAME
            RowIndex += 1
            Write("Date", Range("1"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Item", Range("2"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Gross Wt.", Range("3"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Stone Wt.", Range("4"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Pur.", Range("5"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Fine Wt.", Range("6"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Narr", Range("7"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("1"), Range("7"))

            Write("Date", Range("8"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Item", Range("9"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Gross Wt.", Range("10"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Stone Wt.", Range("11"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Pur.", Range("12"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Fine Wt.", Range("13"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Narr", Range("14"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("8"), Range("14"))


            'FREEZE TOP 6 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 6, objColumn.Item("14").ToString & 6).Select()
            objSheet.Range(objColumn.Item("1").ToString & 6, objColumn.Item("14").ToString & 6).Application.ActiveWindow.FreezePanes = True


            '************************** START OF OPENING CODE ***************************************
            'GET OPENING JAMA OR ISSUE
            Dim OPJAMA As Double = 0.0
            Dim OPJAMAAMT As Double = 0.0
            Dim OPBALANCE As Double = 0.0
            Dim OPBALANCEAMT As Double = 0.0

            'GET SETTLEMENT DATE FIRST
            Dim SETTLEMENTDATE As Date
            Dim tempcmd As New OleDbCommand(" Select LEDGER_SETTLEMENT AS SETTLEMENTDATE FROM LEDGERMASTER WHERE LEDGERMASTER.LEDGER_CODE = '" & PARTYNAME & "'", tempconn)
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            dr = tempcmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                If IsDBNull(dr("SETTLEMENTDATE")) = False Then SETTLEMENTDATE = dr("SETTLEMENTDATE") Else SETTLEMENTDATE = "01/01/2016"
            End If

            If DATECHECK = False Then FROMDATE = SETTLEMENTDATE

            If SETTLEMENTDATE < FROMDATE Then
                tempcmd = New OleDbCommand(" Select IIF(ISNULL(Sum(SETTING_GROSSWT)) = TRUE , 0, Sum(SETTING_GROSSWT)) AS Nettwt FROM SETTING inner join LEDGERMASTER ON SETTING.SETTING_LEDGERID = LEDGERMASTER.LEDGER_ID WHERE LEDGERMASTER.LEDGER_CODE = '" & PARTYNAME & "' AND SETTING.SETTING_DATE < #" & Format(FROMDATE, "MM/dd/yyyy") & "# and SETTING.SETTING_TYPE = 'Jama'", tempconn)
            Else
                tempcmd = New OleDbCommand(" Select IIF(ISNULL(Sum(SETTING_GROSSWT)) = TRUE , 0, Sum(SETTING_GROSSWT)) AS Nettwt FROM SETTING inner join LEDGERMASTER ON SETTING.SETTING_LEDGERID = LEDGERMASTER.LEDGER_ID WHERE LEDGERMASTER.LEDGER_CODE = '" & PARTYNAME & "' AND SETTING.SETTING_DATE <= #" & Format(SETTLEMENTDATE, "MM/dd/yyyy") & "# and SETTING.SETTING_TYPE = 'Jama'", tempconn)
            End If
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            dr = tempcmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                OPJAMA = dr("NETTWT")
            End If


            If SETTLEMENTDATE < FROMDATE Then
                tempcmd = New OleDbCommand(" Select IIF(ISNULL(Sum(SETTING_GROSSWT)) = TRUE , 0, Sum(SETTING_GROSSWT)) AS Nettwt FROM SETTING inner join LEDGERMASTER ON SETTING.SETTING_LEDGERID = LEDGERMASTER.LEDGER_ID WHERE LEDGERMASTER.LEDGER_CODE = '" & PARTYNAME & "' AND SETTING.SETTING_DATE < #" & Format(FROMDATE, "MM/dd/yyyy") & "# and SETTING.SETTING_TYPE = 'Issue'", tempconn)
            Else
                tempcmd = New OleDbCommand(" Select IIF(ISNULL(Sum(SETTING_GROSSWT)) = TRUE , 0, Sum(SETTING_GROSSWT)) AS Nettwt FROM SETTING inner join LEDGERMASTER ON SETTING.SETTING_LEDGERID = LEDGERMASTER.LEDGER_ID WHERE LEDGERMASTER.LEDGER_CODE = '" & PARTYNAME & "' AND SETTING.SETTING_DATE <= #" & Format(SETTLEMENTDATE, "MM/dd/yyyy") & "# and SETTING.SETTING_TYPE = 'Issue'", tempconn)
            End If
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            dr = tempcmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                OPBALANCE = dr("NETTWT")
            End If


            'get PARTYOPENING AMT
            tempcmd = New OleDbCommand(" Select IIF(LEDGER_DRCRRS = 'Cr.' , LEDGER_OPBALRS, 0 ) AS OPBALDR, IIF(LEDGER_DRCRRS = 'Dr.' , LEDGER_OPBALRS, 0 ) AS OPBALCR FROM LEDGERMASTER WHERE LEDGERMASTER.LEDGER_CODE = '" & PARTYNAME & "'", tempconn)
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            dr = tempcmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                OPJAMAAMT = OPJAMAAMT + dr("OPBALDR")
                OPBALANCEAMT = OPBALANCEAMT + dr("OPBALCR")
            End If


            'get PARTYOPENING BALANCE
            tempcmd = New OleDbCommand(" Select IIF(LEDGER_DRCRWT = 'Cr.' , LEDGER_OPBALWT, 0 ) AS OPBALDR, IIF(LEDGER_DRCRWT = 'Dr.' , LEDGER_OPBALWT, 0 ) AS OPBALCR FROM LEDGERMASTER WHERE LEDGERMASTER.LEDGER_CODE = '" & PARTYNAME & "'", tempconn)
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            dr = tempcmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                OPJAMA = OPJAMA + dr("OPBALDR")
                OPBALANCE = OPBALANCE + dr("OPBALCR")
            End If


            'WRITE OP BAL
            If OPJAMA > OPBALANCE Then
                RowIndex = 6
                Write("Opening", Range("1"), XlHAlign.xlHAlignRight, Range("2"), False, 9)
                Write(Format(Val(OPJAMA - OPBALANCE), "0.000"), Range("3"), XlHAlign.xlHAlignRight, , False, 9)
            Else
                RowIndex = 6
                Write("Opening", Range("8"), XlHAlign.xlHAlignRight, Range("9"), False, 9)
                Write(Format(Val(OPBALANCE - OPJAMA), "0.000"), Range("10"), XlHAlign.xlHAlignRight, , False, 9)
            End If

            'NO NEED OF AMOUNT HERE
            'WRITE OPAMT
            'If OPJAMAAMT > OPBALANCEAMT Then
            '    RowIndex = 6
            '    Write("Opening", Range("1"), XlHAlign.xlHAlignRight, Range("7"), False, 9)
            '    Write(Format(Val(OPJAMAAMT - OPBALANCEAMT), "0.000"), Range("9"), XlHAlign.xlHAlignRight, , False, 9)
            'Else
            '    RowIndex = 6
            '    Write("Opening", Range("10"), XlHAlign.xlHAlignRight, Range("16"), False, 9)
            '    Write(Format(Val(OPBALANCEAMT - OPJAMAAMT), "0.000"), Range("18"), XlHAlign.xlHAlignRight, , False, 9)
            'End If
            '************************** END OF OPENING CODE ***************************************



            'JAMA
            Dim dtjama As New System.Data.DataTable
            tempcmd = New OleDbCommand(" SELECT SETTING.SETTING_DATE AS JAMADATE, ItemMaster.item_code AS ITEMCODE, SETTING.SETTING_GROSSWT AS GROSSWT, SETTING.SETTING_STONEWT AS STONEWT, SETTING.SETTING_PURITY AS PURITY, SETTING.SETTING_FINEWT AS FINEWT, SETTING.SETTING_NARR AS NARR FROM (SETTING INNER JOIN ledgermaster ON SETTING.SETTING_LEDGERID = ledgermaster.ledger_id) INNER JOIN ItemMaster ON SETTING.SETTING_ITEMID = ItemMaster.item_id WHERE SETTING.SETTING_TYPE = 'Jama' AND LEDGERMASTER.LEDGER_CODE = '" & PARTYNAME & "' ORDER BY SETTING.SETTING_DATE ", tempconn)
            da = New System.Data.OleDb.OleDbDataAdapter(tempcmd)
            da.Fill(dtjama)
            If dtjama.Rows.Count > 0 Then
                Dim JSTARTROW As Integer = RowIndex
                For Each DRJAMA As System.Data.DataRow In dtjama.Rows
                    RowIndex += 1
                    Write(DRJAMA("JAMADATE"), Range("1"), XlHAlign.xlHAlignCenter, , False, 9)
                    Write(DRJAMA("ITEMCODE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(DRJAMA("GROSSWT"), Range("3"), XlHAlign.xlHAlignRight, , False, 9, True)
                    Write(DRJAMA("STONEWT"), Range("4"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DRJAMA("PURITY"), Range("5"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DRJAMA("FINEWT"), Range("6"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DRJAMA("NARR"), Range("7"), XlHAlign.xlHAlignLeft, , False, 9)
                Next
            End If
            Dim JENDROW As Integer = RowIndex



            'ISSUE
            Dim dtISSUE As New System.Data.DataTable
            tempcmd = New OleDbCommand(" SELECT SETTING.SETTING_DATE AS JAMADATE, ItemMaster.item_code AS ITEMCODE, SETTING.SETTING_GROSSWT AS GROSSWT, SETTING.SETTING_STONEWT AS STONEWT, SETTING.SETTING_PURITY AS PURITY, SETTING.SETTING_FINEWT AS FINEWT, SETTING.SETTING_NARR AS NARR FROM (SETTING INNER JOIN ledgermaster ON SETTING.SETTING_LEDGERID = ledgermaster.ledger_id) INNER JOIN ItemMaster ON SETTING.SETTING_ITEMID = ItemMaster.item_id WHERE SETTING.SETTING_TYPE = 'Issue' AND LEDGERMASTER.LEDGER_CODE = '" & PARTYNAME & "' ORDER BY SETTING.SETTING_DATE ", tempconn)
            da = New System.Data.OleDb.OleDbDataAdapter(tempcmd)
            da.Fill(dtISSUE)
            If dtISSUE.Rows.Count > 0 Then
                RowIndex = 6
                For Each DRISSUE As System.Data.DataRow In dtISSUE.Rows
                    RowIndex += 1
                    Write(DRISSUE("JAMADATE"), Range("8"), XlHAlign.xlHAlignCenter, , False, 9)
                    Write(DRISSUE("ITEMCODE"), Range("9"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(DRISSUE("GROSSWT"), Range("10"), XlHAlign.xlHAlignRight, , False, 9, True)
                    Write(DRISSUE("STONEWT"), Range("11"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DRISSUE("PURITY"), Range("12"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DRISSUE("FINEWT"), Range("13"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DRISSUE("NARR"), Range("14"), XlHAlign.xlHAlignLeft, , False, 9)
                Next
            End If
            If RowIndex < JENDROW Then RowIndex = JENDROW

            SetBorder(RowIndex, objColumn.Item("1").ToString & 6, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 6, objColumn.Item("14").ToString & RowIndex)




            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 10)
            Write("Total :", Range("8"), XlHAlign.xlHAlignRight, Range("9"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("2"))
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, Range("9"))


            objSheet.Range(objColumn.Item("3").ToString & 7, objColumn.Item("3").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("4").ToString & 7, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("5").ToString & 7, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("6").ToString & 7, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("10").ToString & 7, objColumn.Item("10").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("11").ToString & 7, objColumn.Item("11").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("12").ToString & 7, objColumn.Item("12").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("13").ToString & 7, objColumn.Item("13").ToString & RowIndex).NumberFormat = "0.000"
            


            'TO AVOID ERROR IF NO RECORDS
            If RowIndex > 7 Then
                For i As Integer = 3 To 13
                    If i <> 7 And i <> 8 And i <> 9 Then
                        FORMULA("=SUM(" & objColumn.Item(i.ToString).ToString & 6 & ":" & objColumn.Item(i.ToString).ToString & RowIndex - 1 & ")", Range(i.ToString), XlHAlign.xlHAlignRight, , True, 10)
                    End If
                Next
            End If
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, Range("7"))
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, Range("14"))



            RowIndex += 2
            Write("Balance Gross :", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 10)
            FORMULA("=(" & objColumn.Item("3").ToString & RowIndex - 2 & "-" & objColumn.Item("10").ToString & RowIndex - 2 & ")", Range("3"), XlHAlign.xlHAlignRight, Range("4"), True, 9)
            objSheet.Range(objColumn.Item("3").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.000"


            RowIndex += 1
            Write("Balance Stone :", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 10)
            FORMULA("=(" & objColumn.Item("4").ToString & RowIndex - 3 & "-" & objColumn.Item("11").ToString & RowIndex - 3 & ")", Range("3"), XlHAlign.xlHAlignRight, Range("4"), True, 10)
            objSheet.Range(objColumn.Item("3").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.000"


            RowIndex += 1
            Write("Balance Nett :", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 10)
            FORMULA("=(" & objColumn.Item("6").ToString & RowIndex - 4 & "-" & objColumn.Item("13").ToString & RowIndex - 4 & ")", Range("3"), XlHAlign.xlHAlignRight, Range("4"), True, 9)
            objSheet.Range(objColumn.Item("3").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.000"

            objBook.Application.ActiveWindow.Zoom = 100

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .TopMargin = 20
                .LeftMargin = 20
                .RightMargin = 20
                .BottomMargin = 20
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "LAB REPORT"

    Public Function RUNNINGLABREPORT_EXCEL(ByVal DT As System.Data.DataTable, ByVal PERIOD As String) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 10)
            Next
            SetColumnWidth(Range("4"), 20)


            ''''''''''Report Title
            'CMPNAME
            RowIndex = 2
            Write(tempcmpname, Range("1"), XlHAlign.xlHAlignCenter, Range("10"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("10"))

            'PARTY NAME
            RowIndex += 1
            Write("Lab Report", Range("1"), XlHAlign.xlHAlignCenter, Range("10"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("10"))

            'PERIOD
            RowIndex += 1
            Write(PERIOD, Range("1"), XlHAlign.xlHAlignCenter, Range("10"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("10"))


            RowIndex += 1
            Write("Lot No", Range("1"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("Part No", Range("2"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("2"), Range("2"))
            Write("Status", Range("3"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("3"), Range("3"))
            Write("Narration", Range("4"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("4"), Range("4"))
            Write("Gross Wt", Range("5"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("5"), Range("5"))
            Write("Nett Wt", Range("6"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("6"), Range("6"))
            Write("Fact Rep", Range("7"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("7"), Range("7"))
            Write("Lab Rep", Range("8"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("8"), Range("8"))
            Write("Fac/Lab Diff", Range("9"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("9"), Range("9"))
            Write("Actual Diff", Range("10"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("10"), Range("10"))

            objSheet.Range(Range("1"), Range("10")).Interior.Color = RGB(213, 228, 248)

            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 6, objColumn.Item("10").ToString & 6).Select()
            objSheet.Range(objColumn.Item("1").ToString & 6, objColumn.Item("10").ToString & 6).Application.ActiveWindow.FreezePanes = True


            Dim DV As New DataView(DT)
            DV.Sort = "LOTNO ASC, PARTNO ASC, TYPE ASC"
            Dim NEWDT As System.Data.DataTable = DV.ToTable()

            Dim RUNNINGBAL As Double = 0.0
            Dim RECORDNO As Integer = 1
            For Each DTROW As System.Data.DataRow In NEWDT.Rows
                RowIndex += 1

                If Val(DTROW("LABREP")) = 0 Then DTROW("LABREP") = Val(DTROW("MELTING"))
                If RECORDNO = 1 Then
                    RUNNINGBAL = Val(DT.Rows(0).Item("FACLAB"))
                Else
                    RUNNINGBAL = Format(Val(DTROW("FACLAB") - Val(RUNNINGBAL)), "0.00")
                End If
                Write(DTROW("LOTNO"), Range("1"), XlHAlign.xlHAlignRight, , False, 9)
                Write(DTROW("PARTNO"), Range("2"), XlHAlign.xlHAlignLeft, , False, 9)
                Write(DTROW("REFNO"), Range("3"), XlHAlign.xlHAlignLeft, , False, 9)
                Write(DTROW("NARRATION"), Range("4"), XlHAlign.xlHAlignRight, , False, 9)
                Write(Format(Val(DTROW("WT")), "0.000"), Range("5"), XlHAlign.xlHAlignRight, , False, 9)
                Write(Format(Val(DTROW("NETTWT")), "0.000"), Range("6"), XlHAlign.xlHAlignRight, , False, 9)
                Write(Format(Val(DTROW("MELTING")), "0.00"), Range("7"), XlHAlign.xlHAlignRight, , False, 9)
                Write(Format(Val(DTROW("LABREP")), "0.00"), Range("8"), XlHAlign.xlHAlignRight, , False, 9)
                Write(Format(Val(DTROW("FACLAB")), "0.00"), Range("9"), XlHAlign.xlHAlignRight, , False, 9)
                If Val(DTROW("FACLAB")) > 0 Then objSheet.Range(Range("9"), Range("9")).Font.Color = RGB(255, 0, 0) Else objSheet.Range(Range("9"), Range("9")).Font.Color = RGB(0, 176, 80)
                Write(Format(Val(RUNNINGBAL), "0.00"), Range("10"), XlHAlign.xlHAlignRight, , False, 9)
                If Val(RUNNINGBAL) > 0 Then objSheet.Range(Range("10"), Range("10")).Font.Color = RGB(255, 0, 0) Else objSheet.Range(Range("10"), Range("10")).Font.Color = RGB(0, 176, 80)
                RECORDNO += 1
            Next


            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("4"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("4"))
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, Range("5"))
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, Range("6"))
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, Range("8"))
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, Range("9"))
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, Range("10"))

            FORMULA("=SUM(" & objColumn.Item("5").ToString & 6 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & 6 & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("9").ToString & 6 & ":" & objColumn.Item("9").ToString & RowIndex - 1 & ")", Range("9"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("10").ToString & 6 & ":" & objColumn.Item("10").ToString & RowIndex - 1 & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 10)

            objSheet.Range(objColumn.Item("5").ToString & 1, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("6").ToString & 1, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("7").ToString & 1, objColumn.Item("7").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("8").ToString & 1, objColumn.Item("8").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("9").ToString & 1, objColumn.Item("9").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("10").ToString & 1, objColumn.Item("10").ToString & RowIndex).NumberFormat = "0.00"

            objSheet.Range(Range("1"), Range("10")).Interior.Color = RGB(213, 228, 248)

            objBook.Application.ActiveWindow.Zoom = 100

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .TopMargin = 20
                .LeftMargin = 20
                .RightMargin = 20
                .BottomMargin = 20
                .Zoom = False
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "STOCK SUMMARY"

    Public Function STOCK_SUMMARY_EXCEL(ByVal DT As System.Data.DataTable, Optional ByVal CONDITION As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 7
                SetColumnWidth(Range(i), 10)
            Next

            SetColumnWidth("B1", 15)
            SetColumnWidth("C1", 6)


            ''''''''''Report Title
            'CMPNAME
            RowIndex = 2
            Write(tempcmpname, Range("1"), XlHAlign.xlHAlignCenter, Range("7"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("7"))

            'STOCK SUMMARY
            RowIndex += 1
            Write("Stock Summary", Range("1"), XlHAlign.xlHAlignCenter, Range("7"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("7"))


            'RECEIPT/JAMA
            RowIndex += 1
            Write("", Range("1"), XlHAlign.xlHAlignCenter, Range("3"), True, 9)
            Write("Receipt/Jama", Range("4"), XlHAlign.xlHAlignCenter, Range("5"), True, 9)
            SetBorder(RowIndex, Range("4"), Range("5"))
            Write("Issue/Naame", Range("6"), XlHAlign.xlHAlignCenter, Range("7"), True, 9)
            SetBorder(RowIndex, Range("6"), Range("7"))


            'COLUMNS NAME
            RowIndex += 1
            Write("Date", Range("1"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Name", Range("2"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Purity", Range("3"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Gross Wt.", Range("4"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Nett Wt.", Range("5"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Gross Wt.", Range("6"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Nett Wt.", Range("7"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("1"), Range("7"))


            'FREEZE TOP 6 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 6, objColumn.Item("7").ToString & 6).Select()
            objSheet.Range(objColumn.Item("1").ToString & 6, objColumn.Item("7").ToString & 6).Application.ActiveWindow.FreezePanes = True


            'JAMA
            If DT.Rows.Count > 0 Then
                For Each DTROW As System.Data.DataRow In DT.Rows
                    RowIndex += 1
                    Write(DTROW("DATE"), Range("1"), XlHAlign.xlHAlignCenter, , False, 9)
                    Write(DTROW("NAME"), Range("2"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(DTROW("PURITY"), Range("3"), XlHAlign.xlHAlignRight, , False, 9, True)
                    Write(DTROW("RECGROSS"), Range("4"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("RECNETT"), Range("5"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("ISSGROSS"), Range("6"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("ISSNETT"), Range("7"), XlHAlign.xlHAlignRight, , False, 9)
                Next
            End If


            SetBorder(RowIndex, objColumn.Item("1").ToString & 6, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 6, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 6, objColumn.Item("7").ToString & RowIndex)


            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("3"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("3"))
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, Range("5"))
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, Range("7"))


            FORMULA("=SUM(" & objColumn.Item("4").ToString & 6 & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 6 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & 6 & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 6 & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            objSheet.Range(objColumn.Item("4").ToString & 1, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("5").ToString & 1, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("6").ToString & 1, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("7").ToString & 1, objColumn.Item("7").ToString & RowIndex).NumberFormat = "0.000"

            RowIndex += 2
            Write("Balance Gross :", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 10)
            FORMULA("=(" & objColumn.Item("4").ToString & RowIndex - 2 & "-" & objColumn.Item("6").ToString & RowIndex - 2 & ")", Range("3"), XlHAlign.xlHAlignRight, Range("4"), True, 10)
            objSheet.Range(objColumn.Item("3").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.000"


            RowIndex += 1
            Write("Balance Nett :", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 10)
            FORMULA("=(" & objColumn.Item("5").ToString & RowIndex - 3 & "-" & objColumn.Item("7").ToString & RowIndex - 3 & ")", Range("3"), XlHAlign.xlHAlignRight, Range("4"), True, 10)
            objSheet.Range(objColumn.Item("3").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.000"



            objBook.Application.ActiveWindow.Zoom = 100

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .TopMargin = 20
                .LeftMargin = 20
                .RightMargin = 20
                .BottomMargin = 20
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "STOCK WITH TB"

    Public Function STOCKTB_EXCEL() As Object

        SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 7
                SetColumnWidth(Range(i), 10)
            Next

            SetColumnWidth(Range("1"), 30)


            ''''''''''Report Title
            'CMPNAME
            RowIndex = 2
            Write(tempcmpname, Range("1"), XlHAlign.xlHAlignCenter, Range("4"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("4"))

            'STOCK SUMMARY
            RowIndex += 1
            Write("Stock with Trial Balance", Range("1"), XlHAlign.xlHAlignCenter, Range("4"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("4"))


            RowIndex += 1
            Write("Item Name", Range("1"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Purity", Range("2"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Gross Wt", Range("3"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Fine Wt", Range("4"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("1"), Range("4"))


            'FREEZE TOP 4 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 5, objColumn.Item("4").ToString & 5).Select()
            objSheet.Range(objColumn.Item("1").ToString & 5, objColumn.Item("4").ToString & 5).Application.ActiveWindow.FreezePanes = True



            'STOCK ON HAND
            Dim DT As New System.Data.DataTable
            tempcmd = New OleDbCommand("SELECT STOCKS.ITEM_CODE AS ITEMCODE, STOCKS.NARRATION, STOCKS.ITEM_PURITY AS PURITY, ROUND(Sum(STOCKS.ITEM_GROSSWT),3) AS GROSSWT, ROUND(Sum(STOCKS.ITEM_NETTWT),3) AS NETTWT  FROM Stocks GROUP BY STOCKS.ITEM_CODE, STOCKS.NARRATION, STOCKS.ITEM_PURITY HAVING(ROUND(Sum(STOCKS.ITEM_GROSSWT),2) <> 0 Or ROUND(Sum(STOCKS.ITEM_NETTWT),2)) ORDER BY STOCKS.ITEM_CODE", tempconn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(DT)
            If DT.Rows.Count > 0 Then
                For Each DTROW As System.Data.DataRow In DT.Rows
                    RowIndex += 1
                    Write(DTROW("ITEMCODE"), Range("1"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(DTROW("PURITY"), Range("2"), XlHAlign.xlHAlignRight, , False, 9, True)
                    Write(DTROW("GROSSWT"), Range("3"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("NETTWT"), Range("4"), XlHAlign.xlHAlignRight, , False, 9)
                Next
            End If


            'GET DISINTCT WASTAGELEDGERS AND FILL IN WASTGEGRID
            Dim WHERECLAUSE As String = ""
            Dim GROUPBYCLAUSE As String = ""
            Dim WASTAGEDT As New System.Data.DataTable
            Dim LEDGERDT As New System.Data.DataTable
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            tempcmd = New OleDbCommand("SELECT DISTINCT LEDGER_NAME AS LEDGERNAME FROM MFGWASTAGE", tempconn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(LEDGERDT)
            WHERECLAUSE = ""
            If LEDGERDT.Rows.Count > 0 Then
                For Each DTROW As DataRow In LEDGERDT.Rows
                    If WHERECLAUSE = "" Then
                        WHERECLAUSE = " AND LEDGERNAME IN ('" & DTROW("LEDGERNAME") & "'"
                    Else
                        WHERECLAUSE += ",'" & DTROW("LEDGERNAME") & "'"
                    End If
                Next
                If WHERECLAUSE <> "" Then WHERECLAUSE += ")"

                GROUPBYCLAUSE = ""
                If USERDEPARTMENT <> "" Then WHERECLAUSE = WHERECLAUSE & " And WASTAGEREPORT.DEPARTMENT = '" & USERDEPARTMENT & "'"
                If USERDEPARTMENT <> "" Then GROUPBYCLAUSE = GROUPBYCLAUSE & ", WASTAGEREPORT.DEPARTMENT "

                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempcmd = New OleDbCommand(" SELECT ROUND(SUM(CDBL(VAL(WASTAGE))) - SUM(CDBL(VAL(JAMAGROSSWT))),3) AS GROSSWT, ROUND(SUM(CDBL(VAL(NETTWT))) - SUM(CDBL(VAL(JAMANETTWT))),3) AS NETTWT, LEDGERNAME AS WASTAGE FROM WASTAGEREPORT WHERE 1 = 1 " & WHERECLAUSE & " GROUP BY LEDGERNAME " & GROUPBYCLAUSE, tempconn)
                da = New OleDbDataAdapter(tempcmd)
                da.Fill(WASTAGEDT)
                If WASTAGEDT.Rows.Count > 0 Then
                    For Each DTROW As System.Data.DataRow In WASTAGEDT.Rows
                        RowIndex += 1
                        Write("WASTAGE A/C", Range("1"), XlHAlign.xlHAlignLeft, , False, 9)
                        Write(Format((Val(DTROW("NETTWT")) / Val(DTROW("GROSSWT"))) * 100, "0.000"), Range("2"), XlHAlign.xlHAlignRight, , False, 9, True)
                        Write(DTROW("GROSSWT"), Range("3"), XlHAlign.xlHAlignRight, , False, 9)
                        Write(DTROW("NETTWT"), Range("4"), XlHAlign.xlHAlignRight, , False, 9)
                    Next
                End If

                da.Dispose()
                tempcmd.Dispose()
            End If



        Dim VACCUMDT As New System.Data.DataTable
        Dim VACCUMWT As Double = 0.00
        Dim VACCUMNETTWT As Double = 0.00
        If tempconn.State = ConnectionState.Open Then tempconn.Close()
        tempconn.Open()
        tempcmd = New OleDbCommand(" SELECT ROUND(SUM(ACCOUNTMASTER.ACCOUNT_GROSSWT),3) AS VACCUMWT, 'VACCUM AC' AS NAME FROM (ACCOUNTMASTER INNER JOIN ledgermaster ON ACCOUNTMASTER.account_ledgercode = ledgermaster.ledger_code) INNER JOIN mfgWastage ON ledgermaster.ledger_name = mfgWastage.ledger_name WHERE (((mfgWastage.mfg_vaccum)=True) AND ((ACCOUNTMASTER.ACCOUNT_TYPE)='A') AND ((ACCOUNTMASTER.ACCOUNT_BALORJAMAORPAID)='Balance')) AND (LEDGERMASTER.LEDGER_CODE = 'VACCUM AC') UNION ALL SELECT ROUND(SUM(ACCOUNTMASTER.account_grosswt)*(-1),3) AS VACCUMWT, 'VACCUM AC' AS NAME FROM ACCOUNTMASTER INNER JOIN ledgermaster ON ACCOUNTMASTER.account_ledgercode = ledgermaster.ledger_code WHERE (((ACCOUNTMASTER.ACCOUNT_TYPE)='A') AND ((ACCOUNTMASTER.ACCOUNT_BALORJAMAORPAID)='Jama') AND ((ACCOUNTMASTER.account_ledgercode) = 'VACCUM AC')) UNION ALL SELECT ROUND(SUM(ACCOUNTMASTER.ACCOUNT_GROSSWT),3) AS VACCUMWT, 'VACCUM AC' AS NAME FROM (ACCOUNTMASTER INNER JOIN ledgermaster ON ACCOUNTMASTER.account_ledgercode = ledgermaster.ledger_code) WHERE (((ACCOUNTMASTER.ACCOUNT_TYPE)='A') AND ((ACCOUNTMASTER.ACCOUNT_BALORJAMAORPAID)='Balance')) AND (LEDGERMASTER.LEDGER_CODE = 'VACCUM AC') UNION ALL SELECT ROUND(SUM(mfg_vaccum),3), 'VACCUM AC' AS NAME FROM mfgWastage where mfg_vaccum = True ", tempconn)
        da = New OleDbDataAdapter(tempcmd)
        On Error Resume Next
        da.Fill(VACCUMDT)
        If VACCUMDT.Rows.Count > 0 Then
            For Each VACDR As DataRow In VACCUMDT.Rows
                If Not IsDBNull(VACDR("VACCUMWT")) Then VACCUMWT += Val(VACDR("VACCUMWT"))
            Next
        End If


        Dim VACCUMDT1 As New System.Data.DataTable
        tempcmd = New OleDbCommand(" SELECT ROUND(SUM(CDBL(VAL(NETTWT))) - SUM(CDBL(VAL(JAMANETTWT))),3) AS VACNETTWT, 'VACCUM AC' AS VACNAME FROM VACCUMREPORT ", tempconn)
        da = New OleDbDataAdapter(tempcmd)
        On Error Resume Next
        da.Fill(VACCUMDT1)
        If VACCUMDT1.Rows.Count > 0 Then
            For Each VACDR As DataRow In VACCUMDT1.Rows
                If Not IsDBNull(VACDR("VACNETTWT")) Then VACCUMNETTWT += Val(VACDR("VACNETTWT"))
            Next
        End If

        RowIndex += 1
        Write("VACCUM A/C", Range("1"), XlHAlign.xlHAlignLeft, , False, 9)
        Write(Format((Val(VACCUMNETTWT) / Val(VACCUMWT)) * 100, "0.00"), Range("2"), XlHAlign.xlHAlignRight, , False, 9, True)
        Write(VACCUMWT, Range("3"), XlHAlign.xlHAlignRight, , False, 9)
        Write(VACCUMNETTWT, Range("4"), XlHAlign.xlHAlignRight, , False, 9)
        da.Dispose()
        tempcmd.Dispose()



        RowIndex += 1
        Write("Total", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 9)
        FORMULA("=SUM(" & objColumn.Item("3").ToString & 5 & ":" & objColumn.Item("3").ToString & RowIndex - 1 & ")", Range("3"), XlHAlign.xlHAlignRight, , True, 10)
        FORMULA("=SUM(" & objColumn.Item("4").ToString & 5 & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 10)
        SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("4"))


        SetBorder(RowIndex, objColumn.Item("1").ToString & 5, objColumn.Item("1").ToString & RowIndex)
        SetBorder(RowIndex, objColumn.Item("2").ToString & 5, objColumn.Item("2").ToString & RowIndex)
        SetBorder(RowIndex, objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex)
        SetBorder(RowIndex, objColumn.Item("4").ToString & 5, objColumn.Item("4").ToString & RowIndex)




        'NOW ADD TRIALBALANCE
        RowIndex += 3
            Write("Trial Balance", Range("1"), XlHAlign.xlHAlignCenter, Range("4"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("4"))


            RowIndex += 1
            Dim STARTROW As Integer = RowIndex
            Write("Party Name", Range("1"), XlHAlign.xlHAlignCenter, Range("2"), True, 9)
            Write("Debit", Range("3"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Credit", Range("4"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("1"), Range("4"))


            DT.Clear()
            'TRIALBALANCE
            Dim TOTALOPBALDR, TOTALOPBALCR, TOTALDR, TOTALCR, TOTALCLODR, TOTALCLOCR, CLODR, CLOCR As Double
            cmd = New OleDbCommand("SELECT T.NAME, ROUND(SUM(TDR),3) AS DR, ROUND(SUM(TCR),3) AS CR FROM (SELECT ACCOUNT_LEDGERCODE AS NAME, ROUND(SUM(ACCOUNT_NETTWT),3) AS TDR, 0 AS TCR FROM ACCOUNTMAST WHERE ACCOUNT_BALORJAMAORPAID= 'Jama' GROUP BY ACCOUNT_LEDGERCODE UNION ALL SELECT ACCOUNT_LEDGERCODE AS NAME, 0 AS TDR, SUM(ACCOUNT_NETTWT) AS TCR FROM ACCOUNTMAST WHERE ACCOUNT_BALORJAMAORPAID = 'Balance' GROUP BY ACCOUNT_LEDGERCODE) AS T WHERE NAME <> '' GROUP BY T.NAME", conn)
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            da = New OleDbDataAdapter(cmd)
            da.Fill(DT)
            For Each DTROW As System.Data.DataRow In DT.Rows

                Dim DTOPBAL As New System.Data.DataTable
                tempcmd = New OleDbCommand("SELECT IIF(LEDGER_DRCRWT = 'Cr.', LEDGER_OPBALWT,0) AS OPBALDR, IIF(LEDGER_DRCRWT = 'Dr.', LEDGER_OPBALWT,0) AS OPBALCR FROM LEDGERMASTER WHERE LEDGER_CODE = '" & DTROW("NAME") & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                da = New OleDbDataAdapter(tempcmd)
                da.Fill(DTOPBAL)

                If (Val(DTROW("DR")) + Val(DTOPBAL.Rows(0).Item("OPBALDR"))) - (Val(DTROW("CR")) + Val(DTOPBAL.Rows(0).Item("OPBALCR"))) > 0 Then
                    CLODR = (Val(DTROW("DR")) + Val(DTOPBAL.Rows(0).Item("OPBALDR"))) - (Val(DTROW("CR")) + Val(DTOPBAL.Rows(0).Item("OPBALCR")))
                    CLOCR = 0
                Else
                    CLODR = 0
                    CLOCR = (Val(DTROW("CR")) + Val(DTOPBAL.Rows(0).Item("OPBALCR"))) - (Val(DTROW("DR")) + Val(DTOPBAL.Rows(0).Item("OPBALDR")))
                End If

                RowIndex += 1
                Write(DTROW("NAME"), Range("1"), XlHAlign.xlHAlignLeft, Range("2"), False, 9)
                Write(Val(CLODR), Range("3"), XlHAlign.xlHAlignRight, Range("3"), False, 9)
                Write(Val(CLOCR), Range("4"), XlHAlign.xlHAlignRight, Range("4"), False, 9)

                TOTALOPBALDR += Val(DTOPBAL.Rows(0).Item("OPBALDR"))
                TOTALOPBALCR += Val(DTOPBAL.Rows(0).Item("OPBALCR"))

                TOTALDR += Val(DTROW("DR"))
                TOTALCR += Val(DTROW("CR"))

                TOTALCLODR += Val(CLODR)
                TOTALCLOCR += Val(CLOCR)
            Next

            RowIndex += 1
            Write("Total", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 9)
            FORMULA("=SUM(" & objColumn.Item("3").ToString & STARTROW + 1 & ":" & objColumn.Item("3").ToString & RowIndex - 1 & ")", Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("4").ToString & STARTROW + 1 & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("4"))


            SetBorder(RowIndex, objColumn.Item("1").ToString & STARTROW, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & STARTROW, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & STARTROW, objColumn.Item("4").ToString & RowIndex)

            RowIndex += 2
            Write("Note :", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            RowIndex += 1
            Write("Trial Balance is in Fine Wt", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            RowIndex += 1
            Write("While Considering Total Stock, please consider Credit Column of Trial Balance", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)


            objBook.Application.ActiveWindow.Zoom = 100

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .TopMargin = 20
                .LeftMargin = 20
                .RightMargin = 20
                .BottomMargin = 20
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            SaveAndClose()

        Return Nothing
    End Function

#End Region

#Region "VACCUM REPORT"

    Public Function VACCUM_REPORT_EXCEL(ByVal DT As System.Data.DataTable, ByVal PERIOD As String) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 10)
            Next



            ''''''''''Report Title
            'CMPNAME
            RowIndex = 2
            Write(tempcmpname, Range("1"), XlHAlign.xlHAlignCenter, Range("14"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("14"))

            'VACCUM REPORT
            RowIndex += 1
            Write("Vaccum Report    " & PERIOD, Range("1"), XlHAlign.xlHAlignCenter, Range("14"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("14"))


            'RECEIPT/JAMA
            RowIndex += 1
            Write("Receipt/Jama", Range("1"), XlHAlign.xlHAlignCenter, Range("5"), True, 9)
            SetBorder(RowIndex, Range("1"), Range("5"))
            Write("Issue/Naame", Range("6"), XlHAlign.xlHAlignCenter, Range("14"), True, 9)
            SetBorder(RowIndex, Range("6"), Range("14"))


            'COLUMNS NAME
            RowIndex += 1
            Write("Date", Range("1"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Item", Range("2"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Pur.", Range("3"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Gross Wt.", Range("4"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Nett Wt.", Range("5"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Date", Range("6"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Melting", Range("7"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Lot No", Range("8"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("In Wt.", Range("9"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Out Wt.", Range("10"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Vaccum Wt.", Range("11"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Pur.", Range("12"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Fine", Range("13"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Part No", Range("14"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("1"), Range("5"))
            SetBorder(RowIndex, Range("6"), Range("14"))


            'FREEZE TOP 6 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 6, objColumn.Item("14").ToString & 6).Select()
            objSheet.Range(objColumn.Item("1").ToString & 6, objColumn.Item("14").ToString & 6).Application.ActiveWindow.FreezePanes = True


            'JAMA
            If DT.Rows.Count > 0 Then
                For Each DTROW As System.Data.DataRow In DT.Rows
                    RowIndex += 1

                    If DTROW("ITEMCODE") <> "" Then
                        Write(DTROW("DATE"), Range("1"), XlHAlign.xlHAlignCenter, , False, 9)
                        Write("", Range("6"), XlHAlign.xlHAlignCenter, , False, 9)
                    Else
                        Write("", Range("1"), XlHAlign.xlHAlignCenter, , False, 9)
                        Write(DTROW("DATE"), Range("6"), XlHAlign.xlHAlignCenter, , False, 9)
                    End If

                    Write(DTROW("ITEMCODE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(DTROW("JAMAPURITY"), Range("3"), XlHAlign.xlHAlignRight, , False, 9, True)
                    Write(DTROW("JAMAGROSSWT"), Range("4"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("JAMANETTWT"), Range("5"), XlHAlign.xlHAlignRight, , False, 9)


                    Write(DTROW("MELTING"), Range("7"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("LOTNO"), Range("8"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("INWT"), Range("9"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("OUTWT"), Range("10"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("VACCUMWT"), Range("11"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("VACCUMPURITY"), Range("12"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("NETTWT"), Range("13"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("PARTNO"), Range("14"), XlHAlign.xlHAlignLeft, , False, 9)

                Next
            End If


            SetBorder(RowIndex, objColumn.Item("1").ToString & 6, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 6, objColumn.Item("14").ToString & RowIndex)


            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("3"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("14"))
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("3"))
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, Range("4"))
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, Range("5"))
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, Range("9"))
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, Range("10"))
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, Range("11"))
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, Range("12"))
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, Range("13"))
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, Range("14"))


            FORMULA("=SUM(" & objColumn.Item("4").ToString & 6 & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 6 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("9").ToString & 6 & ":" & objColumn.Item("9").ToString & RowIndex - 1 & ")", Range("9"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("10").ToString & 6 & ":" & objColumn.Item("10").ToString & RowIndex - 1 & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("11").ToString & 6 & ":" & objColumn.Item("11").ToString & RowIndex - 1 & ")", Range("11"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("13").ToString & 6 & ":" & objColumn.Item("13").ToString & RowIndex - 1 & ")", Range("13"), XlHAlign.xlHAlignRight, , True, 10)
            objSheet.Range(objColumn.Item("4").ToString & 1, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("5").ToString & 1, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("7").ToString & 1, objColumn.Item("7").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("9").ToString & 1, objColumn.Item("9").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("10").ToString & 1, objColumn.Item("10").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("11").ToString & 1, objColumn.Item("11").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("12").ToString & 1, objColumn.Item("12").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("13").ToString & 1, objColumn.Item("13").ToString & RowIndex).NumberFormat = "0.000"


            RowIndex += 2
            Write("Balance Gross :", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 10)
            FORMULA("=(" & objColumn.Item("4").ToString & RowIndex - 2 & "-" & objColumn.Item("11").ToString & RowIndex - 2 & ")", Range("3"), XlHAlign.xlHAlignRight, Range("4"), True, 10)
            objSheet.Range(objColumn.Item("3").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.000"


            RowIndex += 1
            Write("Balance Nett :", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 10)
            FORMULA("=(" & objColumn.Item("5").ToString & RowIndex - 3 & "-" & objColumn.Item("13").ToString & RowIndex - 3 & ")", Range("3"), XlHAlign.xlHAlignRight, Range("4"), True, 10)
            objSheet.Range(objColumn.Item("3").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.000"

            RowIndex += 1
            Write("Avg Vaccum Report:", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 10)
            'OLD FORMULA
            'FORMULA("=(" & objColumn.Item("13").ToString & RowIndex - 4 & "/" & objColumn.Item("11").ToString & RowIndex - 4 & ")*100", Range("3"), XlHAlign.xlHAlignRight, Range("4"), True, 10)
            FORMULA("=(" & objColumn.Item("3").ToString & RowIndex - 1 & "/" & objColumn.Item("3").ToString & RowIndex - 2 & ")*100", Range("3"), XlHAlign.xlHAlignRight, Range("4"), True, 10)
            objSheet.Range(objColumn.Item("3").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.00"



            objBook.Application.ActiveWindow.Zoom = 100

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .TopMargin = 20
                .LeftMargin = 20
                .RightMargin = 20
                .BottomMargin = 20
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "SAMPLE REPORT"

    Public Function SAMPLE_REPORT_EXCEL(ByVal DT As System.Data.DataTable, ByVal PERIOD As String) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 20
                SetColumnWidth(Range(i), 10)
            Next
            SetColumnWidth(Range("14"), 15)

            If item = False Then SetColumnWidth(Range("2"), 0)
            If recpur = False Then SetColumnWidth(Range("3"), 0)
            If grosswt = False Then SetColumnWidth(Range("4"), 0)
            If nettwt = False Then SetColumnWidth(Range("5"), 0)
            If lotno = False Then SetColumnWidth(Range("7"), 0)
            If inwt = False Then SetColumnWidth(Range("8"), 0)
            If outwt = False Then SetColumnWidth(Range("9"), 0)
            If smplwt = False Then SetColumnWidth(Range("10"), 0)
            If issupur = False Then SetColumnWidth(Range("11"), 0)
            If fine = False Then SetColumnWidth(Range("12"), 0)
            If partno = False Then SetColumnWidth(Range("13"), 0)
            If process = False Then SetColumnWidth(Range("14"), 0)

            ''''''''''Report Title
            'CMPNAME
            RowIndex = 2
            Write(tempcmpname, Range("1"), XlHAlign.xlHAlignCenter, Range("14"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("14"))

            'WASTAGE REPORT
            RowIndex += 1
            Write("Sample Report " & PERIOD, Range("1"), XlHAlign.xlHAlignCenter, Range("13"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("14"))


            'RECEIPT/JAMA
            RowIndex += 1
            Write("Receipt/Jama", Range("1"), XlHAlign.xlHAlignCenter, Range("5"), True, 9)
            SetBorder(RowIndex, Range("1"), Range("5"))
            Write("Issue/Naame", Range("6"), XlHAlign.xlHAlignCenter, Range("14"), True, 9)
            SetBorder(RowIndex, Range("6"), Range("14"))


            'COLUMNS NAME
            RowIndex += 1
            Write("Date", Range("1"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Item", Range("2"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Pur.", Range("3"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Gross Wt.", Range("4"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Nett Wt.", Range("5"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Date", Range("6"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Lot No", Range("7"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("In Wt.", Range("8"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Out Wt.", Range("9"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Smp Wt.", Range("10"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Pur.", Range("11"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Fine", Range("12"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Part No", Range("13"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Process Name", Range("14"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("1"), Range("5"))
            SetBorder(RowIndex, Range("6"), Range("14"))


            'FREEZE TOP 6 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 6, objColumn.Item("14").ToString & 6).Select()
            objSheet.Range(objColumn.Item("1").ToString & 6, objColumn.Item("14").ToString & 6).Application.ActiveWindow.FreezePanes = True


            'JAMA
            If DT.Rows.Count > 0 Then
                For Each DTROW As System.Data.DataRow In DT.Rows
                    RowIndex += 1

                    If DTROW("ITEMCODE") <> "" And Val(DTROW("INWT")) = 0 Then
                        Write(DTROW("DATE"), Range("1"), XlHAlign.xlHAlignCenter, , False, 9)
                        Write("", Range("6"), XlHAlign.xlHAlignCenter, , False, 9)
                        Write(DTROW("ITEMCODE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 9)
                    Else
                        Write("", Range("1"), XlHAlign.xlHAlignCenter, , False, 9)
                        Write(DTROW("DATE"), Range("6"), XlHAlign.xlHAlignCenter, , False, 9)
                    End If

                    Write(DTROW("JAMAPURITY"), Range("3"), XlHAlign.xlHAlignRight, , False, 9, True)
                    Write(DTROW("JAMAGROSSWT"), Range("4"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("JAMANETTWT"), Range("5"), XlHAlign.xlHAlignRight, , False, 9)

                    If DTROW("ITEMCODE") <> "" And Val(DTROW("INWT")) > 0 Then
                        Write(DTROW("ITEMCODE"), Range("7"), XlHAlign.xlHAlignRight, , False, 9)
                    Else
                        Write(DTROW("LOTNO"), Range("7"), XlHAlign.xlHAlignRight, , False, 9)
                    End If
                    Write(DTROW("INWT"), Range("8"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("OUTWT"), Range("9"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("SAMPLE"), Range("10"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("SAMPLEPURITY"), Range("11"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("NETTWT"), Range("12"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("PARTNO"), Range("13"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(DTROW("PROCESSNAME"), Range("14"), XlHAlign.xlHAlignLeft, , False, 9)

                Next
            End If


            SetBorder(RowIndex, objColumn.Item("1").ToString & 6, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 6, objColumn.Item("14").ToString & RowIndex)


            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("3"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("13"))
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("3"))
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, Range("4"))
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, Range("5"))
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, Range("8"))
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, Range("9"))
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, Range("10"))
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, Range("11"))
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, Range("12"))
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, Range("13"))
            SetBorder(RowIndex, objColumn.Item("14").ToString & RowIndex, Range("14"))


            FORMULA("=SUM(" & objColumn.Item("4").ToString & 6 & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 6 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)

            If inwt = True Then FORMULA("=SUM(" & objColumn.Item("8").ToString & 6 & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 10)
            If outwt = True Then FORMULA("=SUM(" & objColumn.Item("9").ToString & 6 & ":" & objColumn.Item("9").ToString & RowIndex - 1 & ")", Range("9"), XlHAlign.xlHAlignRight, , True, 10)

            FORMULA("=SUM(" & objColumn.Item("10").ToString & 6 & ":" & objColumn.Item("10").ToString & RowIndex - 1 & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("12").ToString & 6 & ":" & objColumn.Item("12").ToString & RowIndex - 1 & ")", Range("12"), XlHAlign.xlHAlignRight, , True, 10)
            objSheet.Range(objColumn.Item("4").ToString & 1, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("5").ToString & 1, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("8").ToString & 1, objColumn.Item("8").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("9").ToString & 1, objColumn.Item("9").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("10").ToString & 1, objColumn.Item("10").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("11").ToString & 1, objColumn.Item("11").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("12").ToString & 1, objColumn.Item("12").ToString & RowIndex).NumberFormat = "0.000"


            RowIndex += 2
            Write("Balance Gross :", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 10)
            FORMULA("=(" & objColumn.Item("4").ToString & RowIndex - 2 & "-" & objColumn.Item("10").ToString & RowIndex - 2 & ")", Range("3"), XlHAlign.xlHAlignRight, Range("4"), True, 10)
            objSheet.Range(objColumn.Item("3").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.000"


            RowIndex += 1
            Write("Balance Nett :", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 10)
            FORMULA("=(" & objColumn.Item("5").ToString & RowIndex - 3 & "-" & objColumn.Item("12").ToString & RowIndex - 3 & ")", Range("3"), XlHAlign.xlHAlignRight, Range("4"), True, 10)
            objSheet.Range(objColumn.Item("3").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.000"


            RowIndex += 1
            Write("Avg Sample Report:", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 10)
            FORMULA("=(" & objColumn.Item("12").ToString & RowIndex - 4 & "/" & objColumn.Item("10").ToString & RowIndex - 4 & ")*100", Range("3"), XlHAlign.xlHAlignRight, Range("4"), True, 10)
            objSheet.Range(objColumn.Item("3").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.00"



            objBook.Application.ActiveWindow.Zoom = 100

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .TopMargin = 20
                .LeftMargin = 20
                .RightMargin = 20
                .BottomMargin = 20
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "WASTAGE REPORT"

    Public Function WASTAGE_REPORT_EXCEL(ByVal DT As System.Data.DataTable, Optional ByVal HEADER As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 15
                SetColumnWidth(Range(i), 10)
            Next
            SetColumnWidth(Range(9), 15)


            ''''''''''Report Title
            'CMPNAME
            RowIndex = 2
            Write(tempcmpname, Range("1"), XlHAlign.xlHAlignCenter, Range("15"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("15"))

            'WASTAGE REPORT
            RowIndex += 1
            Write("Wastage Report " & HEADER, Range("1"), XlHAlign.xlHAlignCenter, Range("15"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("15"))


            'RECEIPT/JAMA
            RowIndex += 1
            Write("Receipt/Jama", Range("1"), XlHAlign.xlHAlignCenter, Range("5"), True, 9)
            SetBorder(RowIndex, Range("1"), Range("5"))
            Write("Issue/Naame", Range("6"), XlHAlign.xlHAlignCenter, Range("15"), True, 9)
            SetBorder(RowIndex, Range("6"), Range("15"))


            'COLUMNS NAME
            RowIndex += 1
            Write("Date", Range("1"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Item", Range("2"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Pur.", Range("3"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Gross Wt.", Range("4"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Nett Wt.", Range("5"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Date", Range("6"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Lot No", Range("7"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Req Melting", Range("8"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Process", Range("9"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("In Wt.", Range("10"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Out Wt.", Range("11"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Was Wt.", Range("12"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Pur.", Range("13"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Fine", Range("14"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Part No", Range("15"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("1"), Range("5"))
            SetBorder(RowIndex, Range("6"), Range("15"))


            'FREEZE TOP 6 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 6, objColumn.Item("15").ToString & 6).Select()
            objSheet.Range(objColumn.Item("1").ToString & 6, objColumn.Item("15").ToString & 6).Application.ActiveWindow.FreezePanes = True


            'JAMA
            If DT.Rows.Count > 0 Then
                For Each DTROW As System.Data.DataRow In DT.Rows
                    RowIndex += 1

                    If DTROW("ITEMCODE") <> "" Then
                        Write(DTROW("DATE"), Range("1"), XlHAlign.xlHAlignCenter, , False, 9)
                        Write("", Range("6"), XlHAlign.xlHAlignCenter, , False, 9)
                    Else
                        Write("", Range("1"), XlHAlign.xlHAlignCenter, , False, 9)
                        Write(DTROW("DATE"), Range("6"), XlHAlign.xlHAlignCenter, , False, 9)
                    End If

                    Write(DTROW("ITEMCODE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(DTROW("JAMAPURITY"), Range("3"), XlHAlign.xlHAlignRight, , False, 9, True)
                    Write(DTROW("JAMAGROSSWT"), Range("4"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("JAMANETTWT"), Range("5"), XlHAlign.xlHAlignRight, , False, 9)


                    Write(DTROW("LOTNO"), Range("7"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("REQMELTING"), Range("8"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("PROCESSNAME"), Range("9"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(DTROW("INWT"), Range("10"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("OUTWT"), Range("11"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("WASTAGE"), Range("12"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("WASTAGEPURITY"), Range("13"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("NETTWT"), Range("14"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("PARTNO"), Range("15"), XlHAlign.xlHAlignLeft, , False, 9)

                Next
            End If


            SetBorder(RowIndex, objColumn.Item("1").ToString & 6, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 6, objColumn.Item("15").ToString & RowIndex)


            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("3"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("15"))
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("3"))
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, Range("4"))
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, Range("5"))
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, Range("10"))
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, Range("11"))
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, Range("12"))
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, Range("13"))
            SetBorder(RowIndex, objColumn.Item("14").ToString & RowIndex, Range("14"))
            SetBorder(RowIndex, objColumn.Item("15").ToString & RowIndex, Range("15"))


            FORMULA("=SUM(" & objColumn.Item("4").ToString & 6 & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 6 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("10").ToString & 6 & ":" & objColumn.Item("10").ToString & RowIndex - 1 & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("11").ToString & 6 & ":" & objColumn.Item("11").ToString & RowIndex - 1 & ")", Range("11"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("12").ToString & 6 & ":" & objColumn.Item("12").ToString & RowIndex - 1 & ")", Range("12"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("14").ToString & 6 & ":" & objColumn.Item("14").ToString & RowIndex - 1 & ")", Range("14"), XlHAlign.xlHAlignRight, , True, 10)
            objSheet.Range(objColumn.Item("4").ToString & 1, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("5").ToString & 1, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("8").ToString & 1, objColumn.Item("8").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("10").ToString & 1, objColumn.Item("10").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("11").ToString & 1, objColumn.Item("11").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("12").ToString & 1, objColumn.Item("12").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("13").ToString & 1, objColumn.Item("13").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("14").ToString & 1, objColumn.Item("14").ToString & RowIndex).NumberFormat = "0.000"


            RowIndex += 2
            Write("Balance Gross :", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 10)
            FORMULA("=(" & objColumn.Item("4").ToString & RowIndex - 2 & "-" & objColumn.Item("12").ToString & RowIndex - 2 & ")", Range("3"), XlHAlign.xlHAlignRight, Range("4"), True, 10)
            objSheet.Range(objColumn.Item("3").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.000"


            RowIndex += 1
            Write("Balance Nett :", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 10)
            FORMULA("=(" & objColumn.Item("5").ToString & RowIndex - 3 & "-" & objColumn.Item("14").ToString & RowIndex - 3 & ")", Range("3"), XlHAlign.xlHAlignRight, Range("4"), True, 10)
            objSheet.Range(objColumn.Item("3").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.000"


            RowIndex += 1
            Write("Avg Wastage Report:", Range("1"), XlHAlign.xlHAlignRight, Range("2"), True, 10)
            'OLD FORMULA
            'FORMULA("=(" & objColumn.Item("14").ToString & RowIndex - 4 & "/" & objColumn.Item("12").ToString & RowIndex - 4 & ")*100", Range("3"), XlHAlign.xlHAlignRight, Range("4"), True, 10)
            FORMULA("=(" & objColumn.Item("3").ToString & RowIndex - 1 & "/" & objColumn.Item("3").ToString & RowIndex - 2 & ")*100", Range("3"), XlHAlign.xlHAlignRight, Range("4"), True, 10)
            objSheet.Range(objColumn.Item("3").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.00"



            objBook.Application.ActiveWindow.Zoom = 100

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .TopMargin = 20
                .LeftMargin = 20
                .RightMargin = 20
                .BottomMargin = 20
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "LOSS REPORT"

    Public Function LOSS_REPORT_EXCEL(ByVal DT As System.Data.DataTable) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 15
                SetColumnWidth(Range(i), 10)
            Next
            SetColumnWidth(Range(3), 15)


            ''''''''''Report Title
            'CMPNAME
            RowIndex = 2
            Write(tempcmpname, Range("1"), XlHAlign.xlHAlignCenter, Range("11"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("11"))

            'LOSS REPORT
            RowIndex += 1
            Write("Loss Report", Range("1"), XlHAlign.xlHAlignCenter, Range("11"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("11"))



            'COLUMNS NAME
            RowIndex += 1
            Write("Date", Range("1"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Lot No", Range("2"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Process", Range("3"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("In Wt.", Range("4"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Out Wt.", Range("5"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Loss Wt.", Range("6"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Fine", Range("7"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Part No", Range("8"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Max Loss", Range("9"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Extra Loss", Range("10"), XlHAlign.xlHAlignCenter, , True, 9)
            Write("Req Melting", Range("11"), XlHAlign.xlHAlignCenter, , True, 9)
            SetBorder(RowIndex, Range("1"), Range("11"))


            'FREEZE TOP 5 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 5, objColumn.Item("11").ToString & 5).Select()
            objSheet.Range(objColumn.Item("1").ToString & 5, objColumn.Item("11").ToString & 5).Application.ActiveWindow.FreezePanes = True


            'Dim STYLE As Excel.Style = objSheet.Application.ActiveWorkbook.Styles.Add("NEWSTYLE")
            'STYLE.Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.Yellow)

            If DT.Rows.Count > 0 Then
                For Each DTROW As System.Data.DataRow In DT.Rows
                    RowIndex += 1

                    Write(DTROW("DATE"), Range("1"), XlHAlign.xlHAlignCenter, , False, 9)
                    Write(DTROW("LOTNO"), Range("2"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("PROCESSNAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(DTROW("INWT"), Range("4"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("OUTWT"), Range("5"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("LOSS"), Range("6"), XlHAlign.xlHAlignRight, , False, 9)
                    If ClientName = "CNJ" Then Write(Format((Val(DTROW("LOSS")) * Val(DTROW("REQPURITY"))) / 100, "0.000"), Range("7"), XlHAlign.xlHAlignRight, , False, 9) Else Write(DTROW("NETTWT"), Range("7"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("PARTNO"), Range("8"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(DTROW("MAXLOSS"), Range("9"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("EXTRALOSS"), Range("10"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("REQPURITY"), Range("11"), XlHAlign.xlHAlignRight, , False, 9)
                    If DTROW("PARTNO") = "" Then objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex).Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.Yellow)
                Next
            End If


            SetBorder(RowIndex, objColumn.Item("1").ToString & 5, objColumn.Item("11").ToString & RowIndex)


            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("3"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("3"))
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, Range("4"))
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, Range("5"))
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, Range("6"))
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, Range("7"))
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, Range("8"))
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, Range("9"))
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, Range("10"))
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, Range("11"))


            FORMULA("=SUM(" & objColumn.Item("4").ToString & 5 & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 5 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & 5 & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 5 & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("9").ToString & 5 & ":" & objColumn.Item("9").ToString & RowIndex - 1 & ")", Range("9"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("10").ToString & 5 & ":" & objColumn.Item("10").ToString & RowIndex - 1 & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 10)

            objSheet.Range(objColumn.Item("4").ToString & 1, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("5").ToString & 1, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("6").ToString & 1, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("7").ToString & 1, objColumn.Item("7").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("9").ToString & 1, objColumn.Item("9").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("10").ToString & 1, objColumn.Item("10").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("11").ToString & 1, objColumn.Item("11").ToString & RowIndex).NumberFormat = "0.00"



            objBook.Application.ActiveWindow.Zoom = 100

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .TopMargin = 20
                .LeftMargin = 20
                .RightMargin = 20
                .BottomMargin = 20
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "PENDING LOT REPORT"

    Public Function PENDINGLOT_REPORT_EXCEL(ByVal DT As System.Data.DataTable, Optional ByVal HEADER As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 15
                SetColumnWidth(Range(i), 9)
            Next
            SetColumnWidth(Range(5), 20)
            SetColumnWidth(Range(7), 12)
            SetColumnWidth(Range(9), 20)
            SetColumnWidth(Range(10), 20)


            ''''''''''Report Title
            'CMPNAME
            RowIndex = 2
            Write(tempcmpname, Range("1"), XlHAlign.xlHAlignCenter, Range("12"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("11"))

            'WASTAGE REPORT
            RowIndex += 1
            Write("Pending Lot Report       " & HEADER, Range("1"), XlHAlign.xlHAlignCenter, Range("12"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("12"))


            'HEADERS
            RowIndex += 1
            Write("Lot No", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 9)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("Req Purity", Range("2"), XlHAlign.xlHAlignCenter, Range("2"), True, 9)
            SetBorder(RowIndex, Range("2"), Range("2"))
            Write("Date", Range("3"), XlHAlign.xlHAlignCenter, Range("3"), True, 9)
            SetBorder(RowIndex, Range("3"), Range("3"))
            Write("Part", Range("4"), XlHAlign.xlHAlignCenter, Range("4"), True, 9)
            SetBorder(RowIndex, Range("4"), Range("4"))
            Write("Name", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 9)
            SetBorder(RowIndex, Range("5"), Range("5"))
            Write("Gross Wt", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 9)
            SetBorder(RowIndex, Range("6"), Range("6"))
            Write("Process Name", Range("7"), XlHAlign.xlHAlignCenter, Range("7"), True, 9)
            SetBorder(RowIndex, Range("7"), Range("7"))
            Write("Purity", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 9)
            SetBorder(RowIndex, Range("8"), Range("8"))
            Write("Brief", Range("9"), XlHAlign.xlHAlignCenter, Range("9"), True, 9)
            SetBorder(RowIndex, Range("9"), Range("9"))
            Write("Remarks", Range("10"), XlHAlign.xlHAlignCenter, Range("10"), True, 9)
            SetBorder(RowIndex, Range("10"), Range("10"))
            Write("Nett Wt", Range("11"), XlHAlign.xlHAlignCenter, Range("11"), True, 9)
            SetBorder(RowIndex, Range("11"), Range("11"))
            Write("Order No", Range("12"), XlHAlign.xlHAlignCenter, Range("12"), True, 9)
            SetBorder(RowIndex, Range("12"), Range("12"))


            'FREEZE TOP 5 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 5, objColumn.Item("12").ToString & 5).Select()
            objSheet.Range(objColumn.Item("1").ToString & 5, objColumn.Item("12").ToString & 5).Application.ActiveWindow.FreezePanes = True


            If DT.Rows.Count > 0 Then
                For Each DTROW As System.Data.DataRow In DT.Rows
                    RowIndex += 1

                    Write(DTROW("LOTNO"), Range("1"), XlHAlign.xlHAlignCenter, , False, 9)
                    Write(DTROW("REQPURITY"), Range("2"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("DATE1"), Range("3"), XlHAlign.xlHAlignCenter, , False, 9, True)
                    Write(DTROW("PARTNO"), Range("4"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(DTROW("NAME"), Range("5"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(DTROW("GROSS"), Range("6"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("PROCESS"), Range("7"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(DTROW("PURITY"), Range("8"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("BRIEF"), Range("9"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(DTROW("REMARKS"), Range("10"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(DTROW("NETTWT"), Range("11"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("ORDERNO"), Range("12"), XlHAlign.xlHAlignRight, , False, 9)

                Next
            End If


            SetBorder(RowIndex, objColumn.Item("1").ToString & 5, objColumn.Item("11").ToString & RowIndex)


            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("5"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("11"))
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("5"))
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, Range("6"))
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, Range("11"))
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, Range("12"))


            FORMULA("=SUM(" & objColumn.Item("6").ToString & 5 & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("11").ToString & 5 & ":" & objColumn.Item("11").ToString & RowIndex - 1 & ")", Range("11"), XlHAlign.xlHAlignRight, , True, 10)
            objSheet.Range(objColumn.Item("2").ToString & 1, objColumn.Item("2").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 1, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("8").ToString & 1, objColumn.Item("8").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("11").ToString & 1, objColumn.Item("11").ToString & RowIndex).NumberFormat = "0.000"


            objBook.Application.ActiveWindow.Zoom = 100

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .TopMargin = 20
                .LeftMargin = 20
                .RightMargin = 20
                .BottomMargin = 20
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "FACTORY ISSUE DIFF REPORT"

    Public Function FACTISSDIFF_REPORT_EXCEL(ByVal DT As System.Data.DataTable, ByVal PERIOD As String) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 15
                SetColumnWidth(Range(i), 9)
            Next
            SetColumnWidth(Range(10), 20)


            ''''''''''Report Title
            'CMPNAME
            RowIndex = 2
            Write(tempcmpname, Range("1"), XlHAlign.xlHAlignCenter, Range("12"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("10"))

            'WASTAGE REPORT
            RowIndex += 1
            Write("Factory - Party Issue Diff Report       " & PERIOD, Range("1"), XlHAlign.xlHAlignCenter, Range("10"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("10"))


            'HEADERS
            RowIndex += 1
            Write("Lot No", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 9)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("Date", Range("2"), XlHAlign.xlHAlignCenter, Range("2"), True, 9)
            SetBorder(RowIndex, Range("2"), Range("2"))
            Write("In Wt.", Range("3"), XlHAlign.xlHAlignCenter, Range("3"), True, 9)
            SetBorder(RowIndex, Range("3"), Range("3"))
            Write("Out Wt.", Range("4"), XlHAlign.xlHAlignCenter, Range("4"), True, 9)
            SetBorder(RowIndex, Range("4"), Range("4"))
            Write("%In", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 9)
            SetBorder(RowIndex, Range("5"), Range("5"))
            Write("%Out", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 9)
            SetBorder(RowIndex, Range("6"), Range("6"))
            Write("%Final", Range("7"), XlHAlign.xlHAlignCenter, Range("7"), True, 9)
            SetBorder(RowIndex, Range("7"), Range("7"))
            Write("Diff", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 9)
            SetBorder(RowIndex, Range("8"), Range("8"))
            Write("Fine Diff", Range("9"), XlHAlign.xlHAlignCenter, Range("9"), True, 9)
            SetBorder(RowIndex, Range("9"), Range("9"))
            Write("Item Code", Range("10"), XlHAlign.xlHAlignCenter, Range("10"), True, 9)
            SetBorder(RowIndex, Range("10"), Range("10"))


            'FREEZE TOP 5 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 5, objColumn.Item("10").ToString & 5).Select()
            objSheet.Range(objColumn.Item("1").ToString & 5, objColumn.Item("10").ToString & 5).Application.ActiveWindow.FreezePanes = True


            If DT.Rows.Count > 0 Then
                For Each DTROW As System.Data.DataRow In DT.Rows
                    RowIndex += 1

                    Write(DTROW("LOTNO"), Range("1"), XlHAlign.xlHAlignCenter, , False, 9)
                    Write(DTROW("DATE1"), Range("2"), XlHAlign.xlHAlignCenter, , False, 9)
                    Write(DTROW("INWT"), Range("3"), XlHAlign.xlHAlignRight, , False, 9, True)
                    Write(DTROW("OUTWT"), Range("4"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("PERCENTIN"), Range("5"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("PERCENTOUT"), Range("6"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("PERCENTFINAL"), Range("7"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("DIFF"), Range("8"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("FINEDIFF"), Range("9"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(DTROW("ITEMCODE"), Range("10"), XlHAlign.xlHAlignLeft, , False, 9)

                Next
            End If


            SetBorder(RowIndex, objColumn.Item("1").ToString & 5, objColumn.Item("10").ToString & RowIndex)


            RowIndex += 1
            objSheet.Range(objColumn.Item("3").ToString & 1, objColumn.Item("3").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("4").ToString & 1, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.000"
            objSheet.Range(objColumn.Item("5").ToString & 1, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 1, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("7").ToString & 1, objColumn.Item("7").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("8").ToString & 1, objColumn.Item("8").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("9").ToString & 1, objColumn.Item("9").ToString & RowIndex).NumberFormat = "0.000"


            FORMULA("=SUM(" & objColumn.Item("8").ToString & 5 & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("9").ToString & 5 & ":" & objColumn.Item("9").ToString & RowIndex - 1 & ")", Range("9"), XlHAlign.xlHAlignRight, , True, 10)


            objBook.Application.ActiveWindow.Zoom = 100

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .TopMargin = 20
                .LeftMargin = 20
                .RightMargin = 20
                .BottomMargin = 20
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

End Class
