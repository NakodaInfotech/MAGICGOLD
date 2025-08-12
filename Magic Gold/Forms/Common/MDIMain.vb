
Imports System.IO
Imports System.Data.OleDb

Public Class MDIMain

    Private m_ChildFormNumber As Integer = 0

    Sub SCROLLERS()
        Try


            LBLPENDING.Left = Me.Width
            LBLPENDING.Top = StatusStrip2.Top + 2

            Dim PENDINGENTRIES As String = "No Pending Entries"
            Dim WHERECLAUSE As String = " WHERE STOCKTRANSFER.ST_ACCEPTED = 0 "
            If USERDEPARTMENT <> "" Then WHERECLAUSE = WHERECLAUSE & " AND TODEPARTMENTMASTER.DEPARTMENT_NAME = '" & USERDEPARTMENT & "'"
            Dim dt As New DataTable()
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            tempcmd = New OleDbCommand(" SELECT STOCKTRANSFER.ST_ACCEPTED AS ACCEPTED, STOCKTRANSFER.ST_NO AS STNO, STOCKTRANSFER.ST_DATE AS STDATE, STOCKTRANSFER.ST_SRNO AS GRIDSRNO, ItemMaster.item_code AS ITEMNAME, STOCKTRANSFER.ST_ITEMDESC AS ITEMDESC, STOCKTRANSFER.ST_PCS AS PCS, STOCKTRANSFER.ST_GROSSWT AS GROSSWT, STOCKTRANSFER.ST_PURITY AS PURITY, STOCKTRANSFER.ST_WASTAGE AS WASTAGE, STOCKTRANSFER.ST_FINEWT AS FINEWT, STOCKTRANSFER.ST_REMARKS AS REMARKS, IIF(ISNULL(FROMDEPARTMENTMASTER.DEPARTMENT_NAME) = 'TRUE', '', FROMDEPARTMENTMASTER.DEPARTMENT_NAME) AS FROMDEPARTMENT , IIF(ISNULL(TODEPARTMENTMASTER.DEPARTMENT_NAME) = 'TRUE', '', TODEPARTMENTMASTER.DEPARTMENT_NAME) AS TODEPARTMENT FROM ((STOCKTRANSFER INNER JOIN ItemMaster ON STOCKTRANSFER.ST_ITEMID = ItemMaster.item_id) LEFT JOIN DEPARTMENTMASTER AS FROMDEPARTMENTMASTER ON STOCKTRANSFER.ST_FROMDEPARTMENTID = FROMDEPARTMENTMASTER.DEPARTMENT_ID) LEFT JOIN DEPARTMENTMASTER AS TODEPARTMENTMASTER ON STOCKTRANSFER.ST_TODEPARTMENTID = TODEPARTMENTMASTER.DEPARTMENT_ID " & WHERECLAUSE & " ORDER BY STOCKTRANSFER.ST_NO ", tempconn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                PENDINGENTRIES = ""
                For Each ROW As DataRow In dt.Rows
                    PENDINGENTRIES = PENDINGENTRIES & ROW("FROMDEPARTMENT") & " - " & ROW("ITEMNAME") & " - " & Val(ROW("GROSSWT")) & "                        "
                Next
            End If
            tempconn.Close()
            LBLPENDING.Text = PENDINGENTRIES

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACCADD.Click
        Try
            Dim OBJVENDOR As New ACCOUNTMASTER
            OBJVENDOR.MdiParent = Me
            OBJVENDOR.cmdedit.Enabled = True
            OBJVENDOR.EDIT = False
            OBJVENDOR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditAccountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACCEDIT.Click

        'editing account
        If (chldvendordetails.IsMdiChild = False) Then
            If chldvendordetails.IsDisposed = True Then
                chldvendordetails = New ACCOUNTDETAILS
            End If
            chldvendordetails.MdiParent = Me
            chldvendordetails.Show()
        Else
            chldvendordetails.BringToFront()
        End If

    End Sub

    Private Sub EditExistingGroupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GROUPEDIT.Click

        'editing group
        If (chldgroupdetails.IsMdiChild = False) Then
            If chldgroupdetails.IsDisposed = True Then
                chldgroupdetails = New groupdetails
            End If
            chldgroupdetails.MdiParent = Me
            chldgroupdetails.Show()
        Else
            chldgroupdetails.BringToFront()
        End If

    End Sub

    Private Sub AddNewGroupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GROUPADD.Click

        'adding new group
        If (chldgroupmaster.IsMdiChild = False) Then
            If chldgroupmaster.IsDisposed = True Then
                chldgroupmaster = New groupmaster
            End If
            chldgroupmaster.MdiParent = Me
            chldgroupmaster.cmdedit.Enabled = True
            chldgroupmaster.EDIT = False
            chldgroupmaster.Show()
        Else
            chldgroupmaster.BringToFront()
        End If

    End Sub

    Private Sub AddNewAreaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewAreaToolStripMenuItem.Click

        'add area
        If (chldareamaster.IsMdiChild = False) Then
            If chldareamaster.IsDisposed = True Then
                chldareamaster = New areamaster
            End If
            chldareamaster.MdiParent = Me
            frmareamaster = True
            frmcitymaster = False
            frmstatemaster = False
            frmcountrymaster = False
            frmcategorymaster = False
            frmtypemaster = False
            chldareamaster.Show()
        Else
            chldareamaster.BringToFront()
        End If

    End Sub

    Private Sub AddNewCityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewCityToolStripMenuItem.Click

        'add city
        If (chldareamaster.IsMdiChild = False) Then
            If chldareamaster.IsDisposed = True Then
                chldareamaster = New areamaster
            End If
            chldareamaster.MdiParent = Me
            frmareamaster = False
            frmcitymaster = True
            frmstatemaster = False
            frmcountrymaster = False
            frmcategorymaster = False
            frmtypemaster = False
            chldareamaster.Show()
        Else
            chldareamaster.BringToFront()
        End If

    End Sub

    Private Sub AddNewStateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewStateToolStripMenuItem.Click

        'add state
        If (chldareamaster.IsMdiChild = False) Then
            If chldareamaster.IsDisposed = True Then
                chldareamaster = New areamaster
            End If
            chldareamaster.MdiParent = Me
            frmareamaster = False
            frmcitymaster = False
            frmstatemaster = True
            frmcountrymaster = False
            frmcategorymaster = False
            frmtypemaster = False
            chldareamaster.Show()
        Else
            chldareamaster.BringToFront()
        End If

    End Sub

    Private Sub AddNewCountryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewCountryToolStripMenuItem.Click

        'add country
        If (chldareamaster.IsMdiChild = False) Then
            If chldareamaster.IsDisposed = True Then
                chldareamaster = New areamaster
            End If
            chldareamaster.MdiParent = Me
            frmareamaster = False
            frmcitymaster = False
            frmstatemaster = False
            frmcountrymaster = True
            frmcategorymaster = False
            frmtypemaster = False
            chldareamaster.Show()
        Else
            chldareamaster.BringToFront()
        End If

    End Sub

    Private Sub AddNewCompanyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMPADD.Click

        'add company
        If (chldcmpmaster.IsMdiChild = False) Then
            If chldcmpmaster.IsDisposed = True Then
                chldcmpmaster = New companymaster
            End If
            chldcmpmaster.MdiParent = Me
            chldcmpmaster.Show()
        Else
            chldcmpmaster.BringToFront()
        End If

    End Sub

    Private Sub EditExistingCompanyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMPEDIT.Click

        'editing company
        If (chldcmpmaster.IsMdiChild = False) Then
            If chldcmpmaster.IsDisposed = True Then
                chldcmpmaster = New companymaster
            End If
            chldcmpmaster.MdiParent = Me
            chldcmpmaster.cmdedit.Enabled = False
            chldcmpmaster.EDIT = True
            chldcmpmaster.Show()
        Else
            chldcmpmaster.Show()
            chldcmpmaster.BringToFront()
        End If

    End Sub

    Private Sub MDIParent1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        openconn("MagicGold")
        openconn(tempcmpname)

        Mastersmenu.Enabled = False
        Transactionsmenu.Enabled = False
        Reportsmenu.Enabled = False
        Utilitiesmenu.Enabled = False
        HelpMenu.Enabled = False



        '********************

        If ClientName = "MIMARAGEMS" Then
            MFG_TOOL.Visible = False
            MFG_MASTER.Visible = False
            MFG_TOOLSTRIP.Visible = False
        Else
            MATERIALREC_MASTER.Visible = False
            MATERIALRET_MASTER.Visible = False
            TOOLSTRIPORDER.Visible = False
            PREPOLISH_TOOL.Visible = False
            PREPOLISH_TOOLSTRIP.Visible = False
            FILLING_MASTER.Visible = False
            FILLING_TOOL.Visible = False
            FILLING_TOOLSTRIP.Visible = False
            PREPOLISH_MASTER.Visible = False
            FINALPOLISH_MASTER.Visible = False
            REPAIR_MASTER.Visible = False
        End If

        SETENABILITY()

        If ALLOWLABELLING = True Then
            LABELLING_MASTER.Enabled = True
        End If

        'CHECK WHETHER IS DATABASE IS MASTER OR NOT, IF THIS IS NOT MASTER DATABASE THEN DONT ALLOW TO ADD MASTERS
        'IN DATABASE IF VERSION_PRESENT = TRUE THEN THIS IS MASTER DATABASE ELSE DONT ALLOW TO ADD MASTERS
        Dim dt As New DataTable()
        If tempconn.State = ConnectionState.Open Then tempconn.Close()
        tempconn.Open()
        tempcmd = New OleDbCommand(" SELECT VERSION_PRESENT AS ISMASTER FROM VERSION ", tempconn)
        da = New OleDbDataAdapter(tempcmd)
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            If Convert.ToBoolean(dt.Rows(0).Item("ISMASTER")) = False Then ISMASTER = False
        End If
        tempconn.Close()
        If ISMASTER = False Then
            ACC_MASTER.Enabled = False
            ACC_TOOL.Enabled = False
            GROUP_MASTER.Enabled = False
            SALESMAN_MASTER.Enabled = False
            ITEM_MASTER.Enabled = False
            ITEM_TOOL.Enabled = False
            ITEMTYPE_MASTER.Enabled = False
            ITEMCATEGORY_MASTER.Enabled = False
            SIZE_MASTER.Enabled = False
            SHAPE_MASTER.Enabled = False
            COLOR_MASTER.Enabled = False
            LOCATION_MASTER.Enabled = False
            PROCESS_MASTER.Enabled = False
            TAX_MASTER.Enabled = False
            CMP_MASTER.Enabled = False
            YEAR_MASTER.Enabled = False
            DEPARTMENT_MASTER.Enabled = False
            ADMIN_MASTER.Enabled = False
        End If

    End Sub

    Sub SETENABILITY()
        Try

            If USERNAME = "Admin" Then
                CMP_MASTER.Enabled = True
                CMPADD.Enabled = True
                CMPEDIT.Enabled = True

                YEAR_MASTER.Enabled = True
                YEARADD.Enabled = True
                YEARDELETE.Enabled = True

                PROCESS_MASTER.Enabled = True
                DEPARTMENT_MASTER.Enabled = True

                ADMIN_MASTER.Enabled = True
                USER_MASTER.Enabled = True
                USERADD.Enabled = True
                USEREDIT.Enabled = True
                OPENING.Enabled = True

            Else
                'ONLY TO CHANGE PASSWORD
                ADMIN_MASTER.Enabled = True
                USERADD.Enabled = False
                USEREDIT.Enabled = True
            End If

            For Each DTROW As DataRow In USERRIGHTS.Rows

                'MASTERS
                If DTROW(0).ToString = "GROUP MASTER" Then
                    If DTROW(1).ToString = True Then
                        GROUP_MASTER.Enabled = True
                        GROUPADD.Enabled = True
                    Else
                        GROUPADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        GROUP_MASTER.Enabled = True
                        GROUPEDIT.Enabled = True
                    Else
                        GROUPEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "ACCOUNTS MASTER" Then
                    If DTROW(1).ToString = True Then
                        ACC_MASTER.Enabled = True
                        ACCADD.Enabled = True
                        ACC_TOOL.Enabled = True
                    Else
                        ACCADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        ACC_MASTER.Enabled = True
                        ACC_TOOL.Enabled = True
                        ACCEDIT.Enabled = True
                    Else
                        ACCEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "ITEM MASTER" Then
                    If DTROW(1).ToString = True Then
                        ITEM_MASTER.Enabled = True
                        ITEMTYPE_MASTER.Enabled = True
                        ITEMCATEGORY_MASTER.Enabled = True
                        SIZE_MASTER.Enabled = True
                        SHAPE_MASTER.Enabled = True
                        COLOR_MASTER.Enabled = True
                        ITEM_TOOL.Enabled = True

                        ITEMTYPEADD.Enabled = True
                        ITEMCATEGORYADD.Enabled = True
                        SIZEADD.Enabled = True
                        SHAPEADD.Enabled = True
                        COLORADD.Enabled = True

                    Else
                        ITEMTYPEADD.Enabled = False
                        ITEMCATEGORYADD.Enabled = False
                        SIZEADD.Enabled = False
                        SHAPEADD.Enabled = False
                        COLORADD.Enabled = False

                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        ITEM_MASTER.Enabled = True
                        ITEMTYPE_MASTER.Enabled = True
                        ITEMCATEGORY_MASTER.Enabled = True
                        SIZE_MASTER.Enabled = True
                        SHAPE_MASTER.Enabled = True
                        COLOR_MASTER.Enabled = True
                        ITEM_TOOL.Enabled = True

                        ITEMTYPEEDIT.Enabled = True
                        ITEMCATEGORYEDIT.Enabled = True
                        SIZEEDIT.Enabled = True
                        SHAPEEDIT.Enabled = True
                        COLOREDIT.Enabled = True

                    Else
                        ITEMTYPEEDIT.Enabled = False
                        ITEMCATEGORYEDIT.Enabled = False
                        SIZEEDIT.Enabled = False
                        SHAPEEDIT.Enabled = False
                        COLOREDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "TAX MASTER" Then
                    If DTROW(1).ToString = True Then
                        TAX_MASTER.Enabled = True
                        TAXADD.Enabled = True
                    Else
                        TAXADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        TAX_MASTER.Enabled = True
                        TAXEDIT.Enabled = True
                    Else
                        TAXEDIT.Enabled = False
                    End If




                    'SALE & PURCHASE
                ElseIf DTROW(0).ToString = "SALE ORDER" Then
                    If DTROW(1).ToString = True Then
                        SO_MASTER.Enabled = True
                        MATERIALREC_MASTER.Enabled = True
                        MATERIALRET_MASTER.Enabled = True
                        SOADD.Enabled = True
                        MATERIALRECADD.Enabled = True
                        MATERIALRETADD.Enabled = True
                    Else
                        SOADD.Enabled = False
                        MATERIALRECADD.Enabled = False
                        MATERIALRETADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        SO_MASTER.Enabled = True
                        MATERIALREC_MASTER.Enabled = True
                        MATERIALRET_MASTER.Enabled = True
                        SOEDIT.Enabled = True
                        MATERIALRECEDIT.Enabled = True
                        MATERIALRETEDIT.Enabled = True
                    Else
                        SOEDIT.Enabled = False
                        MATERIALRECEDIT.Enabled = False
                        MATERIALRETEDIT.Enabled = False
                    End If



                ElseIf DTROW(0).ToString = "VOUCHERS" Then
                    If DTROW(1).ToString = True Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        DAILYKHATA_MASTER.Enabled = True
                        RECEIPT_MASTER.Enabled = True
                        ISSUE_MASTER.Enabled = True
                        DAILYKHATA_TOOL.Enabled = True
                        RECEIPT_TOOL.Enabled = True
                        ISSUE_TOOL.Enabled = True
                    End If

                ElseIf DTROW(0).ToString = "JOURNAL" Then
                    If DTROW(1).ToString = True Then
                        JOURNAL_MASTER.Enabled = True
                        JV_TOOL.Enabled = True
                        JOURNALADD.Enabled = True
                    Else
                        JOURNALADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        JOURNAL_MASTER.Enabled = True
                        JV_TOOL.Enabled = True
                        JOURNALEDIT.Enabled = True
                    Else
                        JOURNALEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "STOCK TRANSFER" Then
                    If DTROW(1).ToString = True Then
                        STOCKTRANSFER_MASTER.Enabled = True
                        STOCKTRANSFERADD.Enabled = True
                    Else
                        STOCKTRANSFERADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        STOCKTRANSFER_MASTER.Enabled = True
                        STOCKTRANSFEREDIT.Enabled = True
                    Else
                        STOCKTRANSFEREDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "CASH" Then
                    If DTROW(1).ToString = True Then
                        CASHREC_MASTER.Enabled = True
                        CASHISSUE_MASTER.Enabled = True
                        CASHREC_TOOL.Enabled = True
                        CASHISSUE_TOOL.Enabled = True
                        CASHRECADD.Enabled = True
                        CASHISSUEADD.Enabled = True
                        SALARY_MASTER.Enabled = True
                        SALARYADD.Enabled = True
                    Else
                        CASHRECADD.Enabled = False
                        CASHISSUEADD.Enabled = False
                        SALARYADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        CASHREC_MASTER.Enabled = True
                        CASHISSUE_MASTER.Enabled = True
                        CASHREC_TOOL.Enabled = True
                        CASHISSUE_TOOL.Enabled = True
                        CASHRECEDIT.Enabled = True
                        CASHISSUEEDIT.Enabled = True
                        SALARY_MASTER.Enabled = True
                        SALARYEDIT.Enabled = True
                    Else
                        CASHRECEDIT.Enabled = False
                        CASHISSUEEDIT.Enabled = False
                        SALARYEDIT.Enabled = False
                    End If

                    'MFG
                ElseIf DTROW(0).ToString = "MELTING" Then
                    If DTROW(1).ToString = True Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        MELTING_MASTER.Enabled = True
                        MELTING_TOOL.Enabled = True
                    End If

                ElseIf DTROW(0).ToString = "MANUFACTURING" Then
                    If DTROW(1).ToString = True Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        MFG_MASTER.Enabled = True
                        MFG_TOOL.Enabled = True
                    End If

                ElseIf DTROW(0).ToString = "FILLING" Then
                    If DTROW(1).ToString = True Then
                        FILLING_MASTER.Enabled = True
                        FILLING_TOOL.Enabled = True
                        FILLINGADD.Enabled = True
                    Else
                        FILLINGADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        FILLING_MASTER.Enabled = True
                        FILLING_TOOL.Enabled = True
                        FILLINGEDIT.Enabled = True
                    Else
                        FILLINGEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "SETTING" Then
                    If DTROW(1).ToString = True Then
                        SETTING_MASTER.Enabled = True
                        SETTING_TOOL.Enabled = True
                        SETTINGADD.Enabled = True
                    Else
                        SETTINGADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        SETTING_MASTER.Enabled = True
                        SETTING_TOOL.Enabled = True
                        SETTINGEDIT.Enabled = True
                    Else
                        SETTINGEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "POLISH" Then
                    If DTROW(1).ToString = True Then
                        PREPOLISH_MASTER.Enabled = True
                        FINALPOLISH_MASTER.Enabled = True
                        PREPOLISH_TOOL.Enabled = True
                        PREPOLISHADD.Enabled = True
                        FINALPOLISHADD.Enabled = True
                    Else
                        PREPOLISHADD.Enabled = False
                        FINALPOLISHADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        PREPOLISH_MASTER.Enabled = True
                        FINALPOLISH_MASTER.Enabled = True
                        PREPOLISH_TOOL.Enabled = True
                        PREPOLISHEDIT.Enabled = True
                        FINALPOLISHEDIT.Enabled = True
                    Else
                        PREPOLISHEDIT.Enabled = False
                        FINALPOLISHEDIT.Enabled = False
                    End If


                    'REPORTS
                ElseIf DTROW(0).ToString = "ACCOUNT REPORTS" Then
                    If (DTROW(1) = True) Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        ACCOUNTREPORT.Enabled = True
                        TBWTREPORT.Enabled = True
                        TBAMTREPORT.Enabled = True
                        TBWTAMTREPORT.Enabled = True
                        LEDGERREPORT.Enabled = True
                        KARIGARREPORT.Enabled = True
                        SETTINGREPORT.Enabled = True
                        AVGSALEPUR.Enabled = True
                        PARTYWASTAGE.Enabled = True
                        PARTYWASTAGEREPORT.Enabled = True
                        PARTYSCRAPREPORT.Enabled = True
                        FACISSDIFFREPORT.Enabled = True
                        ORDERREPORT.Enabled = True
                    End If

                ElseIf DTROW(0).ToString = "STOCK REPORTS" Then
                    If (DTROW(1) = True) Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        STOCKREPORT.Enabled = True
                        STOCKS.Enabled = True
                        STOCKSUMMARY.Enabled = True
                        STOCKONHAND.Enabled = True
                        ITEMSTOCK.Enabled = True
                        STOCKWITHTB.Enabled = True
                        STOCKWITHKARIGARWASTAGE.Enabled = True
                        STOCKWITHKARIGARWASTAGEFINE.Enabled = True
                    End If

                ElseIf DTROW(0).ToString = "MFG REPORTS" Then
                    If (DTROW(1) = True) Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        MFGREPORT.Enabled = True
                        PROCESSREPORT.Enabled = True
                        PROCESSSUMM_REPORT.Enabled = True
                        SAMPLEREPORT.Enabled = True
                        VACCUMREPORT.Enabled = True
                        LOSSREPORT.Enabled = True
                        WASTAGEREPORT.Enabled = True
                        LOTREPORT.Enabled = True
                        LABFILTER.Enabled = True
                    End If

                End If
            Next

            'objhp.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditArea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditArea.Click

        'editing area
        If (chldareadetails.IsMdiChild = False) Then
            If chldareadetails.IsDisposed = True Then
                chldareadetails = New areadetails
            End If
            chldareadetails.MdiParent = Me
            frmareamaster = True
            frmcitymaster = False
            frmstatemaster = False
            frmcountrymaster = False
            frmcategorymaster = False
            frmtypemaster = False
            chldareadetails.Show()
        Else
            chldareadetails.BringToFront()
        End If

    End Sub

    Private Sub EditCity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditCity.Click

        'editing area
        If (chldareadetails.IsMdiChild = False) Then
            If chldareadetails.IsDisposed = True Then
                chldareadetails = New areadetails
            End If
            chldareadetails.MdiParent = Me
            frmareamaster = False
            frmcitymaster = True
            frmstatemaster = False
            frmcountrymaster = False
            frmcategorymaster = False
            frmtypemaster = False
            chldareadetails.Show()
        Else
            chldareadetails.BringToFront()
        End If

    End Sub

    Private Sub EditState_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditState.Click

        'editing area
        If (chldareadetails.IsMdiChild = False) Then
            If chldareadetails.IsDisposed = True Then
                chldareadetails = New areadetails
            End If
            chldareadetails.MdiParent = Me
            frmareamaster = False
            frmcitymaster = False
            frmstatemaster = True
            frmcountrymaster = False
            frmcategorymaster = False
            frmtypemaster = False
            chldareadetails.Show()
        Else
            chldareadetails.BringToFront()
        End If

    End Sub

    Private Sub EditCountry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditCountry.Click

        'editing area
        If (chldareadetails.IsMdiChild = False) Then
            If chldareadetails.IsDisposed = True Then
                chldareadetails = New areadetails
            End If
            chldareadetails.MdiParent = Me
            frmareamaster = False
            frmcitymaster = False
            frmstatemaster = False
            frmcountrymaster = True
            frmcategorymaster = False
            chldareadetails.Show()
        Else
            chldareadetails.BringToFront()
        End If

    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        End
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACC_TOOL.Click
        'editing account
        If (chldvendordetails.IsMdiChild = False) Then
            If chldvendordetails.IsDisposed = True Then
                chldvendordetails = New ACCOUNTDETAILS
            End If
            chldvendordetails.MdiParent = Me
            chldvendordetails.Show()
        Else
            chldvendordetails.BringToFront()
        End If
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITEM_TOOL.Click
        'adding item
        If (chlditemmaster.IsMdiChild = False) Then
            If chlditemmaster.IsDisposed = True Then
                chlditemmaster = New Itemmaster
            End If
            chlditemmaster.MdiParent = Me
            chlditemmaster.Show()
        Else
            chlditemmaster.BringToFront()
        End If
    End Sub

    Private Sub ChangePassWordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePassWordToolStripMenuItem.Click

        'change companypassword    
        If (chldcmppassword.IsMdiChild = False) Then
            If chldcmppassword.IsDisposed = True Then
                chldcmppassword = New companypasswd
            End If
            chldcmppassword.MdiParent = Me
            chldcmppassword.EDIT = True
            chldcmppassword.cmdback.Visible = False
            tempcmd = New OleDbCommand("select * from cmpmaster where cmp_no = " & tempcmpid, tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempdr = tempcmd.ExecuteReader
            tempdr.Read()
            chldcmppassword.txtpassword.Text = tempdr("cmp_password")
            chldcmppassword.txtretypepassword.Text = tempdr("cmp_password")

            'getting values in variables
            tempcmpname = tempdr(1).ToString
            cmplegalname = tempdr(2).ToString
            cmpcstno = tempdr(3).ToString
            cmpvatno = tempdr(4).ToString
            cmppanno = tempdr(5).ToString
            cmpadd1 = tempdr(6).ToString
            cmpadd2 = tempdr(7).ToString
            tempcityid = tempdr(8).ToString
            tempstateid = tempdr(9).ToString
            cmpzip = tempdr(10).ToString
            tempcountryid = tempdr(11).ToString
            cmptel1 = tempdr(12).ToString
            cmpfax = tempdr(13).ToString
            cmpemail = tempdr(14).ToString
            cmpwebsite = tempdr(15).ToString

            chldcmppassword.Show()
        Else
            chldcmppassword.BringToFront()
            chldcmppassword.Show()
        End If
    End Sub

    Private Sub ChangeCompanyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeCompanyToolStripMenuItem.Click
        Try
            'close all child forms
            Dim frm As Form
            For Each frm In MdiChildren
                frm.Close()
            Next

            Me.Dispose()
            companydetails.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        'About Us
        AboutUs.Show(Me)
    End Sub

    Private Sub AddNewCategoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITEMCATEGORYADD.Click

        'add category
        If (chldareamaster.IsMdiChild = False) Then
            If chldareamaster.IsDisposed = True Then
                chldareamaster = New areamaster
            End If
            chldareamaster.MdiParent = Me
            frmareamaster = False
            frmcitymaster = False
            frmstatemaster = False
            frmcountrymaster = False
            frmcategorymaster = True
            frmtypemaster = False
            chldareamaster.Show()
        Else
            chldareamaster.BringToFront()
        End If

    End Sub

    Private Sub EditExistingCategoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITEMCATEGORYEDIT.Click

        'editing category
        If (chldareadetails.IsMdiChild = False) Then
            If chldareadetails.IsDisposed = True Then
                chldareadetails = New areadetails
            End If
            chldareadetails.MdiParent = Me
            frmareamaster = False
            frmcitymaster = False
            frmstatemaster = False
            frmcountrymaster = False
            frmcategorymaster = True
            frmtypemaster = False
            chldareadetails.Show()
        Else
            chldareadetails.BringToFront()
        End If

    End Sub

    Private Sub DesignMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITEM_MASTER.Click
        'adding item
        If (chlditemmaster.IsMdiChild = False) Then
            If chlditemmaster.IsDisposed = True Then
                chlditemmaster = New Itemmaster
            End If
            chlditemmaster.MdiParent = Me
            chlditemmaster.Show()
        Else
            chlditemmaster.BringToFront()
        End If
    End Sub

    Private Sub AddNewItemTypeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITEMTYPEADD.Click

        'add itemtype
        If (chldareamaster.IsMdiChild = False) Then
            If chldareamaster.IsDisposed = True Then
                chldareamaster = New areamaster
            End If
            chldareamaster.MdiParent = Me
            frmareamaster = False
            frmcitymaster = False
            frmstatemaster = False
            frmcountrymaster = False
            frmcategorymaster = False
            frmtypemaster = True
            chldareamaster.Show()
        Else
            chldareamaster.BringToFront()
        End If

    End Sub

    Private Sub EditExistingItemTypeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITEMTYPEEDIT.Click

        'editing itemtype
        If (chldareadetails.IsMdiChild = False) Then
            If chldareadetails.IsDisposed = True Then
                chldareadetails = New areadetails
            End If
            chldareadetails.MdiParent = Me
            frmareamaster = False
            frmcitymaster = False
            frmstatemaster = False
            frmcountrymaster = False
            frmcategorymaster = False
            frmtypemaster = True
            chldareadetails.Show()
        Else
            chldareadetails.BringToFront()
        End If

    End Sub

    Private Sub MeltingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MELTING_MASTER.Click

        'add meltingdetails
        If (chldmeltingdetails.IsMdiChild = False) Then
            If chldmeltingdetails.IsDisposed = True Then
                chldmeltingdetails = New MeltingDetails
            End If
            chldmeltingdetails.MdiParent = Me
            chldmeltingdetails.Show()
        Else
            chldmeltingdetails.BringToFront()
        End If

    End Sub

    Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MELTING_TOOL.Click

        'add meltingdetails
        If (chldmeltingdetails.IsMdiChild = False) Then
            If chldmeltingdetails.IsDisposed = True Then
                chldmeltingdetails = New MeltingDetails
            End If
            chldmeltingdetails.MdiParent = Me
            chldmeltingdetails.Show()
        Else
            chldmeltingdetails.BringToFront()
        End If

    End Sub

    Private Sub AddNewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TAXADD.Click

        'add taxmaster
        If (chldtaxmaster.IsMdiChild = False) Then
            If chldtaxmaster.IsDisposed = True Then
                chldtaxmaster = New taxmaster
            End If
            chldtaxmaster.MdiParent = Me
            chldtaxmaster.Show()
        Else
            chldtaxmaster.BringToFront()
        End If

    End Sub

    Private Sub EditTax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TAXEDIT.Click

        'add taxdetails
        If (chldtaxdetails.IsMdiChild = False) Then
            If chldtaxdetails.IsDisposed = True Then
                chldtaxdetails = New Taxdetails
            End If
            chldtaxdetails.MdiParent = Me
            chldtaxdetails.Show()
        Else
            chldtaxdetails.BringToFront()
        End If
    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RECEIPT_TOOL.Click
        ''add voucherdetails
        'If (chldvoucherdetails.IsMdiChild = False) Then
        '    If chldvoucherdetails.IsDisposed = True Then
        '        chldvoucherdetails = New Voucherdetails
        '    End If
        '    frminvoicemaster = False
        '    frmdailykhata = False
        '    frmrecieptmaster = True
        '    chldvoucherdetails.MdiParent = Me
        '    chldvoucherdetails.Show()
        'Else

        '    chldvoucherdetails.BringToFront()
        'End If
        Try
            Dim OBJVOUCHER As New Voucherdetails
            OBJVOUCHER.MdiParent = Me
            OBJVOUCHER.FRMSTRING = "RECEIPT"
            OBJVOUCHER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ISSUE_TOOL.Click
        ''add voucherdetails
        'If (chldvoucherdetails.IsMdiChild = False) Then
        '    If chldvoucherdetails.IsDisposed = True Then
        '        chldvoucherdetails = New Voucherdetails
        '    End If
        '    frminvoicemaster = True
        '    frmrecieptmaster = False
        '    frmdailykhata = False

        '    chldvoucherdetails.MdiParent = Me
        '    chldvoucherdetails.Show()
        'Else
        '    chldvoucherdetails.BringToFront()
        'End If
        Try
            Dim OBJVOUCHER As New Voucherdetails
            OBJVOUCHER.MdiParent = Me
            OBJVOUCHER.FRMSTRING = "ISSUE"
            OBJVOUCHER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReceiptVoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RECEIPT_MASTER.Click

        ''add voucherdetails
        'If (chldvoucherdetails.IsMdiChild = False) Then
        '    If chldvoucherdetails.IsDisposed = True Then
        '        chldvoucherdetails = New Voucherdetails
        '    End If
        '    frmdailykhata = False
        '    frminvoicemaster = False
        '    frmrecieptmaster = True

        '    chldvoucherdetails.MdiParent = Me
        '    chldvoucherdetails.Show()
        'Else
        '    chldvoucherdetails.BringToFront()
        'End If
        Try
            Dim OBJVOUCHER As New Voucherdetails
            OBJVOUCHER.MdiParent = Me
            OBJVOUCHER.FRMSTRING = "RECEIPT"
            OBJVOUCHER.Show()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub InvoiceVoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ISSUE_MASTER.Click
        ''add voucherdetails
        'If (chldvoucherdetails.IsMdiChild = False) Then
        '    If chldvoucherdetails.IsDisposed = True Then
        '        chldvoucherdetails = New Voucherdetails
        '    End If
        '    frminvoicemaster = True
        '    frmrecieptmaster = False
        '    frmdailykhata = False

        '    chldvoucherdetails.MdiParent = Me
        '    chldvoucherdetails.Show()
        'Else
        '    chldvoucherdetails.BringToFront()
        'End If
        Try
            Dim OBJVOUCHER As New Voucherdetails
            OBJVOUCHER.MdiParent = Me
            OBJVOUCHER.FRMSTRING = "ISSUE"
            OBJVOUCHER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ProcessMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PROCESS_MASTER.Click
        'add process
        If (chldprocess.IsMdiChild = False) Then
            If chldprocess.IsDisposed = True Then
                chldprocess = New processmaster
            End If
            chldprocess.MdiParent = Me
            chldprocess.Show()
        Else
            chldprocess.BringToFront()
        End If
    End Sub

    Private Sub ManufacturingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MFG_MASTER.Click

        'add mfgdetails
        If (chldmfgdetails.IsMdiChild = False) Then
            If chldmfgdetails.IsDisposed = True Then
                chldmfgdetails = New Manufacturingdetails
            End If
            chldmfgdetails.MdiParent = Me
            chldmfgdetails.Show()
        Else
            chldmfgdetails.BringToFront()
        End If

    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MFG_TOOL.Click

        'add mfgdetails
        If (chldmfgdetails.IsMdiChild = False) Then
            If chldmfgdetails.IsDisposed = True Then
                chldmfgdetails = New Manufacturingdetails
            End If
            chldmfgdetails.MdiParent = Me
            chldmfgdetails.Show()
        Else
            chldmfgdetails.BringToFront()
        End If

    End Sub

    Private Sub DailyKhataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DAILYKHATA_MASTER.Click
        frmdailykhata = True
        'add dailykhata
        If (chlddailykhata.IsMdiChild = False) Then
            If chlddailykhata.IsDisposed = True Then
                chlddailykhata = New dailykhata
            End If
            chlddailykhata.MdiParent = Me
            chlddailykhata.Show()
        Else
            chlddailykhata.BringToFront()
        End If

    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DAILYKHATA_TOOL.Click
        frmdailykhata = True

        'add dailykhata
        If (chlddailykhata.IsMdiChild = False) Then
            If chlddailykhata.IsDisposed = True Then
                chlddailykhata = New dailykhata
            End If
            chlddailykhata.MdiParent = Me
            chlddailykhata.Show()
        Else
            chlddailykhata.BringToFront()
        End If

    End Sub

    Private Sub AddNewSalesMenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALESMANADD.Click
        'add Drivermaster
        If (chldSalesmenmaster.IsMdiChild = False) Then
            If chldSalesmenmaster.IsDisposed = True Then
                chldSalesmenmaster = New salesmenmaster
            End If
            chldSalesmenmaster.MdiParent = Me
            chldSalesmenmaster.Show()
        Else
            chldSalesmenmaster.BringToFront()
        End If
    End Sub

    Private Sub EditExistingSalesMenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALESMANEDIT.Click
        If (chldsalesmendetails.IsMdiChild = False) Then
            If chldsalesmendetails.IsDisposed = True Then
                chldsalesmendetails = New salesmendetails
            End If
            chldsalesmendetails.MdiParent = Me
            chldsalesmendetails.Show()
        Else
            chldsalesmendetails.BringToFront()
        End If
    End Sub

    Private Sub TrialBalanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBWTREPORT.Click
        Try
            Dim OBJTB As New TB
            OBJTB.MdiParent = Me
            OBJTB.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StocksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STOCKS.Click
        frmstring = ""
        If (chldstockfilter.IsMdiChild = False) Then
            If chldstockfilter.IsDisposed = True Then
                chldstockfilter = New StockFilter
            End If
            chldstockfilter.MdiParent = Me
            chldstockfilter.Show()
        Else
            chldstockfilter.BringToFront()
        End If
    End Sub

    Private Sub AverageSalePurchaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AVGSALEPUR.Click
        frmavgsalepur = True
        frmpartyitemwast = False
        frmmfgvaccum = False
        frmmfgprocessreport = False
        frmsamplereport = False

        If (chldbasicfilter.IsMdiChild = False) Then
            If chldbasicfilter.IsDisposed = True Then
                chldbasicfilter = New basicfilter
            End If
            chldbasicfilter.MdiParent = Me
            chldbasicfilter.Show()
        Else
            chldbasicfilter.BringToFront()
        End If
    End Sub

    Private Sub PartyWastageReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PARTYWASTAGE.Click
        frmavgsalepur = False
        frmpartyitemwast = True
        frmmfgvaccum = False
        frmmfgprocessreport = False
        frmsamplereport = False

        If (chldbasicfilter.IsMdiChild = False) Then
            If chldbasicfilter.IsDisposed = True Then
                chldbasicfilter = New basicfilter
            End If
            chldbasicfilter.MdiParent = Me
            chldbasicfilter.Show()
        Else
            chldbasicfilter.BringToFront()
        End If
    End Sub

    Private Sub SalesMenWiseSaleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesMenWiseSaleToolStripMenuItem.Click
        If (chldsalesmenfilter.IsMdiChild = False) Then
            If chldsalesmenfilter.IsDisposed = True Then
                chldsalesmenfilter = New KarigarFilter
            End If
            chldsalesmenfilter.MdiParent = Me
            chldsalesmenfilter.Show()
        Else
            chldsalesmenfilter.BringToFront()
        End If
    End Sub

    Private Sub WastageReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WASTAGEREPORT.Click
        frmmfgloss = False
        frmmfgwastage = True
        If (chldmfgfilter.IsMdiChild = False) Then
            If chldmfgfilter.IsDisposed = True Then
                chldmfgfilter = New mfgfilter
            End If
            chldmfgfilter.MdiParent = Me
            chldmfgfilter.Show()
        Else
            chldmfgfilter.BringToFront()
        End If
    End Sub

    Private Sub MfgLossReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LOSSREPORT.Click
        frmmfgloss = True
        frmmfgwastage = False
        If (chldmfgfilter.IsMdiChild = False) Then
            If chldmfgfilter.IsDisposed = True Then
                chldmfgfilter = New mfgfilter
            End If
            chldmfgfilter.MdiParent = Me
            chldmfgfilter.Show()
        Else
            chldmfgfilter.BringToFront()
        End If
    End Sub

    Private Sub LedgerAccountsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LEDGERREPORT.Click
        If (chlddailykhatafilter.IsMdiChild = False) Then
            If chlddailykhatafilter.IsDisposed = True Then
                chlddailykhatafilter = New dailykhatafilter
            End If
            chlddailykhatafilter.MdiParent = Me
            chlddailykhatafilter.Show()
        Else
            chlddailykhatafilter.BringToFront()
        End If
    End Sub

    Private Sub VaccumReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VACCUMREPORT.Click
        frmavgsalepur = False
        frmpartyitemwast = False
        frmmfgvaccum = True
        frmmfgprocessreport = False
        frmsamplereport = False

        If (chldbasicfilter.IsMdiChild = False) Then
            If chldbasicfilter.IsDisposed = True Then
                chldbasicfilter = New basicfilter
            End If
            chldbasicfilter.MdiParent = Me
            chldbasicfilter.Show()
        Else
            chldbasicfilter.BringToFront()
        End If
    End Sub

    Private Sub ProcessReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PROCESSREPORT.Click
        Try
            Dim OBJRPT As New ProcessGridReport
            OBJRPT.MdiParent = Me
            OBJRPT.Show()
            'If ClientName = "JAINAM" Then
            '    frmavgsalepur = False
            '    frmpartyitemwast = False
            '    frmmfgvaccum = False
            '    frmmfgprocessreport = True
            '    frmsamplereport = False

            '    If (chldbasicfilter.IsMdiChild = False) Then
            '        If chldbasicfilter.IsDisposed = True Then
            '            chldbasicfilter = New basicfilter
            '        End If
            '        chldbasicfilter.MdiParent = Me
            '        chldbasicfilter.Show()
            '    Else
            '        chldbasicfilter.BringToFront()
            '    End If
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SampleReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAMPLEREPORT.Click
        frmavgsalepur = False
        frmpartyitemwast = False
        frmmfgvaccum = False
        frmmfgprocessreport = False
        frmsamplereport = True

        If (chldbasicfilter.IsMdiChild = False) Then
            If chldbasicfilter.IsDisposed = True Then
                chldbasicfilter = New basicfilter
            End If
            chldbasicfilter.MdiParent = Me
            chldbasicfilter.Show()
        Else
            chldbasicfilter.BringToFront()
        End If
    End Sub

    Private Sub ItemWiseStockReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITEMSTOCK.Click
        frmstring = "IPreport"
        If (chldstockfilter.IsMdiChild = False) Then
            If chldstockfilter.IsDisposed = True Then
                chldstockfilter = New StockFilter
            End If
            chldstockfilter.MdiParent = Me
            chldstockfilter.Show()
        Else
            chldstockfilter.BringToFront()
        End If
    End Sub

    Private Sub StockSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STOCKSUMMARY.Click
        Try
            Dim OBJSTOCKSUMMARY As New StockSummary
            OBJSTOCKSUMMARY.MdiParent = Me
            OBJSTOCKSUMMARY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CustomerWiseMeltingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerWiseMeltingToolStripMenuItem.Click
        Try
            Dim OBJCUS As New CustomerWiseMelting
            OBJCUS.MdiParent = Me
            OBJCUS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub KarigarAccountReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KARIGARREPORT.Click
        Try
            Dim OBJKARIGAR As New KarigarFilter
            OBJKARIGAR.MdiParent = Me
            OBJKARIGAR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DATATRANSFER_MASTER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DATATRANSFER_MASTER.Click
        Dim OBJ As New YearTansfer
        OBJ.MdiParent = Me
        OBJ.Show()
    End Sub

    Private Sub ORDERADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SOADD.Click
        Try
            Dim OBJ As New OrderMaster
            OBJ.MdiParent = Me
            OBJ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ORDEREDIT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SOEDIT.Click
        Try
            Dim OBJ As New OrderDetails
            OBJ.MdiParent = Me
            OBJ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LabourWiseDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabourWiseDetailsToolStripMenuItem.Click
        Try
            Dim OBJ As New KarigarWiseLabour
            OBJ.MdiParent = Me
            OBJ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewSizeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SIZEADD.Click
        Try
            Dim OBJ As New SizeMaster
            OBJ.MdiParent = Me
            OBJ.FRMSTRING = "SIZE"
            OBJ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SIZEEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SIZEEDIT.Click
        Try
            Dim OBJ As New SizeDetails
            OBJ.MdiParent = Me
            OBJ.FRMSTRING = "SIZE"
            OBJ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SHAPEADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SHAPEADD.Click
        Try
            Dim OBJ As New SizeMaster
            OBJ.MdiParent = Me
            OBJ.FRMSTRING = "SHAPE"
            OBJ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SHAPEEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SHAPEEDIT.Click
        Try
            Dim OBJ As New SizeDetails
            OBJ.MdiParent = Me
            OBJ.FRMSTRING = "SHAPE"
            OBJ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub COLORADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COLORADD.Click
        Try
            Dim OBJ As New SizeMaster
            OBJ.MdiParent = Me
            OBJ.FRMSTRING = "COLOR"
            OBJ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub COLOREDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COLOREDIT.Click
        Try
            Dim OBJ As New SizeDetails
            OBJ.MdiParent = Me
            OBJ.FRMSTRING = "COLOR"
            OBJ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MATERIALRECADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MATERIALRECADD.Click
        Try
            Dim OBJ As New MaterialReceipt
            OBJ.MdiParent = Me
            OBJ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MATERIALRECEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MATERIALRECEDIT.Click
        Try
            Dim OBJ As New MaterialReceiptDetails
            OBJ.MdiParent = Me
            OBJ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PREPOLISH_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PREPOLISH_TOOL.Click
        Try
            Dim OBJ As New PrePolish
            OBJ.MdiParent = Me
            OBJ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CASTINGADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim OBJCAST As New Casting
            OBJCAST.MdiParent = Me
            OBJCAST.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CASTINGEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim OBJCAST As New CastingDetails
            OBJCAST.MdiParent = Me
            OBJCAST.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MATERIALRETADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MATERIALRETADD.Click
        Try
            Dim OBJ As New MaterialReturn
            OBJ.MdiParent = Me
            OBJ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MATERIALRETEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MATERIALRETEDIT.Click
        Try
            Dim OBJ As New MaterialReturnDetails
            OBJ.MdiParent = Me
            OBJ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FILLINGADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FILLINGADD.Click
        Try
            Dim OBJ As New Filling
            OBJ.MdiParent = Me
            OBJ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FILLINGEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FILLINGEDIT.Click
        Try
            Dim OBJ As New FillingDetails
            OBJ.MdiParent = Me
            OBJ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FILLING_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FILLING_TOOL.Click
        Try
            Dim OBJ As New Filling
            OBJ.MdiParent = Me
            OBJ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StockOnHandToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STOCKONHAND.Click
        Try
            Dim OBJ As New StockOnHand
            OBJ.MdiParent = Me
            OBJ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LOTREPORT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LOTREPORT.Click
        Try
            Dim OBJLAB As New LabReport
            OBJLAB.MdiParent = Me
            OBJLAB.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FactIssueDiffReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FACISSDIFFREPORT.Click
        Try
            Dim OBJFILTER As New basicfilter
            OBJFILTER.FRMSTRING = "FACTISSDIFF"
            OBJFILTER.MdiParent = Me
            OBJFILTER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OrderReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ORDERREPORT.Click
        Try
            Dim OBJORDER As New OrderFilter
            OBJORDER.MdiParent = Me
            OBJORDER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub USERADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USERADD.Click
        Try
            Dim OBJUSER As New UserMaster
            OBJUSER.MdiParent = Me
            OBJUSER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub USEREDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USEREDIT.Click
        Try
            Dim OBJUSER As New UserDetails
            OBJUSER.MdiParent = Me
            OBJUSER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BLOCKBACKDATE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BLOCKBACKDATE.Click
        Try
            Dim OBJBLOCK As New BlockDate
            OBJBLOCK.MdiParent = Me
            OBJBLOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BLOCKDATEPASS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BLOCKDATEPASS.Click
        Try
            Dim OBJBLOCK As New BlockDatePassword
            OBJBLOCK.MdiParent = Me
            OBJBLOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LABFILTER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LABFILTER.Click
        Try
            Dim OBJLAB As New LabFilter
            OBJLAB.MdiParent = Me
            OBJLAB.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MERGEITEM_MASTER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MERGEITEM_MASTER.Click
        Try
            Dim OBJMERGE As New MergeItem
            OBJMERGE.MdiParent = Me
            OBJMERGE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StockWithTrialBalanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STOCKWITHTB.Click
        Try
            Dim OBJSTOCK As New clsReportDesigner("Stock With Trial Balance", System.AppDomain.CurrentDomain.BaseDirectory & "Stock With Trial Balance.xlsx", 2)
            OBJSTOCK.STOCKTB_EXCEL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StockWithKarigarWastageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STOCKWITHKARIGARWASTAGE.Click
        Try
            Dim OBJSTOCK As New StockWithKarigarWastage
            OBJSTOCK.MdiParent = Me
            OBJSTOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JOURNALADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JOURNALADD.Click
        Try
            Dim OBJJV As New JournalVoucher
            OBJJV.MdiParent = Me
            OBJJV.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JOURNALEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JOURNALEDIT.Click
        Try
            Dim OBJJV As New JournalVoucherDetails
            OBJJV.MdiParent = Me
            OBJJV.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JV_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JV_TOOL.Click
        Try
            Dim OBJJV As New JournalVoucher
            OBJJV.MdiParent = Me
            OBJJV.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CASHADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CASHRECADD.Click
        Try
            Dim OBJCASH As New CashBook
            OBJCASH.MdiParent = Me
            OBJCASH.FRMSTRING = "CASHREC"
            OBJCASH.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CASHEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CASHRECEDIT.Click
        Try
            Dim OBJCASH As New CashBookDetails
            OBJCASH.FRMSTRING = "CASHREC"
            OBJCASH.MdiParent = Me
            OBJCASH.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CASH_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CASHREC_TOOL.Click
        Try
            Dim OBJCASH As New CashBook
            OBJCASH.FRMSTRING = "CASHREC"
            OBJCASH.MdiParent = Me
            OBJCASH.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CASHISSUE_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CASHISSUE_TOOL.Click
        Try
            Dim OBJCASH As New CashBook
            OBJCASH.FRMSTRING = "CASHISSUE"
            OBJCASH.MdiParent = Me
            OBJCASH.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CASHISSUEADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CASHISSUEADD.Click
        Try
            Dim OBJCASH As New CashBook
            OBJCASH.FRMSTRING = "CASHISSUE"
            OBJCASH.MdiParent = Me
            OBJCASH.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CASHISSUEEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CASHISSUEEDIT.Click
        Try
            Dim OBJCASH As New CashBookDetails
            OBJCASH.FRMSTRING = "CASHISSUE"
            OBJCASH.MdiParent = Me
            OBJCASH.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PARTYWASTAGEREPORT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PARTYWASTAGEREPORT.Click
        Try
            If ClientName = "SHASHAWAT" Or ClientName = "SANGAM" Then
                Dim OBJPARTYWASTAGE As New PartyWastageFilter
                OBJPARTYWASTAGE.MdiParent = Me
                OBJPARTYWASTAGE.Show()
            Else
                Dim OBJPARTYWASTAGE As New PartyWiseWastageReport
                OBJPARTYWASTAGE.MdiParent = Me
                OBJPARTYWASTAGE.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PARTYSCRAPREPORT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PARTYSCRAPREPORT.Click
        Try
            Dim OBJPARTYSCRAP As New PartyWiseScrapReport
            OBJPARTYSCRAP.MdiParent = Me
            OBJPARTYSCRAP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SALARYADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALARYADD.Click
        Try
            Dim OBJSAL As New Salary
            OBJSAL.MdiParent = Me
            OBJSAL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SALARYEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALARYEDIT.Click
        Try
            Dim OBJSAL As New SalaryDetails
            OBJSAL.MdiParent = Me
            OBJSAL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TBAMTREPORT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBAMTREPORT.Click
        Try
            Dim OBJTB As New TBAmount
            OBJTB.MdiParent = Me
            OBJTB.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TBWTAMTREPORT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBWTAMTREPORT.Click
        Try
            Dim OBJTB As New TBWtAmount
            OBJTB.MdiParent = Me
            OBJTB.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BackupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupToolStripMenuItem.Click
        Try
            If ClientName = "SHASHAWAT" Then
                Dim sourcefilepath As String = ""
                If Directory.Exists("ftp://133.233.25.68/Database " & Now.Date.Day.ToString & "-" & Now.Date.Month.ToString & "-" & Now.Date.Year.ToString) = False Then Directory.CreateDirectory("ftp://133.233.25.68/Database " & Now.Date.Day.ToString & "-" & Now.Date.Month.ToString & "-" & Now.Date.Year.ToString)
                Dim ftpurl As String = "ftp://133.233.25.68/foldername/foldername"
                Dim ftpusername As String = "Administrator"
                Dim ftppassword As String = "RAMAN@123"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SETTINGADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SETTINGADD.Click
        Try
            Dim OBJCAST As New KarigarAccountMaster
            OBJCAST.MdiParent = Me
            OBJCAST.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SETTING_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SETTING_TOOL.Click
        Try
            Dim OBJCAST As New KarigarAccountMaster
            OBJCAST.MdiParent = Me
            OBJCAST.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SETTINGREPORT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SETTINGREPORT.Click
        Try
            Dim OBJSETTING As New SettingFilter
            OBJSETTING.MdiParent = Me
            OBJSETTING.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub KarigarItemWiseLoddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KarigarItemWiseLoddToolStripMenuItem.Click
        Try
            Dim OBJKARIGAR As New KarigarItemWiseLoss
            OBJKARIGAR.MdiParent = Me
            OBJKARIGAR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DEPARTMENTADD_Click(sender As Object, e As EventArgs) Handles DEPARTMENTADD.Click
        Try
            Dim OBJ As New SizeMaster
            OBJ.MdiParent = Me
            OBJ.FRMSTRING = "DEPARTMENT"
            OBJ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DEPARTMENTEDIT_Click(sender As Object, e As EventArgs) Handles DEPARTMENTEDIT.Click
        Try
            Dim OBJ As New SizeDetails
            OBJ.MdiParent = Me
            OBJ.FRMSTRING = "DEPARTMENT"
            OBJ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub STOCKTRANSFERADD_Click(sender As Object, e As EventArgs) Handles STOCKTRANSFERADD.Click
        Try
            Dim OBJSTOCK As New StockTransferMaster
            OBJSTOCK.MdiParent = Me
            OBJSTOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub STOCKTRANSFEREDIT_Click(sender As Object, e As EventArgs) Handles STOCKTRANSFEREDIT.Click
        Try
            Dim OBJSTOCK As New StockTransferDetails
            OBJSTOCK.MdiParent = Me
            OBJSTOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub STOCKTRANSFER_TOOL_Click(sender As Object, e As EventArgs)
        Try
            Dim OBJSTOCK As New StockTransferMaster
            OBJSTOCK.MdiParent = Me
            OBJSTOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ACCEPTSTOCK_TOOL_Click(sender As Object, e As EventArgs)
        Try
            Dim OBJSTOCK As New StockTransferAccept
            OBJSTOCK.MdiParent = Me
            OBJSTOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ChangeUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeUserToolStripMenuItem.Click
        Try
            'close all child forms
            Dim frm As Form
            For Each frm In MdiChildren
                frm.Close()
            Next

            Me.Dispose()
            LoginForm.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        LBLPENDING.Left = LBLPENDING.Left - 1
        LBLPENDING.Top = StatusStrip2.Top + 2

        If LBLPENDING.Left < 0 - LBLPENDING.Width Then
            'Timer1.Enabled = False
            SCROLLERS()
            LBLPENDING.Left = Me.Width
        End If
        'Me.Refresh()
    End Sub

    Private Sub MDIMain_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName <> "SHASHAWAT" And ClientName <> "SANGAM" Then
                Timer1.Enabled = False
                LBLPENDING.Visible = False
                DAYTRANSFER_MASTER.Enabled = False
            End If

            If ClientName = "MONOGRAM" Then
                ITEM_TOOL.Visible = False
                ITEM_TOOLSTRIP.Visible = False
                RECEIPT_TOOL.Visible = False
                RECEIPT_TOOLSTRIP.Visible = False
                ISSUE_TOOL.Visible = False
                ISSUE_TOOLSTRIP.Visible = False
                MELTING_TOOL.Visible = False
                MELTING_TOOLSTRIP.Visible = False
                MFG_TOOL.Visible = False
                MFG_TOOLSTRIP.Visible = False
                JV_TOOL.Visible = False
                JV_TOOLSTRIP.Visible = False
                FILLING_TOOL.Visible = False
                FILLING_TOOLSTRIP.Visible = False
                PREPOLISH_TOOL.Visible = False
                PREPOLISH_TOOLSTRIP.Visible = False
                SETTING_TOOL.Visible = False
                SETTING_TOOLSTRIP.Visible = False

                DAILYKHATA_MASTER.Visible = False
                RECEIPT_MASTER.Visible = False
                ISSUE_MASTER.Visible = False
                JOURNAL_MASTER.Visible = False
                SALARY_MASTER.Visible = False
                SALARY_TOOLSEPERATOR.Visible = False
                MELTING_MASTER.Visible = False
                MFG_MASTER.Visible = False
                STOCKTRANSFER_MASTER.Visible = False
                STOCKTRANSFER_TOOLSEPERATOR.Visible = False

            End If

            If HIDEMFG = True Then
                MELTING_TOOL.Visible = False
                MELTING_TOOLSTRIP.Visible = False
                MFG_TOOL.Visible = False
                MFG_TOOLSTRIP.Visible = False
                MELTING_MASTER.Visible = False
                MELTING_MASTER.Enabled = False
                MFG_MASTER.Visible = False
                MFG_MASTER.Enabled = False
                PROCESS_MASTER.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub POLISHADD_Click(sender As Object, e As EventArgs) Handles PREPOLISHADD.Click
        Try
            Dim OBJ As New PrePolish
            OBJ.MdiParent = Me
            OBJ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub POLISHEDIT_Click(sender As Object, e As EventArgs) Handles PREPOLISHEDIT.Click
        Try
            Dim OBJ As New PrePolishDetails
            OBJ.MdiParent = Me
            OBJ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PROCESSSUMM_REPORT_Click(sender As Object, e As EventArgs) Handles PROCESSSUMM_REPORT.Click
        Try
            Dim OBJPROCESS As New ProcessSummGridReport
            OBJPROCESS.MdiParent = Me
            OBJPROCESS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHANGEGLOBALDATE_Click(sender As Object, e As EventArgs) Handles CHANGEGLOBALDATE.Click
        Try
            Dim OBJDT As New ChangeDate
            OBJDT.MdiParent = Me
            OBJDT.FRMSTRING = "GLOBALDATE"
            OBJDT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MDIMain_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            'THIS CODE IS USED TO ERASE ALL THE EXISTING DATA FROM THE SOFTWARE
            If (e.Alt = True And e.Control = True And e.KeyCode = Keys.N) And (e.Alt = True AndAlso e.Control = True AndAlso e.KeyCode = Keys.K) And (e.Alt = True AndAlso e.Control = True AndAlso e.KeyCode = Keys.D) Then
                cmd = New OleDbCommand("delete from ACCOUNTMASTER", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from BHAVCUTMASTER", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from CASHENTRY", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from CASTING", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from CUSTOMERWASTAGE", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from DATEPASS", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from FILLING", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from ITEMMASTER", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from ITEMMASTER_DESC", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from ITEMSTOCK", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from JOURNALMASTER", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from KARIGARISSUE", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from KARIGARLOSSDETAILS", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from LABOURDETAILS", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from LABREPORT", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from LEDGERMASTER", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from LEDGERSUMM", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from LOTFAIL", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from MELTINGMASTER", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from MFGBARCODE", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from MFGDESCRIPTION", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from MFGDIRECTISSUE", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from MFGMASTER", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from MFGSTOCK", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from ORDERMASTER", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from ORDERREC", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from ORDERRETURN", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from PREPOLISH", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from PROCESSMASTER", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from RECEIPTDESCRIPTION", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from SALARYENTRY", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from SETTING", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from SPLITMASTER", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from STOCKTRANSFER", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from TEMPISSUE", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from TEMPJAMA", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from TEMPKARIGARISSUE", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from TEMPSPLIT", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from TEMPSTOCK", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from TEMPTB", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from TEMPTBWTAMT", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

                cmd = New OleDbCommand("delete from VOUCHERS", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()


            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub STOCKWITHKARIGARWASTAGEFINE_Click(sender As Object, e As EventArgs) Handles STOCKWITHKARIGARWASTAGEFINE.Click
        Try
            Dim OBJSTOCK As New StockWithKarigarWastageFine
            OBJSTOCK.MdiParent = Me
            OBJSTOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DAYTRANSFER_MASTER_Click(sender As Object, e As EventArgs) Handles DAYTRANSFER_MASTER.Click
        Try
            Dim OBJ As New DayTransfer
            OBJ.MdiParent = Me
            OBJ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LABELLINGADD_Click(sender As Object, e As EventArgs) Handles LABELLINGADD.Click
        Try
            Dim OBJLABEL As New Labelling
            OBJLABEL.MdiParent = Me
            OBJLABEL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LABELLINGEDIT_Click(sender As Object, e As EventArgs) Handles LABELLINGEDIT.Click
        Try
            Dim OBJLABEL As New LabellingDetails
            OBJLABEL.MdiParent = Me
            OBJLABEL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
