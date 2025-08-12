
Imports System.Data.OleDb

Public Class Stockform

    Public ht, wd As Double
    Public item As String
    Public GROSSWT, PURITY As Double

    Private Sub Stockform_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Stockform_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Me.Top = ht + (Me.Height / 2) + 10
            'Me.Left = wd
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try

            Dim WHERECLAUSE As String = ""
            Dim GROUPBYCLAUSE As String = ""
            If USERDEPARTMENT <> "" Then WHERECLAUSE = WHERECLAUSE & " AND STOCKS.DEPARTMENT = '" & USERDEPARTMENT & "'"
            If USERDEPARTMENT <> "" Then GROUPBYCLAUSE = GROUPBYCLAUSE & ", STOCKS.DEPARTMENT "

            Dim cmd As New OleDbCommand("select item_code as [Code], item_purity as [Melting], ROUND(sum(item_grosswt),3) as [Gross Wt], ROUND(sum(item_nettwt),3) as [NettWt] from stocks where item_code = '" & item & "'" & WHERECLAUSE & " group by item_code, item_purity " & GROUPBYCLAUSE & " having sum(item_nettwt) > 0", conn)
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            Dim da As New OleDbDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            gridkarigar.DataSource = dt

            gridkarigar.Columns(0).HeaderText = "Item Code"
            gridkarigar.Columns(0).Width = 100
            gridkarigar.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            gridkarigar.Columns(1).HeaderText = "Purity"
            gridkarigar.Columns(1).Width = 80
            gridkarigar.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            gridkarigar.Columns(2).HeaderText = "Gross Wt."
            gridkarigar.Columns(2).Width = 80
            gridkarigar.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            gridkarigar.Columns(2).DefaultCellStyle.Format = "N3"

            gridkarigar.Columns(3).HeaderText = "Nett Wt."
            gridkarigar.Columns(3).Width = 80
            gridkarigar.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            gridkarigar.Columns(3).DefaultCellStyle.Format = "N3"

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub gridkarigar_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridkarigar.CellDoubleClick
        If IsDBNull(gridkarigar.CurrentRow.Cells(0).Value) = True Then
            Me.Close()
            Exit Sub
        End If
        If Val(gridkarigar.CurrentRow.Cells(1).Value) > 0 Then
            PURITY = Val(gridkarigar.CurrentRow.Cells(1).Value)
            GROSSWT = Val(gridkarigar.CurrentRow.Cells(2).Value)
            Me.Close()
        End If
    End Sub

    Private Sub gridkarigar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridkarigar.KeyDown
        If e.KeyCode = Keys.Enter Then
            If IsDBNull(gridkarigar.CurrentRow.Cells(0).Value) = True Then
                Me.Close()
                Exit Sub
            End If
            If Val(gridkarigar.CurrentRow.Cells(1).Value) > 0 Then
                PURITY = Val(gridkarigar.CurrentRow.Cells(1).Value)
                GROSSWT = Val(gridkarigar.CurrentRow.Cells(2).Value)
                Me.Close()
            End If
        End If
    End Sub
End Class