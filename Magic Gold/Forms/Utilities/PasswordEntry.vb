
Imports System.Data.OleDb

Public Class PasswordEntry

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class