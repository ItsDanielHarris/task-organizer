Public Class Columns

    Dim loading As Boolean = True

    Private Sub HideShow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Font = My.Settings.global_font

        For Each column As ColumnHeader In View_Contacts.ListView1.Columns
            Dim item As New ListViewItem(column.Text)
            ListView1.Items.Add(item)
            If column.Width = 0 Then
                ListView1.Items.Item(ListView1.Items.Count - 1).Checked = False
            Else
                ListView1.Items.Item(ListView1.Items.Count - 1).Checked = True
            End If
        Next
        loading = False
        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
    End Sub

    Private Sub cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancel.Click
        View_Contacts.Enabled = True
        Me.Dispose()
    End Sub

    Private Sub ListView1_Checked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles ListView1.ItemChecked
        If Not loading Then
            Dim selected_column As ListViewItem = e.Item
            If selected_column.Checked = False Then
                For Each column As ColumnHeader In View_Contacts.ListView1.Columns
                    If column.Text = selected_column.Text Then
                        column.Width = 0
                    End If
                Next
            Else
                For Each column As ColumnHeader In View_Contacts.ListView1.Columns
                    If column.Text = selected_column.Text Then
                        column.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
                    End If
                Next
            End If
        End If
    End Sub
End Class