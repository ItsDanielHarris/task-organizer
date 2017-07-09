Public Class Add_Task

    Private Sub cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok.Click

        Try

            Dim t As New Task

            t.time = New Date(datebox.Value.Year, datebox.Value.Month, datebox.Value.Day, timebox.Value.Hour, timebox.Value.Minute, 0)
            t.name = TaskNameTxtBox.Text
            t.description = TaskDescTxtBox.Text
            If TaskPriority.SelectedItem IsNot Nothing Then
                t.priority = TaskPriority.SelectedItem.ToString
            End If
            t.status = StatusBox.Text

            Dim unique As Boolean = True

            If t.name <> "" Then

                For Each task In Main.db.Tasks
                    If t.name = task.name Then
                        unique = False
                    End If
                Next

                If unique Then
                    Main.InsertRows(Nothing, t)

                    Dim name() As String = {t.name}
                    Main.Backup(Nothing, name, 1)

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Dispose()
                Else
                    MsgBox("Task has same name as another task.")
                End If

            Else
                MsgBox("Task is missing a name.")
            End If

        Catch ex As Exception
            MsgBox("There was a problem in adding the task." & vbNewLine & "Error: " + ex.ToString)
        End Try

    End Sub

    Private Sub Add_Task_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Font = My.Settings.global_font
        If Main.selected_task.time <> Nothing Then
            datebox.Value = Main.selected_task.time
            timebox.Value = Main.selected_task.time
        Else
            datebox.Value = Now
            timebox.Value = Now
        End If

    End Sub

    Private Sub TaskNameTxtBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaskNameTxtBox.TextChanged
        If TaskNameTxtBox.Text <> "" Then
            Me.Text = "Add Task - " + TaskNameTxtBox.Text
            Me.Text = "Add Task"
        End If

    End Sub
End Class