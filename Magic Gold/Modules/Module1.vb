Imports System.Data.OleDb
Imports System.Runtime.InteropServices

Module Module1

    Public conn, tempconn, OGCONN As New OleDbConnection
    Public cmd, tempcmd As New OleDbCommand
    Public da As New OleDbDataAdapter
    Public dr, tempdr As OleDbDataReader
    Public dt As DataTable
    Public ClientName As String = "MIMARA"

    '************************************ NEW ************************

    Sub openconn(ByVal databasename As String)

        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\Database\" & databasename & "\" & databasename & ".mdb;Jet OLEDB:Database Password= 1902")
        conn.Open()

        If OGCONN.State = ConnectionState.Open Then
            OGCONN.Close()
        End If
        OGCONN.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\Database\MagicGold\MagicGold.mdb;Jet OLEDB:Database Password= 1902")
        OGCONN.Open()

        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\Database\" & databasename & "\" & databasename & ".mdb;Jet OLEDB:Database Password= 1902")
        tempconn.Open()

    End Sub

    'Public chldsettlement As New settlementdate                    'for settlement
    Public chldvendormaster As New ACCOUNTMASTER                     'for vendormaster
    Public chldvendordetails As New ACCOUNTDETAILS                   'for vendordetails
    Public chldSalesmenmaster As New salesmenmaster                     'for vendormaster
    Public chldsalesmendetails As New salesmendetails                   'for vendordetails

    Public chlditemmaster As New Itemmaster                         'for itemmaster
    Public chldgroupdetails As New groupdetails                     'for groupdetails
    Public chldgroupmaster As New groupmaster                       'for groupmaster
    Public chldareadetails As New areadetails                       'for areadetails
    Public chldareamaster As New areamaster                         'for areamaster
    Public chldlogin As New LoginForm                               'for loginform
    Public chldhome As New Home                                     'for home
    Public chldcmpmaster As New companymaster                       'for company
    Public chldcmppassword As New companypasswd                     'for cmppassword
    Public chldyearmaster As New yearmaster                         'for yaermaster
    Public chldcmpdetails As New companydetails                     'for companydetails
    Public chldmeltingdetails As New MeltingDetails                 'for meltingdetails
    Public chldmelting As New Melting                               'for melting
    Public chldtaxmaster As New taxmaster                           'for taxmaster
    Public chldtaxdetails As New Taxdetails                         'for taxdetails
    Public chldvouchers As New vouchers                             'for vouchers
    Public chldvoucherdetails As New Voucherdetails                 'for voucherdetails
    Public chldprocess As New processmaster                         'for processmaster
    Public chldmfgmaster As New Manufacturing                       'for manufacturing
    Public chldselectlotno As New Selectlotno                       'for Seelct lot No form
    Public chldmfgdetails As New Manufacturingdetails               'for manufacturingdetails
    Public chlddailykhata As New dailykhata                         'for dailykhata
    Public chldtrialbalancefilter As New trialbalancefilter
    Public chldstockfilter As New StockFilter
    Public chldbasicfilter As New basicfilter
    Public chldsalesmenfilter As New KarigarFilter
    Public chldmfgfilter As New mfgfilter
    Public chlddailykhatafilter As New dailykhatafilter
    Public chldEmail As New SendMail                                   'for sending multiple emails


    Public tempattachment As String             'used for file name for attachment
    Public fdate, tdate As Date
    Public startdate As Date                    'used for starting acc date
    Public enddate As Date                      'used for ending acc date
    Public tempname As String                   'used for name
    Public tempnameid As Integer                'used for nameid
    Public tempusername As String               'used for username
    Public tempuserid As Integer                'used for userid
    Public tempitemname As String               'used for itemname
    Public tempitemid As Integer                'used for itemid
    Public tempitemcode As String               'used for itemcode
    Public tempgroupname As String              'used for groupname
    Public tempgrouptype As String              'used for grouptype
    Public tempgroupid As Integer               'used for groupid
    Public tempareaid As Integer                'used for areaid
    Public tempcityid As Integer                'used for cityid
    Public templocation As String               'used for location
    Public tempcityname As String               'used for cityname for transport
    Public tempstateid As Integer               'used for stateid
    Public tempcountryid As Integer             'used for countryid
    Public tempkeychar As Integer               'used for keyascii
    Public tempcmpid As Integer                 'used for companyno
    Public tempyearid As Integer                'used for tempyearid
    Public tempyear As String                   'used for tempyear
    Public tempcategoryid As Integer            'used for category
    Public temptypeid As Integer                'used for itemtype
    Public tempmeltingid As Integer             'used for itemtype
    Public tempprocessname As String            'used for processname
    Public temppartno As String                 'used for partno while editing
    Public tempmfgno As Integer                 'used for mfgno
    Public temptaxname As String                'used for taxname
    'Public tempbillno As Integer                'used for voucher details (previous & Next)
    Public index As Integer                     'USED IN FUNCTIONS
    Public tempmonth As Integer                 'used for registers month
    Public tempexpname As String                'used for add grid in voucehrs
    Public templessname As String               'used for less grid in vouchers
    Public templabour As Double                 'used for labour in mfgmaster for karigar
    Public tempsalesman As String               'used for salesman
    Public frmstring As String

    Public griddoubleclick As Boolean 'used for doubleclick on grids    
    'Public edit As Boolean 'used for editing
    Public duplicate As Boolean 'used for duplication
    Public tempmsg, tempmsg1 As Integer 'used for msgbox
    Public temprow As Integer 'used for saving row no while editing grid
    Public tempimagepath As String 'used to save path of image selected in imagemaster
    Public GLOBALDATE As Date = Now.Date   'used for global date
    Public khata, account As Boolean

    Public frmareamaster As Boolean         'used for displaying aremaster when pressin areamaster in main menu
    Public frmcitymaster As Boolean         'used for displaying citymaster when pressin citymaster in main menu
    Public frmstatemaster As Boolean        'used for displaying statemaster when pressin statemaster in main menu
    Public frmcountrymaster As Boolean      'used for displaying countrymaster when pressin countrymaster in main menu
    Public frmcategorymaster As Boolean     'used for displaying categorymaster when pressin categorymaster in main menu
    Public frmtypemaster As Boolean         'used for displaying tyepmaster when pressin typemaster in main menu
    'Public frminvoicemaster As Boolean      'used for displaying invoicemaster when pressin invoicemaster in main menu
    'Public frmrecieptmaster As Boolean      'used for displaying recieptmaster when pressin recieptmaster in main menu
    Public frmdailykhata As Boolean         'used for displaying dailykhata when pressin dailykhata in main menu

    Public frmmfgwastage As Boolean         'used for displaying dailykhata when pressin dailykhata in wastagefilter
    Public frmmfgloss As Boolean            'used for displaying dailykhata when pressin dailykhata in basiffilter

    Public frmmfgvaccum As Boolean          'used for displaying dailykhata when pressin dailykhata in basicfilter
    Public frmavgsalepur As Boolean         'used for displaying average sale purchase when pressin in basicfilter
    Public frmmfgprocessreport As Boolean   'used for displaying dailykhata when pressin dailykhata in basiffilter
    Public frmsamplereport As Boolean       'used for displaying dailykhata when pressin dailykhata in basiffilter
    Public frmpartyitemwast As Boolean      'used for displaying dailykhata when pressin dailykhata in basiffilter


    Public nett, narr, gross, bullion, item, wast, purity As Boolean
    Public datet, datef As Date
    'used for common functions im module
    'used for processes in processmasyet which are used in mfg
    Public tempcol(100), tempval(100) As String
    Public tempprocess(40) As String                'used from storing mfg process
    Public tempprocessno(40) As Integer             'used from storing mfg processno
    Public tempprocessloss(40) As String            'used from storing mfg processloss
    Public tempprocessvaccum(40) As String          'used from storing mfg processvaccum
    Public tempprocesskarigar(40) As String         'used from storing mfg processkarigar
    Public tempprocessexcess(40) As String          'used from storing mfg processexcess



    'used for parts in mfg
    Public mfgprocessno(50) As Integer              'used from current mfg processno of parts
    Public tempnarration(50) As String              'used from storing narration of diff splitted parts
    Public mfgitemname(50) As String                'used from storing itemname of diff splitted completed lots/parts
    Public partname(50) As Double                   'used for storing inputwt of particular part
    Public percentinput(50) As Double               'used for storing inputpercent of particular part
    Public lotfail(50) As Boolean                   'used for storing lotfail status of particular part
    Public LOTFAILPERCENT(50) As Double             'used for storing FINAL PERCENT OF FAILED LOT'S particular part
    Public LOTFAILMERGED(50) As Boolean             'used for storing WHETHER LOTFAIL IS DONE FOR MERGING of particular part
    Public splitno As Integer                       'used for storing current splitno
    Public find, findend As Integer                 'used for find partname 
    Public tempcondition As String
    Public MFGORDERNO(50) As Integer                'used from current ORDER NO of parts
    Public MFGBARCODE(50) As String                 'used from current BARCODE NO of parts

    Public strsearch As String
    Public a1, a2, a3, a4 As String
    Public a11, a12, a13, a14 As String
    Public fromD As String
    Public toD As String


    Public i As Integer 'for loop
    Public tempcmpname, cmplegalname, cmpprop, cmpautho, cmppartner, cmppropautho, cmpcstno, cmpvatno, cmppanno, cmpadd1, cmpadd2, cmpzip, cmptel1, cmpfax, cmpemail, cmpwebsite, cmppassword, cmpdisplayedname, cmpinvinitials As String 'used for company


    Public USERID As Integer            'Used for Userid while login
    Public USERNAME As String               'User for UserName while Login
    Public CMPID As String               'User for CMPID while Login
    Public CMPNAME As String               'User for CMPNAME while Login
    Public USERRIGHTS As New DataTable          'USED FOR USER RIGHTS THROUGHOUT THE APPLICATION 
    Public ALLOWLABELLING As New Boolean
    Public HIDEMFG As Boolean = False

    Public APPLYBLOCKDATE As Boolean = False    'USED FOR BLOCKING BACKDATED ENTRIES
    Public BLOCKEDDATE As Date                  'USED FOR BLOCKING BACKDATED ENTRIES
    Public ENTRYPASSWORD As String = ""         'USED FOR STORING PASSWORD FOR CHAINGING BACKDATED ENTRIES
    Public USERDEPARTMENT As String = ""        'USED FOR STORING USER'S DEPARTMENT
    Public USERDEPARTMENTID As Integer = 0      'USED FOR STORING USER'S DEPARTMENT ID

    Public ISMASTER As Boolean = True

    ' these vars r used for .rpt to .pdf conversions
    Public ConInfo As New CrystalDecisions.Shared.TableLogOnInfo
    Public expo As New CrystalDecisions.Shared.ExportOptions
    Public oDfDopt As New CrystalDecisions.Shared.DiskFileDestinationOptions



    '*************************************** DSN ****************************************'

    'CODE TO PROGRAMMATICALLY CREATE D. S. N.
    'Module CreateDSN

    Public Declare Auto Function SQLConfigDataSource Lib "ODBCCP32.DLL" (ByVal hwndParent As Integer, ByVal fRequest As Integer, ByVal ByVallpszDriver As String, ByVal lpszAttributes As String) As Long

    Public Sub Main()

        Dim sDriver = "Microsoft Access Driver (*.mdb)"
        Dim sAttributes As New System.Text.StringBuilder
        Const ODBC_ADD_USER_DSN = 4
        Dim intResult As Long

        sAttributes.Append("DBQ=" & Application.StartupPath & "\Database\" & tempcmpname & "\" & tempcmpname & ".mdb" & Chr(0))
        sAttributes.Append("DSN=" & "MagicGold" & Chr(0))
        sAttributes.Append("Uid=Admin" & Chr(0) & "pwd=1902" & Chr(0))
        intResult = SQLConfigDataSource(0&, ODBC_ADD_USER_DSN, sDriver, sAttributes.ToString)
        sAttributes = Nothing

    End Sub 'Main

    '************************************ OLD ************************
    Public tempinvoiceno As Integer             'used for invoice
    Public tempaccountno As Integer             'used for accounts

    '***************************************** END *********************************

    'original code
    Sub insert(ByVal tablename As String, ByVal col() As String, ByVal value() As String)

        Dim i, a As Integer
        Dim q, r As String
        a = col.GetLength(0)

        q = ""
        r = ""
        For i = 0 To a - 1
            If col(i) <> "" Then
                If q = "" Then
                    q = q + col(i)
                Else
                    q = q + "," + col(i)
                End If
            End If
        Next

        'MsgBox(q)

        a = value.GetLength(0)
        For i = 0 To a - 1
            If value(i) <> "" Then
                If r = "" Then
                    r = r + value(i)
                Else
                    r = r + "," + value(i)
                End If
            End If
        Next

        'MsgBox(r)

        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        conn.Open()
        Dim cmd As New OleDbCommand("insert into " + tablename + " ( " + q + ") values (" + r + ")", conn)
        cmd.ExecuteNonQuery()
        conn.Close()
        'MsgBox("Data inserted successfully")

    End Sub

    Sub modify(ByVal tablename As String, ByVal col() As String, ByVal value() As String, ByVal condition As String)

        Dim i, a As Integer
        Dim q, r As String
        a = col.GetLength(0)

        q = ""
        r = ""
        For i = 0 To a - 1
            If col(i) <> "" Then
                If q = "" Then
                    q = q + col(i) + " = " + value(i)
                Else
                    q = q + "," + col(i) + " = " + value(i)
                End If
            End If
        Next

        'MsgBox(q)

        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        conn.Open()
        Dim cmd As New OleDbCommand("update " + tablename + " set " + q + condition, conn)
        cmd.ExecuteNonQuery()
        conn.Close()

    End Sub

    Sub INSERTOG(ByVal tablename As String, ByVal col() As String, ByVal value() As String)

        Dim i, a As Integer
        Dim q, r As String
        a = col.GetLength(0)

        q = ""
        r = ""
        For i = 0 To a - 1
            If col(i) <> "" Then
                If q = "" Then
                    q = q + col(i)
                Else
                    q = q + "," + col(i)
                End If
            End If
        Next

        'MsgBox(q)

        a = value.GetLength(0)
        For i = 0 To a - 1
            If value(i) <> "" Then
                If r = "" Then
                    r = r + value(i)
                Else
                    r = r + "," + value(i)
                End If
            End If
        Next

        'MsgBox(r)

        If OGCONN.State = ConnectionState.Open Then OGCONN.Close()
        OGCONN.Open()
        Dim cmd As New OleDbCommand("insert into " + tablename + " ( " + q + ") values (" + r + ")", OGCONN)
        cmd.ExecuteNonQuery()
        OGCONN.Close()
        'MsgBox("Data inserted successfully")

    End Sub

    Sub MODIFYOG(ByVal tablename As String, ByVal col() As String, ByVal value() As String, ByVal condition As String)

        Dim i, a As Integer
        Dim q, r As String
        a = col.GetLength(0)

        q = ""
        r = ""
        For i = 0 To a - 1
            If col(i) <> "" Then
                If q = "" Then
                    q = q + col(i) + " = " + value(i)
                Else
                    q = q + "," + col(i) + " = " + value(i)
                End If
            End If
        Next

        'MsgBox(q)

        If OGCONN.State = ConnectionState.Open Then OGCONN.Close()
        OGCONN.Open()
        Dim cmd As New OleDbCommand("update " + tablename + " set " + q + condition, OGCONN)
        cmd.ExecuteNonQuery()
        OGCONN.Close()

    End Sub

    Sub INSERTMASTERCONN(ByVal tablename As String, ByVal col() As String, ByVal value() As String, CONN As OleDbConnection)

        Dim i, a As Integer
        Dim q, r As String
        a = col.GetLength(0)

        q = ""
        r = ""
        For i = 0 To a - 1
            If col(i) <> "" Then
                If q = "" Then
                    q = q + col(i)
                Else
                    q = q + "," + col(i)
                End If
            End If
        Next

        'MsgBox(q)

        a = value.GetLength(0)
        For i = 0 To a - 1
            If value(i) <> "" Then
                If r = "" Then
                    r = r + value(i)
                Else
                    r = r + "," + value(i)
                End If
            End If
        Next

        'MsgBox(r)

        If CONN.State = ConnectionState.Open Then CONN.Close()
        CONN.Open()
        Dim cmd As New OleDbCommand("insert into " + tablename + " ( " + q + ") values (" + r + ")", CONN)
        cmd.ExecuteNonQuery()
        CONN.Close()
        'MsgBox("Data inserted successfully")

    End Sub

    Sub duplication(ByVal tablename As String, ByVal colname As String, ByVal value As String, ByVal condition As String)

        cmd = New OleDbCommand("select " & colname & " from " & tablename & " where " & colname & " = '" & value & "'" & condition, conn)
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            duplicate = True
            Exit Sub
        End If
        conn.Close()
    End Sub

    Sub DUPLICATIONOG(ByVal tablename As String, ByVal colname As String, ByVal value As String, ByVal condition As String)

        cmd = New OleDbCommand("select " & colname & " from " & tablename & " where " & colname & " = '" & value & "'" & condition, OGCONN)
        If OGCONN.State = ConnectionState.Open Then OGCONN.Close()
        OGCONN.Open()
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            duplicate = True
            Exit Sub
        End If
        OGCONN.Close()
    End Sub

    Function caps(ByVal txt As String)
        caps = StrConv(txt, VbStrConv.ProperCase)
    End Function

    Function uppercase(ByVal txt As String)
        uppercase = StrConv(txt, VbStrConv.Uppercase)
    End Function

End Module
