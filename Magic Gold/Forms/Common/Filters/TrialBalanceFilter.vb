Imports System.Data.oledb

Public Class trialbalancefilter

    Public WHERECLAUSE As String = ""

    Private Sub trialbalancefilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for SHOW REPORT
                Call cmdShowReport_Click(sender, e)
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub trialbalancefilter_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        fillcmb(cmbarea, "area_name", "areamaster", tempcondition)
        fillgroup()
    End Sub

    Sub fillgroup()

        'filling all groups and subgroups
        cmd = New OleDbCommand("select GROUP_NAME AS GROUPNAME from groupmaster ORDER BY GROUP_NAME", conn)
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()
        dr = cmd.ExecuteReader()
        If dr.HasRows Then
            While (dr.Read())
                gridgroup.Rows.Add(0, dr("GROUPNAME"))
            End While
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub cmdShowReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowReport.Click
        Try
            If cmbarea.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND AREA_NAME = '" & cmbarea.Text.Trim & "'"
            Dim TEMP As String = ""
            For Each ROW As DataGridViewRow In gridgroup.Rows
                If Convert.ToBoolean(ROW.Cells(0).Value) = True Then
                    If TEMP = "" Then
                        TEMP = " AND GROUP_NAME IN ('" & ROW.Cells(GGROUPNAME.Index).Value & "'"
                    Else
                        TEMP = TEMP & ",'" & ROW.Cells(GGROUPNAME.Index).Value & "'"
                    End If
                End If
            Next
            If TEMP <> "" Then TEMP = TEMP & ")"
            WHERECLAUSE = WHERECLAUSE & TEMP
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chkselect_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkselect.CheckedChanged
        If chkselect.Checked = True Then
            For i = 0 To gridgroup.RowCount - 1
                If gridgroup.CurrentRow.Index >= 0 Then
                    With gridgroup.Rows(i).Cells(0)
                        .Value = True
                    End With
                End If
            Next
        Else
            For i = 0 To gridgroup.RowCount - 1
                If gridgroup.CurrentRow.Index >= 0 Then
                    With gridgroup.Rows(i).Cells(0)
                        .Value = False
                    End With
                End If
            Next
        End If
    End Sub
End Class