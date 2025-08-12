
Imports System.Data.OleDb

Public Class BlockDatePassword

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            EP.Clear()
            If Not ERRORVALID Then
                Exit Sub
            End If

            'clearing array
            For i = 1 To 100
                tempcol(i) = ""
                tempval(i) = ""
            Next
            tempcol(0) = "DATEPASS"
            tempcol(1) = "ENTRYPASS"

            tempval(0) = "'" & TXTDATEPASS.Text.Trim & "'"
            tempval(1) = "'" & TXTENTRYPASS.Text.Trim & "'"

            modify("DATEPASS", tempcol, tempval, tempcondition)
            Me.Close()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim BLN As Boolean = True

            If UCase(TXTDATEPASS.Text.Trim) <> UCase(TXTDATERETYPE.Text.Trim) Then
                EP.SetError(TXTDATERETYPE, "Password Does Not Match")
                BLN = False
            End If

            If UCase(TXTENTRYPASS.Text.Trim) <> UCase(TXTENTRYRETYPE.Text.Trim) Then
                EP.SetError(TXTENTRYRETYPE, "Password Does Not Match")
                BLN = False
            End If

            If UCase(TXTDATEPASS.Text.Trim) = UCase(TXTENTRYPASS.Text.Trim) Then
                EP.SetError(TXTDATEPASS, "Both Password Cannot be Same")
                BLN = False
            End If

            If TXTOLDDATEPASS.Text.Trim = "" Then
                EP.SetError(TXTOLDDATEPASS, "Enter Old Password")
                BLN = False
            End If

            If TXTDATEPASS.Text.Trim = "" Then
                EP.SetError(TXTDATEPASS, "Enter New Password")
                BLN = False
            End If

            If TXTDATERETYPE.Text.Trim = "" Then
                EP.SetError(TXTDATERETYPE, "Retype Password")
                BLN = False
            End If

            If TXTOLDENTRYPASS.Text.Trim = "" Then
                EP.SetError(TXTOLDENTRYPASS, "Enter Old Password")
                BLN = False
            End If

            If TXTENTRYPASS.Text.Trim = "" Then
                EP.SetError(TXTENTRYPASS, "Enter New Password")
                BLN = False
            End If

            If TXTENTRYRETYPE.Text.Trim = "" Then
                EP.SetError(TXTENTRYRETYPE, "Retype Password")
                BLN = False
            End If

           
            'CHECKING OLD PASSWORD
            tempcmd = New OleDbCommand("select DATEPASS, ENTRYPASS from DATEPASS", tempconn)
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            tempdr = tempcmd.ExecuteReader
            If tempdr.HasRows = True Then
                While (tempdr.Read)
                    If UCase(tempdr("DATEPASS")) <> UCase(TXTOLDDATEPASS.Text.Trim) Then
                        EP.SetError(TXTOLDDATEPASS, "Old Password Does Not Match")
                        BLN = False
                    End If
                    If UCase(tempdr("ENTRYPASS")) <> UCase(TXTOLDENTRYPASS.Text.Trim) Then
                        EP.SetError(TXTOLDENTRYPASS, "Old Password Does Not Match")
                        BLN = False
                    End If
                End While
            End If

            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub
End Class