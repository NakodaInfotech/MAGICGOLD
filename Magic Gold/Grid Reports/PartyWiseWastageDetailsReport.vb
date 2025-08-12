
Imports System.Data.OleDb

Public Class PartyWiseWastageDetailsReport

    Public WHERECLAUSE As String = ""

    Sub FILLGRID()
        Try
            Dim DT As New DataTable
            Dim DTISSUE As New DataTable
            cmd = New OleDbCommand("SELECT LEDGERDETAILVIEW.ACCOUNT_DATE AS [DATE], LEDGERDETAILVIEW.ACCOUNT_LEDGERCODE AS NAME, LEDGERDETAILVIEW.Item_Code AS ITEMCODE, LEDGERDETAILVIEW.ACCOUNT_grosswt AS GROSSWT, LEDGERDETAILVIEW.ACCOUNT_Purity AS PURITY, LEDGERDETAILVIEW.ACCOUNT_Wastage AS WASTAGE, LEDGERDETAILVIEW.ACCOUNT_nettwt AS NETTWT, LEDGERDETAILVIEW.WastageWt AS WASTAGEWT FROM LEDGERDETAILVIEW WHERE LEDGERDETAILVIEW.ACCOUNT_Wastage > 0 AND LEDGERDETAILVIEW.account_balorjamaorpaid = 'Jama' " & WHERECLAUSE, conn)
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            da = New OleDbDataAdapter(cmd)
            da.Fill(DT)
            gridStock.DataSource = DT
            da.Dispose()
            DT.Dispose()
            tempconn.Close()
            tempcmd.Dispose()

            cmd = New OleDbCommand("SELECT LEDGERDETAILVIEW.ACCOUNT_DATE AS [DATE], LEDGERDETAILVIEW.ACCOUNT_LEDGERCODE AS NAME, LEDGERDETAILVIEW.Item_Code AS ITEMCODE, LEDGERDETAILVIEW.ACCOUNT_grosswt AS GROSSWT, LEDGERDETAILVIEW.ACCOUNT_Purity AS PURITY, LEDGERDETAILVIEW.ACCOUNT_Wastage AS WASTAGE, LEDGERDETAILVIEW.ACCOUNT_nettwt AS NETTWT, LEDGERDETAILVIEW.WastageWt AS WASTAGEWT FROM LEDGERDETAILVIEW WHERE LEDGERDETAILVIEW.ACCOUNT_Wastage > 0 AND LEDGERDETAILVIEW.account_balorjamaorpaid = 'Balance'" & WHERECLAUSE, conn)
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            da = New OleDbDataAdapter(cmd)
            da.Fill(DTISSUE)
            GRIDISSUESTOCK.DataSource = DTISSUE
            da.Dispose()
            DTISSUE.Dispose()
            tempconn.Close()
            tempcmd.Dispose()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PartyWiseWastageDetailsReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub PartyWiseWastageReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()

    End Sub
End Class