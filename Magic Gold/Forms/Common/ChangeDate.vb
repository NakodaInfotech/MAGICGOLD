
Public Class ChangeDate

    Public predate As Date = Now.Date
    Public FRMSTRING As String = ""

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub ChangeDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.O Then       'for OK
            Call cmdok_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub ChangeDate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            NEWDATE.Value = Now.Date
            dtppreviousdate.Value = predate
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            If FRMSTRING = "GLOBALDATE" Then
                GLOBALDATE = NEWDATE.Value.Date
                Me.Close()
            Else

                If MsgBox("This will Change all the Daily Khata Entries to new date, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                If NEWDATE.Value.Date <> dtppreviousdate.Value.Date Then
                    chlddailykhata.CHANGED = True
                    chlddailykhata.CHANGEDDATE = NEWDATE.Value.Date
                End If
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ChangeDate_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If FRMSTRING = "GLOBALDATE" Then
            LBLPREVIOUS.Visible = False
            dtppreviousdate.Visible = False
        End If
    End Sub
End Class