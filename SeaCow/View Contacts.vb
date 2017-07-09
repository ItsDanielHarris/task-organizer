Imports System.Data

Public Class View_Contacts

    Private Sub View_Contacts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Update_Box()
        Main.group = False
        Me.Font = My.Settings.global_font
        If ListView1.Items.Count > 0 Then
            ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        End If
    End Sub

    Private Sub Update_Box()
        ListView1.Items.Clear()

        For Each contact In Main.db.Contacts
            Dim item As New ListViewItem()

            For Each p As System.Reflection.PropertyInfo In contact.GetType().GetProperties()
                If p.CanRead Then
                    Select Case p.Name
                        Case Is = "FirstName"
                            item.Text = p.GetValue(contact, Nothing)
                        Case Is = "BirthMonth"
                            If p.GetValue(contact, Nothing) = Nothing Then
                                item.SubItems.Add("")
                            Else
                                item.SubItems.Add(MonthName(p.GetValue(contact, Nothing)))
                            End If
                        Case Else
                            item.SubItems.Add(p.GetValue(contact, Nothing))
                    End Select
                End If
            Next
            ListView1.Items.Add(item)
        Next
    End Sub

    Private Sub Close_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Close_Button.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub Edit(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditStripMenuItem1.Click, ListView1.DoubleClick
        Try
            Dim selecteditem As ListViewItem = ListView1.SelectedItems.Item(0)

            For Each contact In Main.db.Contacts
                If (selecteditem.SubItems.Item(2).Text = contact.DisplayName) Then
                    Main.selected_contact = contact
                End If
            Next

            Show_Window(Edit_Contact)
            Update_Box()
        Catch ex As Exception

        End Try

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
            Dim selecteditems(ListView1.SelectedItems.Count - 1) As ListViewItem
            For x As Integer = 0 To ListView1.SelectedItems.Count - 1
                Dim selecteditem As ListViewItem = ListView1.SelectedItems.Item(x)
                selecteditems(x) = selecteditem
            Next

            If selecteditems.Count > 1 Then
                If My.Settings.showcdeleteprompt Then
                    If MsgBox("Are you sure you want to delete these contacts?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        For Each selectedc In selecteditems
                            Main.db.ExecuteCommand("DELETE FROM Contacts WHERE DisplayName='" + selectedc.SubItems.Item(2).Text + "'")
                        Next

                        Update_Box()

                        Main.StatusLabel.Text = "Deleted Contacts"
                    End If
                Else
                    ' Delete Without Prompt
                    For Each selectedc In selecteditems
                        Main.db.ExecuteCommand("DELETE FROM Contacts WHERE DisplayName='" + selectedc.SubItems.Item(2).Text + "'")
                    Next

                    Update_Box()

                    Main.StatusLabel.Text = "Deleted Contacts"
                End If
            Else
                ' Show Delete Prompt
                If My.Settings.showcdeleteprompt Then
                    If MsgBox("Are you sure you want to delete this contact?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Main.db.ExecuteCommand("DELETE FROM Contacts WHERE DisplayName='" + selecteditems(0).SubItems.Item(2).Text + "'")

                        Update_Box()

                        Main.StatusLabel.Text = "Deleted Contact"
                    End If
                Else
                    ' Delete Without Prompt
                    Main.db.ExecuteCommand("DELETE FROM Contacts WHERE DisplayName='" + selecteditems(0).SubItems.Item(2).Text + "'")

                    Update_Box()

                    Main.StatusLabel.Text = "Deleted Contact"
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub

    ' Sorting Method
    Dim m_SortingColumn As New ColumnHeader
    Private Sub ListView1_ColumnClick(ByVal sender As  _
        System.Object, ByVal e As  _
        System.Windows.Forms.ColumnClickEventArgs) Handles _
        ListView1.ColumnClick

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

    Private Sub HideShowButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideShowButton.Click
        Me.Enabled = False
        Columns.Show()
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
        Show_Window(Add_Contact)
        Update_Box()
    End Sub
End Class