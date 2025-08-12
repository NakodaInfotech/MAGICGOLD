Imports System.Data.oledb

Public Class groupdetails
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Sub fillgrid(ByVal tablename As String, ByVal col() As String, ByVal condition As String)

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

        gridgroup.RowCount = 0

        cmd = New oledbcommand("select " & q & " from " & tablename & condition, conn)
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()
        dr = cmd.ExecuteReader()
        While (dr.Read())
            gridgroup.Rows.Add(dr(col(0)), dr(col(1)))
        End While
        conn.Close()
        dr.Close()

    End Sub

    Private Sub gridgroup_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridgroup.CellDoubleClick

        If e.RowIndex >= 0 Then
            tempgroupname = gridgroup.Item(0, e.RowIndex).Value.ToString
            If USEREDIT = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If (chldgroupmaster.IsMdiChild = False) Then
                If chldgroupmaster.IsDisposed = True Then
                    chldgroupmaster = New groupmaster
                End If
                chldgroupmaster.MdiParent = MDIMain
                chldgroupmaster.cmdedit.Enabled = False
                chldgroupmaster.EDIT = True
                chldgroupmaster.lblgroup.Text = gridgroup.Item(1, e.RowIndex).Value.ToString
                chldgroupmaster.txtgroupname.Text = gridgroup.Item(0, e.RowIndex).Value.ToString
                tempgrouptype = gridgroup.Item(1, e.RowIndex).Value.ToString
                chldgroupmaster.lbl.Text = "Edit Existing Group" & vbNewLine & "(e.g. Purchase, Sale...., etc.)"
                Me.Close()
                chldgroupmaster.Show()
            Else
                chldgroupmaster.BringToFront()
            End If

        End If
    End Sub

    Private Sub newgroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles newgroup.Click
        If USERADD = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If
        If (chldgroupmaster.IsMdiChild = False) Then
            If chldgroupmaster.IsDisposed = True Then
                chldgroupmaster = New groupmaster
            End If
            Me.Close()
            chldgroupmaster.MdiParent = MDIMain
            chldgroupmaster.Show()
        Else
            chldgroupmaster.BringToFront()
        End If


    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        If Me.gridgroup.SelectedRows.Count > 0 Then
            For Each row As DataGridViewRow In gridgroup.SelectedRows

                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                tempgroupname = row.Cells(0).Value

                If (chldgroupmaster.IsMdiChild = False) Then
                    If chldgroupmaster.IsDisposed = True Then
                        chldgroupmaster = New groupmaster
                    End If
                    chldgroupmaster.MdiParent = MDIMain
                    chldgroupmaster.cmdedit.Enabled = False
                    chldgroupmaster.EDIT = True
                    chldgroupmaster.lblgroup.Text = row.Cells(1).Value
                    chldgroupmaster.txtgroupname.Text = tempgroupname
                    chldgroupmaster.cmbgrouptype.Text = row.Cells(1).Value.ToString
                    chldgroupmaster.lbl.Text = "Edit Existing Group" & vbNewLine & "(e.g. Purchase, Sale...., etc.)"
                    Me.Close()
                    chldgroupmaster.Show()
                Else
                    chldgroupmaster.BringToFront()
                End If
                Me.Close()

            Next
        End If
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub groupdetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

        '*********** CTRL + N ************
        If e.Control = True Then
            If e.KeyCode = Keys.N Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                'adding new group
                If (chldgroupmaster.IsMdiChild = False) Then
                    If chldgroupmaster.IsDisposed = True Then
                        chldgroupmaster = New groupmaster
                    End If
                    chldgroupmaster.MdiParent = MDIMain
                    chldgroupmaster.cmdedit.Enabled = True
                    chldgroupmaster.EDIT = False
                    chldgroupmaster.Show()
                Else
                    chldgroupmaster.BringToFront()
                End If
            End If
        End If
    End Sub

    Private Sub groupdetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'GROUP MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If


            For i = 1 To 100
                tempcol(i) = ""
                tempval(i) = ""
            Next

            group.Width = 200
            under.Visible = True
            Me.Text = "Group Details"
            tempcol(0) = "group_name"
            tempcol(1) = "group_under"
            tempcondition = " order by group_name"
            fillgrid("groupmaster", tempcol, tempcondition)
            newgroup.Text = "New Group"

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripdelete.Click
        If USERDELETE = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If
    End Sub
End Class