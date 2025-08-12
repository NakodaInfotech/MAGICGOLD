
Imports System.Data.OleDb

Public Class BlockDate

    Private Sub BlockDate_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        tempcmd = New OleDbCommand("select BLOCKDATE, APPLYBLOCK from BLOCKDATE ", tempconn)
        If tempconn.State = ConnectionState.Open Then tempconn.Close()
        tempconn.Open()
        tempdr = tempcmd.ExecuteReader
        If tempdr.HasRows = True Then
            While (tempdr.Read)
                If Convert.ToBoolean(tempdr("APPLYBLOCK")) = True Then DTBLOCKDATE.Value = Format(tempdr(0), "dd/MM/yyyy") Else DTBLOCKDATE.Value = Now.Date
            End While
        End If
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            'GET DATEPASSWORD FOR CHANGING THE DATE
            Dim OBJPASS As New PasswordEntry
            OBJPASS.ShowDialog()
            tempcmd = New OleDbCommand("select DATEPASS from DATEPASS ", tempconn)
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            tempdr = tempcmd.ExecuteReader
            If tempdr.HasRows = True Then
                While (tempdr.Read)
                    If tempdr(0) <> OBJPASS.TXTDATERETYPE.Text.Trim Then
                        MsgBox("Invaid Password", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                End While
            End If
            OBJPASS.Dispose()


            'clearing array
            For i = 1 To 100
                tempcol(i) = ""
                tempval(i) = ""
            Next
            tempcol(0) = "BLOCKDATE"
            tempcol(1) = "APPLYBLOCK"

            tempval(0) = "'" & Format(DTBLOCKDATE.Value, "dd/MM/yyyy") & "'"
            tempval(1) = "1"

            modify("BLOCKDATE", tempcol, tempval, "")
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub
End Class