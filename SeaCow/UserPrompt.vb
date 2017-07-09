Public Class UserPrompt

    Private Sub Quit(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub Login(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If UserNameBox.Text = My.Settings.username And UserPassBox.Text = My.Settings.userpassword Then
            Me.Dispose()
        End If
    End Sub
End Class