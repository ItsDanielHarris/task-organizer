Public Class frm_Print_Tasks

    Private Sub View_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TasksTableAdapter.Fill(Me.SeaCowDatabaseDataSet.Tasks)

        Me.Font = My.Settings.global_font

        ListView1.Items.Clear()

        For Each task In Main.db.Tasks
            Dim item As New ListViewItem(task.name.ToString)
            item.SubItems.Add(String.Format("{0:d}", task.time.Date))
            item.SubItems.Add(String.Format("{0:t}", task.time))
            ListView1.Items.Add(item)
        Next

        If ListView1.Items.Count > 0 Then
            ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        End If

        Select Case Main.TaskBox.SelectedItems.Count
            Case Is = 0
                For Each item In ListView1.Items
                    item.Checked = True
                Next
            Case Is >= 1
                For Each item As ListViewItem In Main.TaskBox.SelectedItems
                    For Each i As ListViewItem In ListView1.Items
                        If item.SubItems(1).Text = i.Text Then
                            i.Checked = True
                        End If
                    Next
                Next
        End Select

        Fill_Report()

    End Sub

    Private Sub Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles close_button.Click
        Me.Dispose()
    End Sub

    Private Sub Form_Closed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub ItemChecked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles ListView1.ItemChecked
        Fill_Report()
    End Sub

    Private Sub Select_All(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAll.Click
        For Each item In ListView1.Items
            item.Checked = True
        Next
    End Sub

    Private Sub Select_None(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectNone.Click
        For Each item In ListView1.Items
            item.Checked = False
        Next
    End Sub

    Private Sub ListView_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If ListView1.Items.Count > 0 Then
            ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        End If
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

        ' Refresh resultTextBox
        For Each item In ListView1.CheckedItems
            Dim sitem As ListViewItem = item
            sitem.Checked = False
            sitem.Checked = True
        Next
    End Sub

    Private Sub setup_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles setup_button.Click
        ReportViewer1.PageSetupDialog()
    End Sub

    Private Sub print_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles print_button.Click
        ReportViewer1.PrintDialog()
    End Sub

    Private Sub Fill_Report()
        Try
            Me.TasksTableAdapter.Fill(Me.SeaCowDatabaseDataSet.Tasks)

            For Each row As DataRow In SeaCowDatabaseDataSet.Tasks.Select()
                Dim match As New Boolean
                For Each t As ListViewItem In ListView1.Items
                    If t.Checked Then
                        If CType(row("name"), String) = t.Text Then
                            match = True
                        End If
                    End If
                Next
                If Not match Then
                    row.Delete()
                End If
            Next

            SeaCowDatabaseDataSet.Tasks.AcceptChanges()

            Me.TasksTableAdapter.Update(Me.SeaCowDatabaseDataSet.Tasks)
            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

End Class