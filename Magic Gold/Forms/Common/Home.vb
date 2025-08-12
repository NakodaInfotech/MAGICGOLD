Public Class Home

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        ''purchase order
        'If (chldpurchaseorder.IsMdiChild = False) Then
        '    If chldpurchaseorder.IsDisposed = True Then
        '        chldpurchaseorder = New purchaseorder
        '    End If
        '    frmpurchaseorder = True
        '    frmpurchasereturn = False
        '    chldpurchaseorder.MdiParent = MDIParent1
        '    chldpurchaseorder.Show()
        'Else
        '    chldpurchaseorder.BringToFront()
        'End If
    End Sub

    Private Sub Label1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs)
        'Label1.Image = Textile.My.Resources.Resources.orderchecks2
    End Sub

    Private Sub Label1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        'Label1.Image = Textile.My.Resources.Resources.orderchecks2_r
    End Sub

End Class