Public Class HistoryItem

    Public contacts As New List(Of Contact)
    Public tasks As New List(Of Task)
    Public edited_contacts As New List(Of Contact)
    Public edited_tasks As New List(Of Task)
    Public unedited_contacts As New List(Of Contact)
    Public unedited_tasks As New List(Of Task)
    Public action As New Integer
    Public undo As Integer = 0
    Public time As New Date

End Class
