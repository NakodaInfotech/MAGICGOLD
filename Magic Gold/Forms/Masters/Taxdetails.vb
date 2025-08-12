Imports System.Data.oledb

Public Class Taxdetails
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub Taxdetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Taxdetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'TAX MASTER'")
        USERADD = DTROW(0).Item(1)
        USEREDIT = DTROW(0).Item(2)
        USERVIEW = DTROW(0).Item(3)
        USERDELETE = DTROW(0).Item(4)

        For i = 1 To 100
            tempcol(i) = ""
            tempval(i) = ""
        Next

        If USEREDIT = False And USERVIEW = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        newtax.Text = "New Tax"
        tempcol(0) = "tax_name"
        tempcol(1) = "tax_desc"
        tempcol(2) = "tax_tax"

        tempcondition = ""
        fillgrid("taxmaster", tempcol, tempcondition)
        cmdedit.Text = "Edit Tax..."

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

        gridtax.RowCount = 0
        Dim cmd = New oledbcommand("select " & q & " from " & tablename & condition, conn)

        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()
        dr = cmd.ExecuteReader()
        While (dr.Read())
            gridtax.Rows.Add(dr(col(0)), dr(col(1)), dr(col(2)))
        End While
        conn.Close()
        dr.Close()

    End Sub

    Private Sub gridtax_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridtax.CellDoubleClick
        If e.RowIndex >= 0 Then
            temptaxname = gridtax.Item(0, e.RowIndex).Value.ToString

            If USEREDIT = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (chldtaxmaster.IsMdiChild = False) Then
                If chldtaxmaster.IsDisposed = True Then
                    chldtaxmaster = New taxmaster
                End If
                Me.Close()
                chldtaxmaster.MdiParent = MDIMain
                chldtaxmaster.cmdedit.Enabled = False
                chldtaxmaster.EDIT = True
                chldtaxmaster.Show()
            Else
                chldtaxmaster.BringToFront()
            End If

        End If
    End Sub

    Private Sub cmdexit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        If Me.gridtax.SelectedRows.Count > 0 Then
            For Each row As DataGridViewRow In gridtax.SelectedRows
                temptaxname = row.Cells(0).Value
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If (chldtaxmaster.IsMdiChild = False) Then
                    If chldtaxmaster.IsDisposed = True Then
                        chldtaxmaster = New taxmaster
                    End If
                    Me.Close()
                    chldtaxmaster.MdiParent = MDIMain
                    chldtaxmaster.EDIT = True
                    chldtaxmaster.cmdedit.Enabled = False
                    chldtaxmaster.Show()
                Else
                    chldtaxmaster.BringToFront()
                End If

            Next
        End If
    End Sub

    Private Sub newtax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles newtax.Click
        If USERADD = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If
        If (chldtaxmaster.IsMdiChild = False) Then
            If chldtaxmaster.IsDisposed = True Then
                chldtaxmaster = New taxmaster
            End If
            Me.Close()
            chldtaxmaster.MdiParent = MDIMain
            chldtaxmaster.cmdedit.Enabled = True
            chldtaxmaster.EDIT = False
            chldtaxmaster.Show()
        Else
            chldtaxmaster.BringToFront()
        End If

    End Sub
End Class