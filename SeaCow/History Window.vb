Public Class History_Window

    Dim edited_contacts As New List(Of Contact)
    Dim edited_tasks As New List(Of Task)

    Private Sub History_Window_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Font = My.Settings.global_font

            If HistoryBox.Items.Count = 0 Then
                For Each hi In Main.history
                    AddHistoryItem(hi)
                Next
            End If

            If HistoryBox.Items.Count > 0 Then
                HistoryBox.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub AddHistoryItem(ByVal hi As HistoryItem)
        Try
            Dim item As New ListViewItem
            item.Text = String.Format("{0:t}", hi.time)

            Dim sitem As New ListViewItem.ListViewSubItem

            Select Case hi.action
                Case Is = 1
                    sitem.Text = "Added"
                Case Is = 2
                    sitem.Text = "Edited"
                Case Is = 3
                    sitem.Text = "Deleted"
            End Select
            For Each c In hi.contacts
                sitem.Text += " " + c.DisplayName + " (Contact)"
                If hi.contacts.Count > 1 And hi.contacts(hi.contacts.Count - 1).DisplayName <> c.DisplayName Then
                    sitem.Text += ", "
                End If
            Next
            For Each t In hi.tasks
                sitem.Text += " " + t.name + " (Task)"
                If hi.tasks.Count > 1 And hi.tasks(hi.tasks.Count - 1).name <> t.name Then
                    sitem.Text += ", "
                End If
            Next
            Dim unique As Boolean = True
            For Each i As ListViewItem In HistoryBox.Items
                If sitem.Text = i.Text Then
                    unique = False
                End If
            Next
            If unique Then
                Select Case hi.undo
                    Case Is = 0
                        item.BackColor = Color.White
                        sitem.BackColor = Color.White
                    Case Is = 1
                        item.BackColor = Color.silver
                        sitem.BackColor = Color.silver
                End Select
                item.SubItems.Add(sitem.Text)
                HistoryBox.Items.Add(item)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ResizeMe(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If HistoryBox.Items.Count > 0 Then
            HistoryBox.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        End If
    End Sub

    Private Sub Close_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Close_Button.Click
        Me.Close()
    End Sub

    Private Sub Undo_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Undo_Button.Click
        Try
            If HistoryBox.SelectedItems.Count = 1 Then
                Dim index As Integer = HistoryBox.SelectedItems(0).Index
                Dim hi As HistoryItem = Main.history(index)
                Select Case hi.action
                    Case Is = 1 'Undo Add
                        For Each c In hi.contacts
                            Main.db.ExecuteCommand("DELETE FROM Contacts WHERE DisplayName='" + c.DisplayName + "'")
                        Next
                        For Each t In hi.tasks
                            Main.db.ExecuteCommand("DELETE FROM Tasks WHERE name='" + t.name + "'")
                        Next
                    Case Is = 2 'Undo Edit
                        For Each c In hi.unedited_contacts
                            Main.UpdateRows(c, Nothing, index)
                        Next
                        For Each t In hi.unedited_tasks
                            Main.UpdateRows(Nothing, t, index)
                        Next
                    Case Is = 3 'Undo Delete
                        For Each c In hi.contacts
                            Main.InsertRows(c, Nothing)
                        Next
                        For Each t In hi.tasks
                            Main.InsertRows(Nothing, t)
                        Next

                End Select

                hi.undo = 1

                'Set Status Label
                Dim text As String = "Undo "
                Select Case hi.action
                    Case Is = 1
                        text += "Add "
                    Case Is = 2
                        text += "Edit "
                    Case Is = 3
                        text += "Delete "
                End Select
                If hi.contacts.Count > 1 Then
                    text += hi.contacts.Count.ToString + " contacts."
                ElseIf hi.contacts.Count = 1 Then
                    text += hi.contacts.Count.ToString + " contact."
                End If
                If hi.tasks.Count > 1 Then
                    text += hi.tasks.Count.ToString + " tasks."
                ElseIf hi.tasks.Count = 1 Then
                    text += hi.tasks.Count.ToString + " task."
                End If
                Main.StatusLabel.Text = text

                Main.Update_Contact_Box()
                Main.Update_Task_Box()

                HistoryBox.SelectedItems(0).BackColor = Color.silver
                For Each si As ListViewItem.ListViewSubItem In HistoryBox.SelectedItems(0).SubItems
                    si.BackColor = Color.silver
                Next
                Undo_Button.Enabled = False
                Redo_Button.Enabled = True


            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Redo_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Redo_Button.Click
        Try
            If HistoryBox.SelectedItems.Count = 1 Then
                Dim index As Integer = HistoryBox.SelectedItems(0).Index
                Dim hi As HistoryItem = Main.history(index)
                Select Case hi.action
                    Case Is = 1 'Redo Add
                        For Each c In hi.contacts
                            Main.InsertRows(c, Nothing)
                        Next
                        For Each t In hi.tasks
                            Main.InsertRows(Nothing, t)
                        Next
                    Case Is = 2 'Redo Edit
                        For Each c In hi.edited_contacts
                            Main.UpdateRows(c, Nothing, index)
                        Next
                        For Each t In hi.edited_tasks
                            Main.UpdateRows(Nothing, t, index)
                        Next
                    Case Is = 3 'Redo Delete
                        For Each c In hi.contacts
                            Main.db.ExecuteCommand("DELETE FROM Contacts WHERE DisplayName='" + c.DisplayName + "'")
                        Next
                        For Each t In hi.tasks
                            Main.db.ExecuteCommand("DELETE FROM Tasks WHERE name='" + t.name + "'")
                        Next

                End Select

                hi.undo = 0

                'Set Status Label
                Dim text As String = "Redo "
                Select Case hi.action
                    Case Is = 1
                        text += "Add "
                    Case Is = 2
                        text += "Edit "
                    Case Is = 3
                        text += "Delete "
                End Select
                If hi.contacts.Count > 1 Then
                    text += hi.contacts.Count.ToString + " contacts."
                ElseIf hi.contacts.Count = 1 Then
                    text += hi.contacts.Count.ToString + " contact."
                End If
                If hi.tasks.Count > 1 Then
                    text += hi.tasks.Count.ToString + " tasks."
                ElseIf hi.tasks.Count = 1 Then
                    text += hi.tasks.Count.ToString + " task."
                End If
                Main.StatusLabel.Text = text

                If hi.tasks.Count > 0 Then
                    Main.Update_Task_Box()
                ElseIf hi.contacts.Count > 0 Then
                    Main.Update_Contact_Box()
                End If

                HistoryBox.SelectedItems(0).BackColor = Color.White
                For Each si As ListViewItem.ListViewSubItem In HistoryBox.SelectedItems(0).SubItems
                    si.BackColor = Color.White
                Next
                Undo_Button.Enabled = True
                Redo_Button.Enabled = False
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub HistoryBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HistoryBox.SelectedIndexChanged
        Try
            If HistoryBox.SelectedItems(0).BackColor = Color.silver Then
                Undo_Button.Enabled = False
                Redo_Button.Enabled = True
            Else
                Undo_Button.Enabled = True
                Redo_Button.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class