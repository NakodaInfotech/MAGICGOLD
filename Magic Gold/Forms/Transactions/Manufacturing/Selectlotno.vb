Imports System.Data.OleDb

Public Class Selectlotno

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub Selectlotno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.O Then       'for oPEN
                Call cmdok_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Selectlotno_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        'filling grid
        dt = New DataTable()
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()
        tempcmd = New OleDbCommand("select distinct melting_id, melting_date, melting_reqmelting, melting_output from meltingmaster where melting_mfg = False order by melting_id ", tempconn)
        da = New OleDbDataAdapter(tempcmd)
        da.Fill(dt)

        gridlotno.DataSource = dt

        gridlotno.Columns(0).HeaderText = "Lot No."
        gridlotno.Columns(0).Width = 100
        
        gridlotno.Columns(1).HeaderText = "Date"
        gridlotno.Columns(1).ReadOnly = True
        gridlotno.Columns(1).Width = 100

        gridlotno.Columns(2).HeaderText = "Melting"
        gridlotno.Columns(2).ReadOnly = True
        gridlotno.Columns(2).Width = 100
        gridlotno.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridlotno.Columns(2).DefaultCellStyle.Format = "0.00"

        gridlotno.Columns(3).HeaderText = "Gross Wt."
        gridlotno.Columns(3).ReadOnly = True
        gridlotno.Columns(3).Width = 100
        gridlotno.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridlotno.Columns(3).DefaultCellStyle.Format = "0.000"

        If gridlotno.RowCount > 0 Then gridlotno.FirstDisplayedScrollingRowIndex = gridlotno.RowCount - 1

        da.Dispose()
        dt.Dispose()
        tempconn.Close()
        tempcmd.Dispose()
        
    End Sub

    Private Sub gridlotno_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridlotno.CellDoubleClick
        If gridlotno.Item(0, e.RowIndex).Value <> Nothing Then
            chldmfgmaster.txtlotno.Text = gridlotno.Item(0, e.RowIndex).Value
            Me.Close()
        End If
    End Sub

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        If gridlotno.Item(0, gridlotno.CurrentRow.Index).Value <> Nothing Then
            chldmfgmaster.txtlotno.Text = gridlotno.Item(0, gridlotno.CurrentRow.Index).Value.ToString
            Me.Close()
        End If
    End Sub
End Class