
Imports System.Data.OleDb

Public Class SelectItem

    Public STRSEARCH As String
    Public TEMPNAME, TEMPCODE As String

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub SelectItem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.O Then       'for Saving
                Call CMDOK_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SelectItem_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            FILLGRID("")
            cmbname.Text = "Code"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID(ByVal WHERECLAUSE As String)
        Try
            dt = New DataTable()
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()

            WHERECLAUSE = WHERECLAUSE & STRSEARCH

            tempcmd = New OleDbCommand("select ITEM_NAME, ITEM_CODE   from ITEMMASTER WHERE 1 = 1 " & WHERECLAUSE & " ORDER BY ITEMMASTER.ITEM_CODE", tempconn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt)

            tempdr = tempcmd.ExecuteReader()
            GRIDHOTEL.DataSource = dt

            GRIDHOTEL.Columns(0).HeaderText = "Name"
            GRIDHOTEL.Columns(0).Width = 260

            GRIDHOTEL.Columns(1).HeaderText = "Code"
            GRIDHOTEL.Columns(1).Width = 260

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            If GRIDHOTEL.SelectedRows.Count > 0 Then
                TEMPNAME = GRIDHOTEL.Rows(GRIDHOTEL.SelectedRows(0).Index).Cells(0).Value
                TEMPCODE = GRIDHOTEL.Rows(GRIDHOTEL.SelectedRows(0).Index).Cells(1).Value
            Else
                TEMPNAME = ""
                TEMPCODE = ""
            End If
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDHOTEL_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDHOTEL.CellDoubleClick
        Try
            If GRIDHOTEL.Rows.Count > 0 Then
                CMDOK_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            showform(False, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, GRIDHOTEL.Item(0, GRIDHOTEL.CurrentRow.Index).Value)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal name As String)
        Try
            If (editval = False) Or (editval = True And GRIDHOTEL.RowCount > 0) Then
                Dim OBJITEM As New Itemmaster
                OBJITEM.TEMPITEMCODE = name

                OBJITEM.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            FILLGRID("")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTNAME_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTNAME.TextChanged
        Try
            If TXTNAME.Text.Trim <> "" And cmbname.Text.Trim <> "" Then
                If rbstart.Checked = True Then
                    If cmbname.Text = "Name" Then
                        FILLGRID(" AND ITEM_NAME like '%" & TXTNAME.Text.Trim & "'")
                    ElseIf cmbname.Text = "Code" Then
                        FILLGRID(" AND ITEM_CODE like '%" & TXTNAME.Text.Trim & "'")
                    End If
                ElseIf rbpart.Checked = True Then
                    If cmbname.Text = "Name" Then
                        FILLGRID(" AND ITEM_NAME LIKE '%" & TXTNAME.Text.Trim & "%'")
                    ElseIf cmbname.Text = "Code" Then
                        FILLGRID(" AND ITEM_CODE LIKE '%" & TXTNAME.Text.Trim & "%'")
                    End If
                End If
            Else
                FILLGRID("")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDHOTEL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDHOTEL.KeyDown
        Try
            If e.KeyCode = Keys.Enter And GRIDHOTEL.RowCount > 0 Then

                If GRIDHOTEL.SelectedRows.Count > 0 Then
                    TEMPNAME = GRIDHOTEL.Rows(GRIDHOTEL.SelectedRows(0).Index).Cells(0).Value
                    TEMPCODE = GRIDHOTEL.Rows(GRIDHOTEL.SelectedRows(0).Index).Cells(1).Value
                Else
                    TEMPNAME = ""
                    TEMPCODE = ""
                End If
                Me.Close()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class