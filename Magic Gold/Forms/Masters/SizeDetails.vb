
Imports System.Data.OleDb

Public Class SizeDetails

    Public FRMSTRING As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SizeDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf (e.Control = True And e.KeyCode = Windows.Forms.Keys.N) Then   'for Exit
            showform(False, "")
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, gridgroup.Item(0, gridgroup.CurrentRow.Index).Value.ToString)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RoomTypeDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If FRMSTRING = "SHAPE" Then
                Me.Text = "Shape Master"
            ElseIf FRMSTRING = "SIZE" Then
                Me.Text = "Size Master"
            ElseIf FRMSTRING = "COLOR" Then
                Me.Text = "Color Master"
            ElseIf FRMSTRING = "DEPARTMENT" Then
                Me.Text = "Department Master"
            End If
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()

        Dim dt As New DataTable()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()

        If FRMSTRING = "SHAPE" Then
            tempcmd = New OleDbCommand("select SHAPE_NAME from SHAPEMASTER order by SHAPE_NAME", tempconn)
        ElseIf FRMSTRING = "SIZE" Then
            tempcmd = New OleDbCommand("select SIZE_NAME from SIZEMASTER order by SIZE_NAME", tempconn)
        ElseIf FRMSTRING = "COLOR" Then
            tempcmd = New OleDbCommand("select COLOR_NAME from COLORMASTER order by COLOR_NAME", tempconn)
        ElseIf FRMSTRING = "DEPARTMENT" Then
            tempcmd = New OleDbCommand("select DEPARTMENT_NAME from DEPARTMENTMASTER order by DEPARTMENT_NAME", tempconn)
        End If

        da = New OleDbDataAdapter(tempcmd)
        da.Fill(dt)

        gridgroup.DataSource = dt
        gridgroup.Columns(0).HeaderText = "Name"

        gridgroup.Columns(0).Width = 250
        If gridgroup.RowCount > 0 Then gridgroup.FirstDisplayedScrollingRowIndex = gridgroup.RowCount - 1

    End Sub

    Private Sub gridgroup_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridgroup.CellDoubleClick
        Try
            showform(True, gridgroup.Item(0, gridgroup.CurrentRow.Index).Value.ToString)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal name As String)
        Try
            Dim OBJSIZE As New SizeMaster
            OBJSIZE.edit = editval
            OBJSIZE.MdiParent = MDIMain
            OBJSIZE.FRMSTRING = FRMSTRING
            OBJSIZE.TempName = name
            OBJSIZE.Show()
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

    Private Sub txtcmp_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcmp.Validated
        Dim rowno, b As Integer

        fillgrid()
        rowno = 0
        For b = 1 To gridgroup.RowCount
            txttempname.Text = gridgroup.Item(0, rowno).Value.ToString()
            txttempname.SelectionStart = 0
            txttempname.SelectionLength = txtcmp.TextLength
            If LCase(txtcmp.Text.Trim) <> LCase(txttempname.SelectedText.Trim) Then
                gridgroup.Rows.RemoveAt(rowno)
            Else
                rowno = rowno + 1
            End If
        Next
    End Sub

End Class