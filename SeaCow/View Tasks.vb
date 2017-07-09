Public Class View_Tasks

    Private Sub View_Tasks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Update_Box()
        Me.Font = My.Settings.global_font
        If ListView1.Items.Count > 0 Then
            ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        End If
    End Sub

    Private Sub View_Tasks_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If ListView1.Items.Count > 0 Then
            ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        End If
    End Sub

    Private Sub Update_Box()
        ListView1.Items.Clear()

        For Each task In Main.db.Tasks
            Dim item As New ListViewItem(String.Format("{0:d}", task.time))
            item.SubItems.Add(String.Format("{0:t}", task.time))
            item.SubItems.Add(task.name)
            item.SubItems.Add(task.description)
            item.SubItems.Add(task.priority)
            item.SubItems.Add(task.status)
            If My.Settings.showtaskcolors Then
                Dim color As New Color
                Select Case task.priority
                    Case Is = "Low"
                        color = My.Settings.priority_low
                        item.BackColor = color
                        For Each si As ListViewItem.ListViewSubItem In item.SubItems
                            si.BackColor = color
                        Next
                        If My.Settings.priorityf_low <> Nothing Then
                            item.ForeColor = My.Settings.priorityf_low
                            For Each si As ListViewItem.ListViewSubItem In item.SubItems
                                si.ForeColor = My.Settings.priorityf_low
                            Next
                        Else
                            item.ForeColor = color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B)
                            For Each si As ListViewItem.ListViewSubItem In item.SubItems
                                si.ForeColor = color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B)
                            Next
                        End If
                    Case Is = "Normal"
                        color = My.Settings.priority_normal
                        item.BackColor = color
                        For Each si As ListViewItem.ListViewSubItem In item.SubItems
                            si.BackColor = color
                        Next
                        If My.Settings.priorityf_normal <> Nothing Then
                            item.ForeColor = My.Settings.priorityf_normal
                            For Each si As ListViewItem.ListViewSubItem In item.SubItems
                                si.ForeColor = My.Settings.priorityf_normal
                            Next
                        Else
                            item.ForeColor = color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B)
                            For Each si As ListViewItem.ListViewSubItem In item.SubItems
                                si.ForeColor = color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B)
                            Next
                        End If
                    Case Is = "High"
                        color = My.Settings.priority_high
                        item.BackColor = color
                        For Each si As ListViewItem.ListViewSubItem In item.SubItems
                            si.BackColor = color
                        Next
                        If My.Settings.priorityf_high <> Nothing Then
                            item.ForeColor = My.Settings.priorityf_high
                            For Each si As ListViewItem.ListViewSubItem In item.SubItems
                                si.ForeColor = My.Settings.priorityf_high
                            Next
                        Else
                            item.ForeColor = color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B)
                            For Each si As ListViewItem.ListViewSubItem In item.SubItems
                                si.ForeColor = color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B)
                            Next
                        End If
                End Select
            End If
            ListView1.Items.Add(item)
        Next
    End Sub

    Private Sub Close_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles close_button.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub Edit()
        Try
            Dim selecteditem As ListViewItem = ListView1.SelectedItems.Item(0)

            For Each task In Main.db.Tasks
                If (selecteditem.SubItems.Item(2).Text = task.name) Then
                    Main.selected_task = task
                End If
            Next

            Show_Window(Edit_Task)
            Update_Box()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub EditContact(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditStripMenuItem1.Click, ListView1.DoubleClick
        Edit()
    End Sub

    Private Sub DeletePressed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListView1.KeyDown
        If e.KeyCode = Keys.Delete Then
            Delete()
        End If
    End Sub

    Private Sub DeleteRightClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteStripMenuItem1.Click
        Delete()
    End Sub

    Private Sub Delete()
        Try
            Dim selectedtasks(ListView1.SelectedItems.Count - 1) As String
            For x As Integer = 0 To ListView1.SelectedItems.Count - 1
                Dim selectedtask As String = ListView1.SelectedItems.Item(x).SubItems.Item(2).Text
                selectedtasks(x) = selectedtask
            Next

            'Multiple Tasks
            If selectedtasks.Count > 1 Then
                If My.Settings.showtdeleteprompt Then
                    If MsgBox("Are you sure you want to delete these tasks?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                        'backup
                        Main.Backup(Nothing, selectedtasks, 3)

                        'delete
                        For Each t In selectedtasks
                            Main.db.ExecuteCommand("DELETE FROM Tasks WHERE name='" + t + "'")
                        Next

                        Update_Box()
                    End If
                Else
                    'backup
                    Main.Backup(Nothing, selectedtasks, 3)

                    'delete
                    For Each t In selectedtasks
                        Main.db.ExecuteCommand("DELETE FROM Tasks WHERE name='" + t + "'")
                    Next

                    Update_Box()
                End If
            Else
                'Single Contact
                ' Show Delete Prompt
                If My.Settings.showtdeleteprompt Then
                    If MsgBox("Are you sure you want to delete this task?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                        'backup
                        Main.Backup(Nothing, selectedtasks, 3)

                        'delete
                        Main.db.ExecuteCommand("DELETE FROM Tasks WHERE name='" + selectedtasks(0) + "'")

                        Update_Box()
                    End If
                Else
                    ' Delete Without Prompt

                    'backup
                    Main.Backup(Nothing, selectedtasks, 3)

                    'delete
                    Main.db.ExecuteCommand("DELETE FROM Tasks WHERE name='" + selectedtasks(0) + "'")

                    Update_Box()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    ' Sort using the clicked column.
    Dim m_SortingColumn As New ColumnHeader
    Private Sub ListView1_ColumnClick(ByVal sender As  _
        System.Object, ByVal e As  _
        System.Windows.Forms.ColumnClickEventArgs) Handles ListView1.ColumnClick

        ' Get the new sorting column.
        Dim new_sorting_column As ColumnHeader = _
            ListView1.Columns(e.Column)

        ' Figure out the new sorting order.
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(m_SortingColumn) Then
                ' Same column. Switch the sort order.
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            m_SortingColumn.Text = _
                m_SortingColumn.Text.Substring(2)
        End If

        ' Display the new sort order.
        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        ' Create a comparer.
        ListView1.ListViewItemSorter = New  _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListView1.Sort()

        ' Organize my_contacts List
        For Each item In ListView1.Items

        Next
    End Sub

    Public Sub Show_Window(ByVal window As Form)
        Me.Enabled = False
        If window.ShowDialog = DialogResult.OK Then
            Me.Enabled = True
        Else
            Me.Enabled = True
        End If
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        Main.selected_time = Now
        Show_Window(Add_Task)
        Update_Box()
    End Sub
End Class