﻿
Imports Excel
Imports System.Data.OleDb

Module ExcelFunctions

#Region "EXCEL HEADER"

    Private objColumn As New Hashtable
    Dim ROWINDEX As Integer = 0

    Private Sub SetColumn(ByVal Key As String, ByVal ForColumn As String)
        Try
            objColumn.Add(Key, ForColumn)
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

    Private Sub SetColumnWidth(ByVal OBJSHEET As Excel.Worksheet, ByVal Range As String, ByVal width As Integer)
        'objSheet.Range(Range).BorderAround()
        OBJSHEET.Range(Range).ColumnWidth = width
        '  = objSheet.Range(Range).Select()
        'objSheet.Range(Range).EditionOptions(XlEditionType.xlPublisher, XlEditionOptionsOption.xlAutomaticUpdate, , , XlPictureAppearance.xlScreen, XlPictureAppearance.xlScreen)
    End Sub

    Sub Write(ByVal OBJSHEET As Excel.Worksheet, ByVal Text As Object, ByVal Range As String, ByVal Align As XlHAlign, _
        Optional ByVal ToRange As String = Nothing, Optional ByVal FontBold As Boolean = False, _
        Optional ByVal FontSize As Int16 = 9, Optional ByVal WrapText As Boolean = False, Optional ByVal _
fontItalic As Boolean = False)
        Try
            OBJSHEET.Range(Range).FormulaR1C1 = Text
            'objSheet.Range(Range).BorderAround()
            If Not ToRange Is Nothing Then
                OBJSHEET.Range(Range, ToRange).Merge()
                'objSheet.Range(Range, ToRange).BorderAround()
            End If
            OBJSHEET.Range(Range).HorizontalAlignment = Align
            OBJSHEET.Range(Range).Font.Name = "Calibri"
            If FontBold Then OBJSHEET.Range(Range).Font.Bold = True
            If FontSize > 0 Then OBJSHEET.Range(Range).Font.Size = FontSize
            If WrapText Then OBJSHEET.Range(Range).WrapText = True
            If fontItalic Then OBJSHEET.Range(Range).Font.Italic = True


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SetBorder(ByVal OBJSHEET As Excel.Worksheet, ByVal RowIndex As Integer, Optional ByVal Range As String = Nothing, Optional ByVal ToRange As String = Nothing)

        Dim intI As Integer = 0
        ''RowIndex = 0
        'obj()
        'objSheet.Selec
        'objExcel.Selection("A1:N17").ToString()
        OBJSHEET.Range(Range, ToRange).Select()
        OBJSHEET.Range(Range, ToRange).BorderAround(, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, )
        'For intI = 1 To RowIndex
        '    objSheet.Range(Range, ToRange).Select()
        '    objSheet.Range(Range, ToRange).BorderAround(, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, )
        '    intI += 1
        'Next
    End Sub

    Function Range(ByVal Key As String) As String
        Try
            Return objColumn.Item(Key).ToString & ROWINDEX.ToString
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Sub INSERTNAME(ByVal PATH As String, ByVal COLS As Integer, ByVal NAME As String, ByVal period As String)
        Try
            Dim OBJEXCEL As New Excel.Application
            Dim OBJBOOK As Excel.Workbook = OBJEXCEL.Workbooks.Open(PATH)
            Dim OBJSHEET As Excel.Worksheet = OBJBOOK.Sheets(1)


            objColumn.Clear()
            For I As Integer = 1 To COLS
                SetColumn(I, Chr(64 + I))
            Next

            ROWINDEX = 1
            For i As Integer = 1 To COLS
                SetColumnWidth(OBJSHEET, Range(i), 11)
            Next


            ROWINDEX = 2
            OBJSHEET.Range(Range("1"), Range(COLS)).EntireRow.Insert()
            OBJSHEET.Range(Range("1"), Range(COLS)).EntireRow.Insert()
            OBJSHEET.Range(Range("1"), Range(COLS)).EntireRow.Insert()

            Write(OBJSHEET, "Name : ", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write(OBJSHEET, NAME, Range("2"), XlHAlign.xlHAlignCenter, Range("5"), True, 10)
            Write(OBJSHEET, "Period: ", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            Write(OBJSHEET, period, Range("7"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
            SetBorder(OBJSHEET, ROWINDEX, Range("1"), Range(COLS))

            OBJEXCEL.AlertBeforeOverwriting = False
            OBJEXCEL.DisplayAlerts = False
            OBJSHEET.SaveAs(PATH)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub EXCELCMPHEADER(ByVal PATH As String, ByVal REPORTTITLE As String, ByVal COLS As Integer, Optional ByVal NAME As String = "", Optional ByVal PERIOD As String = "", Optional ByVal OPENING As String = "", Optional ByVal CLOSING As String = "")
        Try
            Dim OBJEXCEL As New Excel.Application
            Dim OBJBOOK As Excel.Workbook = OBJEXCEL.Workbooks.Open(PATH)
            Dim OBJSHEET As Excel.Worksheet = OBJBOOK.Sheets(1)

            CMPHEADER(OBJSHEET, tempcmpid, REPORTTITLE, COLS, NAME, PERIOD, OPENING, CLOSING)

            OBJEXCEL.Visible = True


            OBJBOOK.Application.ActiveWindow.Zoom = 100

            With OBJSHEET.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .RightMargin = 0
                .BottomMargin = 0
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            OBJEXCEL.AlertBeforeOverwriting = False
            OBJEXCEL.DisplayAlerts = False
            OBJSHEET.SaveAs(PATH)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CMPHEADER(ByVal OBJSHEET As Excel.Worksheet, ByVal CMPID As Integer, ByVal REPORTTITLE As String, ByVal COLS As Integer, ByVal NAME As String, ByVal PERIOD As String, ByVal OPENING As String, ByVal CLOSING As String)
        Try
            '''''''''''Report Title

            objColumn.Clear()
            For I As Integer = 1 To COLS
                SetColumn(I, Chr(64 + I))
            Next

            ROWINDEX = 1
            For i As Integer = 1 To COLS
                SetColumnWidth(OBJSHEET, Range(i), 11)
            Next


            ROWINDEX = 1
            OBJSHEET.Range(Range("1"), Range(COLS)).EntireRow.Insert()
            OBJSHEET.Range(Range("1"), Range(COLS)).EntireRow.Insert()
            

            'FOR NAME AND PERIOD
            OBJSHEET.Range(Range("1"), Range(COLS)).EntireRow.Insert()
            OBJSHEET.Range(Range("1"), Range(COLS)).EntireRow.Insert()

            'FOR REPORT TITLE
            OBJSHEET.Range(Range("1"), Range(COLS)).EntireRow.Insert()


            ROWINDEX = 2
            Write(OBJSHEET, tempcmpname, Range("1"), XlHAlign.xlHAlignCenter, Range(COLS), True, 14)
            SetBorder(OBJSHEET, ROWINDEX, Range("1"), Range(COLS))


            'REPORT TITLE
            ROWINDEX += 1
            If REPORTTITLE <> "" Then
                Write(OBJSHEET, REPORTTITLE, Range("1"), XlHAlign.xlHAlignCenter, Range(COLS), True, 9)
                SetBorder(OBJSHEET, ROWINDEX, Range("1"), Range(COLS))
            End If



            'NAME AND PERIOD
            ROWINDEX += 2
            
            If NAME <> "" Then Write(OBJSHEET, "Name : " & NAME, Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 8)
            If PERIOD <> "" Then Write(OBJSHEET, "Period : " & PERIOD, Range(COLS - 2), XlHAlign.xlHAlignRight, Range(COLS), True, 8)
            If NAME <> "" Or PERIOD <> "" Then SetBorder(OBJSHEET, ROWINDEX, Range("1"), Range(COLS))


            'OPENINGBAL
            ROWINDEX += 1
            If OPENING <> "" Then Write(OBJSHEET, "Opening : " & OPENING, Range(COLS - 1), XlHAlign.xlHAlignRight, Range(COLS), True, 8)
            If OPENING <> "" Then SetBorder(OBJSHEET, ROWINDEX, Range("1"), Range(COLS))



            'GET LAST ROW
            ROWINDEX = OBJSHEET.UsedRange.Rows.Count
            ROWINDEX += 2
            If CLOSING <> "" Then Write(OBJSHEET, "Closing : " & CLOSING, Range(COLS - 1), XlHAlign.xlHAlignRight, Range(COLS), True, 8)
            If CLOSING <> "" Then SetBorder(OBJSHEET, ROWINDEX, Range("1"), Range(COLS))


            'FREEZE TOP 6 ROWS
            OBJSHEET.Range(objColumn.Item("1").ToString & 7, objColumn.Item(COLS.ToString).ToString & 7).Select()
            OBJSHEET.Range(objColumn.Item("1").ToString & 7, objColumn.Item(COLS.ToString).ToString & 7).Application.ActiveWindow.FreezePanes = True

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

End Module
