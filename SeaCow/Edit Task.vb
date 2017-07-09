Public Class Edit_Task

    Private Sub Edit_Task_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Font = My.Settings.global_font

        timebox.Value = Main.selected_task.time
        datebox.Value = Main.selected_task.time

        Me.Text += " - " + Main.selected_task.name

        TaskNameTxtBox.Text = Main.selected_task.name
        TaskDescTxtBox.Text = Main.selected_task.description

        Select Case Main.selected_task.priority
            Case Is = "Low"
                TaskPriority.SelectedIndex = 0
            Case Is = "Normal"
                TaskPriority.SelectedIndex = 1
            Case Is = "High"
                TaskPriority.SelectedIndex = 2
        End Select

        StatusBox.Text = Main.selected_task.status

    End Sub

    Private Sub cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancel.Click
        If My.Settings.hidetsavechanges Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Dispose()
        Else
            If MsgBox("Do you want to save the task first?", MsgBoxStyle.YesNo, "Save Task?") = MsgBoxResult.Yes Then
                ok.PerformClick()
            Else
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Dispose()
            End If
        End If

    End Sub

    Private Sub ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok.Click

        Try
            Main.unedited_tasks.Clear()
            Main.unedited_tasks.Add(Main.selected_task)

            Dim t As New Task

            t.time = New Date(datebox.Value.Year, datebox.Value.Month, datebox.Value.Day, timebox.Value.Hour, timebox.Value.Minute, 0)
            t.name = TaskNameTxtBox.Text
            t.description = TaskDescTxtBox.Text
            t.priority = TaskPriority.Text
            t.status = StatusBox.Text

            Dim unique As Boolean = True

            If t.name <> "" Then

                For Each task In Main.db.Tasks
                    If t.name = task.name And t.name <> Main.selected_task.name Then
                        unique = False
                    End If
                Next

                If unique Then
                    Main.unedited_contacts.Clear()
                    Main.edited_contacts.Clear()
                    Main.edited_tasks.Clear()
                    Main.edited_tasks.Add(t)

                    Dim name() As String = {Main.selected_task.name}
                    Main.Backup(Nothing, name, 2)

                    Main.UpdateRows(Nothing, t, Nothing)
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Dispose()
                Else
                    MsgBox("Task has same name as another task.")
                End If

            Else
                MsgBox("Task is missing a name.")
            End If

        Catch ex As Exception

            MsgBox("There was a problem in editing the task." & vbNewLine & "Error: " + ex.ToString)

        End Try

    End Sub

End Class