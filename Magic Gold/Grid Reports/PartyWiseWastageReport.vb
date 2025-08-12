
Imports System.Data.OleDb

Public Class PartyWiseWastageReport

    Sub FILLGRID()
        Try
            Dim DT As New DataTable
            cmd = New OleDbCommand("SELECT * FROM PARTYWISEWASTAGEREPORT", conn)
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            da = New OleDbDataAdapter(cmd)
            da.Fill(DT)
            gridStock.DataSource = DT
            da.Dispose()
            DT.Dispose()
            tempconn.Close()
            tempcmd.Dispose()

        Catch ex As Exception
            Throw ex
        End Try
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