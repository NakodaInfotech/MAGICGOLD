

Public Class EnterPassword

    Public BLN As Boolean = False

    Private Sub CMDEXIT_Click(sender As Object, e As EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(sender As Object, e As EventArgs) Handles CMDOK.Click
        Try
            If TXTPASSWORD.Text.Trim = "Infosys@123" Then
                BLN = True
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class