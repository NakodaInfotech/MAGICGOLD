

Public Class SendMail
    Public attachment As String

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            If cmbfirstadd.Text.Trim <> Nothing Then
                sendemail(cmbfirstadd.Text.Trim, attachment, txtmailbody.Text.Trim)
            End If

            If cmbsecondadd.Text.Trim <> Nothing Then
                sendemail(cmbsecondadd.Text.Trim, attachment, txtmailbody.Text.Trim)
            End If

            If cmbthirdadd.Text.Trim <> Nothing Then
                sendemail(cmbthirdadd.Text.Trim, attachment, txtmailbody.Text.Trim)
            End If

            If cmbfourthadd.Text.Trim <> Nothing Then
                sendemail(cmbfourthadd.Text.Trim, attachment, txtmailbody.Text.Trim)
            End If

            If cmbfifthadd.Text.Trim <> Nothing Then
                sendemail(cmbfifthadd.Text.Trim, attachment, txtmailbody.Text.Trim)
            End If

            MsgBox("Mails sent successfully")
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If cmbfirstadd.Text.Trim.Length = 0 And cmbsecondadd.Text.Trim.Length = 0 And cmbthirdadd.Text.Trim.Length = 0 And cmbfourthadd.Text.Trim.Length = 0 And cmbfifthadd.Text.Trim.Length = 0 Then
            Ep.SetError(cmbfirstadd, "Enter Email Address")
        End If
        Return bln
    End Function

    Private Sub SendMail_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.M Then       'for Saving
                Call cmdok_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SendMail_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = 100
    End Sub

    Private Sub cmbfifthadd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbfifthadd.GotFocus
        Try
            fillcmb(cmbfifthadd)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillcmb(ByRef cmb As System.Windows.Forms.ComboBox)
        Try
            
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbfirstadd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbfirstadd.GotFocus
        Try
            fillcmb(cmbfirstadd)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbfourthadd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbfourthadd.GotFocus
        Try
            fillcmb(cmbfourthadd)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbsecondadd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbsecondadd.GotFocus
        Try
            fillcmb(cmbsecondadd)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbthirdadd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbthirdadd.GotFocus
        Try
            fillcmb(cmbthirdadd)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub cmbvalidate(ByRef cmb As System.Windows.Forms.ComboBox)
        Try
            
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbfifthadd_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbfifthadd.Validating
        Try
            cmbvalidate(cmbfifthadd)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbfirstadd_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbfirstadd.Validating
        Try
            cmbvalidate(cmbfirstadd)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbfourthadd_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbfourthadd.Validating
        Try
            cmbvalidate(cmbfourthadd)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbsecondadd_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbsecondadd.Validating
        Try
            cmbvalidate(cmbsecondadd)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbthirdadd_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbthirdadd.Validating
        Try
            cmbvalidate(cmbthirdadd)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BlendPanel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BlendPanel1.Click

    End Sub
End Class