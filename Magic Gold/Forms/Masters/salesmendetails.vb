Imports System.Data.oledb

Public Class salesmendetails

    Private Sub Driverdetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

        '*********** CTRL + N ***********'
        If e.Control = True And e.KeyCode = Keys.N Then
            If (chldSalesmenmaster.IsMdiChild = False) Then
                If chldSalesmenmaster.IsDisposed = True Then
                    chldSalesmenmaster = New salesmenmaster
                End If
                Me.Close()
                chldSalesmenmaster.MdiParent = MDIMain
                chldSalesmenmaster.cmdedit.Enabled = True
                chldSalesmenmaster.EDIT = False
                chldSalesmenmaster.Show()
            Else
                chldSalesmenmaster.BringToFront()
            End If
        End If
    End Sub

    Sub fillgrid(ByVal tablename As String, ByVal col() As String, ByVal condition As String)

        Dim a As Integer
        Dim q As String
        a = col.GetLength(0)

        q = ""
        For i = 0 To a - 1
            If col(i) <> "" Then
                If q = "" Then
                    q = q + col(i)
                Else
                    q = q + "," + col(i)
                End If
            End If
        Next

        gridsalesman.RowCount = 0
        Dim cmd = New OleDbCommand("select " & q & " from " & tablename & condition, conn)

        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()
        dr = cmd.ExecuteReader()
        While (dr.Read())
            gridsalesman.Rows.Add(dr(col(0)), dr(col(1)))
        End While
        conn.Close()
        dr.Close()

    End Sub

    Private Sub cmdexit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        If Me.gridsalesman.SelectedRows.Count > 0 Then
            For Each row As DataGridViewRow In gridsalesman.SelectedRows
                tempsalesman = row.Cells(0).Value

                If (chldSalesmenmaster.IsMdiChild = False) Then
                    If chldSalesmenmaster.IsDisposed = True Then
                        chldSalesmenmaster = New salesmenmaster
                    End If
                    Me.Close()
                    chldSalesmenmaster.MdiParent = MDIMain
                    chldSalesmenmaster.EDIT = True
                    chldSalesmenmaster.cmdedit.Enabled = False
                    chldSalesmenmaster.Show()
                Else
                    chldSalesmenmaster.BringToFront()
                End If

            Next
        End If
    End Sub

    Private Sub Driverdetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        For i = 1 To 100
            tempcol(i) = ""
            tempval(i) = ""
        Next

        newDriver.Text = "Add New SalesMen"
        tempcol(0) = "SalesMen_name"
        tempcol(1) = "SalesMen_mobileno"

        tempcondition = ""
        fillgrid("SalesMenmaster", tempcol, tempcondition)
        cmdedit.Text = "Edit SalesMen..."

    End Sub

    Private Sub griddriver_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridsalesman.CellDoubleClick
        If e.RowIndex >= 0 Then
            temptaxname = gridsalesman.Item(0, e.RowIndex).Value.ToString

            If (chldSalesmenmaster.IsMdiChild = False) Then
                If chldSalesmenmaster.IsDisposed = True Then
                    chldSalesmenmaster = New salesmenmaster
                End If
                Me.Close()
                chldSalesmenmaster.MdiParent = MDIMain
                chldSalesmenmaster.cmdedit.Enabled = False
                chldSalesmenmaster.EDIT = True
                chldSalesmenmaster.Show()
            Else
                chldSalesmenmaster.BringToFront()
            End If

        End If
    End Sub

    Private Sub newDriver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles newDriver.Click

        If (chldSalesmenmaster.IsMdiChild = False) Then
            If chldSalesmenmaster.IsDisposed = True Then
                chldSalesmenmaster = New salesmenmaster
            End If
            Me.Close()
            chldSalesmenmaster.MdiParent = MDIMain
            chldSalesmenmaster.cmdedit.Enabled = True
            chldSalesmenmaster.EDIT = False
            chldSalesmenmaster.Show()
        Else
            chldSalesmenmaster.BringToFront()
        End If

    End Sub
End Class