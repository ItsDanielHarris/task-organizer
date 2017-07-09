Imports System.IO
Imports System.Threading

Public Class Main

    Public db As New SeaCowDataClassesDataContext

    Public selected_contacts As New List(Of String)
    Public selected_contact As Contact
    Public selected_task As New Task
    Public selected_tasks As New List(Of String)
    Public selected_group As String
    Public selected_groups As New List(Of String)
    Public selected_time As New Date

    Public isloading As New Boolean

    Public unedited_contacts As New List(Of Contact)
    Public unedited_tasks As New List(Of Task)
    Public edited_contacts As New List(Of Contact)
    Public edited_tasks As New List(Of Task)

    Public imported_contacts As New List(Of Contact)
    Public imported_tasks As New List(Of Task)
    Public exported_contacts As New List(Of Contact)
    Public exported_tasks As New List(Of Task)

    Public oldname As String

    Public group As Boolean = True
    Public cgroup As String = ""
    Public WithEvents GroupBox As New DevComponents.DotNetBar.Controls.ListViewEx

    Public history As New List(Of HistoryItem)

    'Update Functions
    Public Sub Update_Contact_Box()
        Try
            For Each l In SummaryBox.Controls
                l.Text = ""
            Next

            ContactBox.Nodes.Clear()
            ContactBox.Refresh()

            If SearchBox.Text = "" Then
                'Add Groups
                For Each contact In db.Contacts
                    Dim unique As Boolean = True
                    For Each n As DevComponents.AdvTree.Node In ContactBox.Nodes
                        If n.Text = contact.Groups Then
                            unique = False
                        End If
                    Next
                    If unique And contact.Groups <> "" Then
                        Dim c As New DevComponents.AdvTree.Node
                        c.Image = SmallIconList.Images(1)
                        c.Text = contact.Groups
                        ContactBox.Nodes.Add(c)
                    End If
                    'Add Contacts with no Groups
                    If contact.Groups = "" Then
                        Dim c As New DevComponents.AdvTree.Node
                        c.Image = SmallIconList.Images(0)
                        c.Text = contact.DisplayName
                        ContactBox.Nodes.Add(c)
                    End If
                Next

                'Add Contacts
                For Each n As DevComponents.AdvTree.Node In ContactBox.Nodes
                    For Each c In db.Contacts
                        If c.Groups = n.Text And c.Groups <> "" Then
                            Dim contact As New DevComponents.AdvTree.Node
                            contact.Image = SmallIconList.Images(0)
                            contact.Text = c.DisplayName
                            n.Nodes.Add(contact)
                        End If
                    Next
                Next

                'Add Searched Contacts
            Else
                selected_contacts.Clear()
                selected_groups.Clear()

                For Each c In db.Contacts
                    If ((c.Groups.Contains(SearchBox.Text) _
                         Or c.Groups.ToUpper.Contains(SearchBox.Text) _
                         Or c.Groups.ToLower.Contains(SearchBox.Text)) _
                         And SearchCategoryBox.SelectedIndex = 1) _
                    Then
                        If Not selected_groups.Contains(c.Groups) Then
                            selected_groups.Add(c.Groups)
                        End If
                    End If

                    If ((c.DisplayName.Contains(SearchBox.Text) _
                         Or c.DisplayName.ToUpper.Contains(SearchBox.Text) _
                         Or c.DisplayName.ToLower.Contains(SearchBox.Text)) _
                         And SearchCategoryBox.SelectedIndex = 0) Then

                        If Not selected_contacts.Contains(c.DisplayName) Then
                            selected_contacts.Add(c.DisplayName)
                        End If
                    End If
                Next

                'Add Searched Groups
                If selected_groups.Count > 0 Then
                    For Each g In selected_groups
                        Dim n As New DevComponents.AdvTree.Node
                        n.Image = SmallIconList.Images(1)
                        n.Text = g
                        ContactBox.Nodes.Add(n)
                    Next
                    For Each n As DevComponents.AdvTree.Node In ContactBox.Nodes
                        For Each c In db.Contacts
                            If c.Groups = n.Text Then
                                Dim contact As New DevComponents.AdvTree.Node
                                contact.Image = SmallIconList.Images(0)
                                contact.Text = c.DisplayName
                                n.Nodes.Add(contact)
                            End If
                        Next
                    Next
                End If





                'Add Searched Contacts

                'create sel contact list

                Dim sel_contacts As New List(Of Contact)
                For Each c In selected_contacts
                    For Each Contact In db.Contacts
                        If c = Contact.DisplayName Then
                            sel_contacts.Add(Contact)
                        End If
                    Next
                Next

                If sel_contacts.Count > 0 Then

                    'add all groups
                    For Each contact In db.Contacts
                        Dim unique As Boolean = True
                        For Each n As DevComponents.AdvTree.Node In ContactBox.Nodes
                            If n.Text = contact.Groups Or contact.Groups = "" Then
                                unique = False
                            End If
                        Next
                        If unique Then
                            Dim c As New DevComponents.AdvTree.Node
                            c.Image = SmallIconList.Images(1)
                            c.Text = contact.Groups
                            ContactBox.Nodes.Add(c)
                        End If
                        'Add Contacts with no Groups
                        If contact.Groups = "" Then
                            Dim match As Boolean = False
                            For Each con In sel_contacts
                                If con.DisplayName = contact.DisplayName Then
                                    match = True
                                End If
                            Next
                            If match Then
                                Dim c As New DevComponents.AdvTree.Node
                                c.Image = SmallIconList.Images(0)
                                c.Text = contact.DisplayName
                                ContactBox.Nodes.Add(c)
                            End If

                        End If
                    Next


                    'add contacts based on group
                    For Each n As DevComponents.AdvTree.Node In ContactBox.Nodes
                        For Each contact In sel_contacts
                            If contact.Groups = n.Text Then
                                Dim con As New DevComponents.AdvTree.Node
                                con.Image = SmallIconList.Images(0)
                                con.Text = contact.DisplayName
                                n.Nodes.Add(con)
                            End If
                        Next
                    Next



                End If


            End If

            'Expand Groups
            For Each n As DevComponents.AdvTree.Node In ContactBox.Nodes
                n.Expanded = True
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Public Sub Update_Task_Box()

        TaskBox.Items.Clear()

        If SearchBox2.Text = "" Then
            For Each task In db.Tasks
                If task.time.Date = TaskDatePicker.SelectedDate Then

                    Dim item As New ListViewItem(String.Format("{0:t}", task.time))
                    item.SubItems.Add(task.name)
                    item.SubItems.Add(task.priority)
                    item.SubItems.Add(task.status)

                    My.Settings.showtaskcolors = ShowTaskColors.Checked
                    My.Settings.showtaskcompletions = ShowCTasks.Checked

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

                    If My.Settings.showtaskcompletions = False Then
                        If task.status <> "Completed" Then
                            TaskBox.Items.Add(item)
                        End If
                    Else
                        TaskBox.Items.Add(item)
                    End If

                    For Each item In TaskBox.Items
                        For Each t In db.Tasks
                            If item.SubItems(1).Text = task.name Then
                                item.ToolTipText = task.description
                            End If
                        Next
                    Next

                End If
            Next
        Else
            selected_tasks.Clear()

            For Each t In db.Tasks
                If ((t.name.Contains(SearchBox2.Text) _
                     Or t.name.ToUpper.Contains(SearchBox2.Text) _
                     Or t.name.ToLower.Contains(SearchBox2.Text)) _
                     And SearchCategoryBox2.SelectedIndex = 0) _
                Then
                    If Not selected_tasks.Contains(t.name) Then
                        selected_tasks.Add(t.name)
                    End If
                End If

                If ((t.description.Contains(SearchBox2.Text) _
                     Or t.description.ToUpper.Contains(SearchBox2.Text) _
                     Or t.description.ToLower.Contains(SearchBox2.Text)) _
                     And SearchCategoryBox2.SelectedIndex = 1) Then

                    If Not selected_tasks.Contains(t.name) Then
                        selected_tasks.Add(t.name)
                    End If
                End If
            Next

            My.Settings.showtaskcolors = ShowTaskColors.Checked
            My.Settings.showtaskcompletions = ShowCTasks.Checked

            For Each t In db.Tasks
                For Each Task In selected_tasks
                    If t.name = Task Then
                        Dim item As New ListViewItem(String.Format("{0:t}", t.time))
                        item.SubItems.Add(t.name)
                        item.SubItems.Add(t.priority)
                        item.SubItems.Add(t.status)

                        If My.Settings.showtaskcolors Then
                            Dim color As New Color
                            Select Case t.priority
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

                        TaskBox.Items.Add(item)
                    End If
                Next
            Next


        End If



        If TaskBox.Items.Count > 0 Then
            TaskBox.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        End If

    End Sub

    Public Sub Update_Contact_Summary()

        Dim Contact As New Contact
        If selected_contact IsNot Nothing Then
            Contact = selected_contact
        End If

        GroupBox.Visible = False

        If Contact.DisplayName <> "" And Contact.DisplayName <> Nothing Then
            SummaryBox.TitleText = Contact.DisplayName
        End If

        For Each l In SplitContainer2.Panel1.Controls
            l.Show()
        Next
        For Each l In SplitContainer2.Panel2.Controls
            l.Show()
        Next

        Label4.Text = Contact.FirstName + " " + Contact.LastName
        Label32.Text = Contact.Groups
        Label34.Text = Contact.Nickname
        If Contact.BirthMonth <> "" Or Contact.BirthDay <> "" Or Contact.BirthYear <> "" Then
            Label36.Text = MonthName(Contact.BirthMonth) + " " + Contact.BirthDay + ", " + Contact.BirthYear
        Else
            Label36.Text = ""
        End If
        Label38.Text = Contact.JobTitle
        Label40.Text = Contact.Department
        Label42.Text = Contact.Organization
        Label44.Text = Contact.HomeAddress + " " + Contact.HomeAddress2
        Label45.Text = Contact.HomeCity + ", " + Contact.HomeState + " " + Contact.HomeZipCode
        Label48.Text = Contact.WorkAddress + " " + Contact.WorkAddress2
        Label47.Text = Contact.WorkCity + ", " + Contact.WorkState + " " + Contact.WorkZipCode
        Label50.Text = Contact.WorkPhone
        Label54.Text = Contact.HomePhone
        Label55.Text = Contact.FaxNumber
        Label56.Text = Contact.PagerNumber
        Label58.Text = Contact.MobileNumber
        pemail.Text = Contact.PrimaryEmail
        semail.Text = Contact.SecondaryEmail
        wp1.Text = Contact.WebPage1
        wp2.Text = Contact.WebPage2
        Label68.Text = Contact.ScreenName
    End Sub

    Public Sub Reset_Contact_Summary()
        SummaryBox.Text = ""

        Hide_Summary_Labels()

        EditContact.Hide()
        PrintContact.Hide()
        ExportContact.Hide()

    End Sub

    Public Sub Hide_Summary_Labels()
        For Each l In SplitContainer2.Panel1.Controls
            l.Hide()
        Next
        For Each l In SplitContainer2.Panel2.Controls
            l.Hide()
        Next
    End Sub

    'Main Load
    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        isloading = True

        Try
            If My.Settings.username <> "" And My.Settings.username <> "" Then
                Show_Window(UserPrompt)
            End If

            ReminderTimer.Start()

            If My.Settings.maximized Then
                Me.WindowState = FormWindowState.Maximized
            ElseIf My.Settings.minimized Then
                Me.WindowState = FormWindowState.Minimized
            Else
                Me.Size = My.Settings.size
                Me.Location = My.Settings.location
            End If

            Me.Text += " " + My.Application.Info.Version.ToString
            Me.Font = My.Settings.global_font
            ShowCTasks.Checked = My.Settings.showtaskcompletions
            ShowTaskColors.Checked = My.Settings.showtaskcolors

            TabControl1.SelectedTabIndex = My.Settings.selectedtabi

            SearchCategoryBox.SelectedIndex = 0
            SearchCategoryBox2.SelectedIndex = 0
            TaskDatePicker.DisplayMonth = Today
            TaskDatePicker.SelectedDate = Today

            GroupBox.Width = SplitContainer2.Panel1.Width + 5
            GroupBox.Height = SplitContainer2.Panel1.Height + 5
            GroupBox.Top = -1
            GroupBox.View = View.LargeIcon
            GroupBox.LargeImageList = LargeIconList
            GroupBox.ContextMenuStrip = ContextMenuStrip1
            SplitContainer2.Panel1.Controls.Add(GroupBox)

            If db.Contacts.Count > 0 Then
                Update_Contact_Box()
            End If
            If db.Tasks.Count > 0 Then
                Update_Task_Box()
            End If
        Catch ex As Exception

        End Try

    End Sub

    'Save Window Properties on Close
    Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
        MyBase.OnClosing(e)
        My.Settings.size = Me.Size
        Select Case Me.WindowState
            Case Is = FormWindowState.Maximized
                My.Settings.maximized = True
            Case Is = FormWindowState.Minimized
                My.Settings.minimized = True
            Case Else
                My.Settings.maximized = False
                My.Settings.minimized = False
                My.Settings.size = Me.Size
                My.Settings.location = Me.Location
        End Select
    End Sub

    'Main Click
    Private Sub Main_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Click, ContactBox.Click, SummaryBox.Click, GroupPanel1.Click, SplitContainer2.Click, GalleryContainer1.Click, RibbonControl1.Click, TabControl1.Click, TabControlPanel1.Click, TabControlPanel2.Click, TaskBox.Click, TaskDatePicker.Click
        StatusLabel.Text = "Ready"
    End Sub

    'Toolbar Buttons
    Private Sub New_Profile(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ribbon_NewProfile.Click, Ribbon_NewProfile2.Click
        Try
            If MsgBox("Are you sure?" & vbNewLine & "(This will erase all of your contacts and tasks.)", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                db.ExecuteCommand("DELETE Contacts")
                db.ExecuteCommand("DELETE Tasks")

                My.Settings.Reset()
                Application.Restart()

            End If
        Catch ex As Exception
            MsgBox("SeaCow encountered an error: " & vbNewLine & ex.ToString)
        End Try
    End Sub

    Private Sub Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ribbon_Exit.Click
        Me.Dispose()
    End Sub

    'Ribbon Buttons
    Private Sub About_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ribbon_About.Click
        Show_Window(About)
    End Sub

    Private Sub Undo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ribbon_Undo.Click, Ribbon_Undo2.Click
        Try
            Dim hi As HistoryItem = history(history.Count - 1)
            If hi.undo = 0 Then
                Select Case hi.action
                    Case Is = 1 'Undo Add
                        For Each c In hi.contacts
                            db.ExecuteCommand("DELETE FROM Contacts WHERE DisplayName='" + c.DisplayName + "'")
                        Next
                        For Each t In hi.tasks
                            db.ExecuteCommand("DELETE FROM Tasks WHERE name='" + t.name + "'")
                        Next
                    Case Is = 2 'Undo Edit
                        For Each c In unedited_contacts
                            UpdateRows(c, Nothing, Nothing)
                        Next
                        For Each t In unedited_tasks
                            UpdateRows(Nothing, t, Nothing)
                        Next
                    Case Is = 3 'Undo Delete
                        For Each c In hi.contacts
                            InsertRows(c, Nothing)
                        Next
                        For Each t In hi.tasks
                            InsertRows(Nothing, t)
                        Next
                End Select

                hi.undo = 1

                'Set status label
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
                StatusLabel.Text = text

                Update_Contact_Box()
                Update_Task_Box()

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Redo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ribbon_Redo.Click, Ribbon_Redo2.Click
        Try
            Dim hi As HistoryItem = history(history.Count - 1)
            If hi.undo = 1 Then
                Select Case hi.action
                    Case Is = 1 'Redo Add
                        For Each c In hi.contacts
                            InsertRows(c, Nothing)
                        Next
                        For Each t In hi.tasks
                            InsertRows(Nothing, t)
                        Next
                    Case Is = 2 'Redo Edit
                        For Each c In edited_contacts
                            UpdateRows(c, Nothing, Nothing)
                        Next
                        For Each t In edited_tasks
                            UpdateRows(Nothing, t, Nothing)
                        Next
                    Case Is = 3 'Redo Delete
                        For Each c In hi.contacts
                            db.ExecuteCommand("DELETE FROM Contacts WHERE DisplayName='" + c.DisplayName + "'")
                        Next
                        For Each t In hi.tasks
                            db.ExecuteCommand("DELETE FROM Tasks WHERE name='" + t.name + "'")
                        Next

                End Select

                hi.undo = 0

                'Set status label
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
                StatusLabel.Text = text

                Update_Contact_Box()
                Update_Task_Box()

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Add_Contact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ribbon_NewContact.Click, ContactToolStripMenuItem.Click
        If group And ContactBox.SelectedNodes.Count = 1 Then
            cgroup = ContactBox.SelectedNodes(0).Text
        End If
        Show_Window(Add_Contact)
        Update_Contact_Box()
    End Sub

    Private Sub Add_Task_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ribbon_NewTask.Click, TaskToolStripMenuItem.Click
        selected_time = TaskDatePicker.SelectedDate
        Show_Window(Add_Task)
        Update_Task_Box()
    End Sub

    Private Sub ViewContacts(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContactsLink.Click, Ribbon_ViewContacts.Click
        Show_Window(View_Contacts)
        Update_Contact_Box()
    End Sub

    Private Sub ViewTasks(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TasksLink.Click, Ribbon_ViewTasks.Click
        Show_Window(View_Tasks)
        Update_Task_Box()
    End Sub

    Private Sub Homepage(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ribbon_Homepage.Click
        Dim webAddress As String = "http://sourceforge.net/projects/seacow"
        Process.Start(webAddress)
    End Sub

    Private Sub Options_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ribbon_Options.Click, Ribbon_Options2.Click
        Show_Window(Options)
        Update_Contact_Box()
        Update_Task_Box()
    End Sub

    Private Sub Import_Contacts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ribbon_ImportContacts.Click, Menu_ImportContacts.Click
        ofd.Title = "Import Contacts"
        ofd.Filter = "CSV Files (*.csv)|*.csv|Text Files (*.txt)|*.txt"
        If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
            ImportContacts()
        End If
        Update_Contact_Box()
    End Sub

    Private Sub Import_Tasks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ribbon_ImportTasks.Click, Menu_ImportTasks.Click
        ofd.Title = "Import Tasks"
        ofd.Filter = "CSV Files (*.csv)|*.csv|Text Files (*.txt)|*.txt"
        If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
            ImportTasks()
        End If
        Update_Task_Box()
    End Sub

    Private Sub Export_Contacts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ribbon_ExportContacts.Click, Menu_ExportContacts.Click
        ExportAllContacts()
        Update_Contact_Box()
    End Sub

    Private Sub Export_Tasks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ribbon_ExportTasks.Click, Menu_ExportTasks.Click
        ExportAllTasks()
        Update_Task_Box()
    End Sub

    Private Sub ReadmeItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ribbon_Readme.Click
        If File.Exists("Readme.txt") Then
            Process.Start("Readme.txt")
        Else
            MsgBox("Could not find the Readme.txt file.")
        End If
    End Sub

    Private Sub HistoryButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ribbon_History.Click
        History_Window.Show()
    End Sub

    Private Sub Ribbon_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ribbon_Save.Click
        Try
            sfd.Title = "Save Database"
            sfd.Filter = "BAK Files (*.bak)|*.bak"
            If sfd.ShowDialog = DialogResult.OK Then
                Dim sql As String = "BACKUP DATABASE SeaCowDatabase TO DISK = '" + sfd.FileName + "'"
                db.ExecuteCommand(sql)
            End If
        Catch ex As Exception
            Clipboard.SetText(ex.ToString)
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Ribbon_Open_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ribbon_Open.Click
        Try
            ofd.Title = "Open Database"
            ofd.Filter = "BAK Files (*.bak)|*.bak"
            If ofd.ShowDialog = DialogResult.OK Then
                Dim sql As String = "RESTORE DATABASE SeaCowDatabase FROM DISK = '" + ofd.FileName + "''"
                db.ExecuteCommand(sql)
                Update_Contact_Box()
                Update_Task_Box()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    'Ribbon Menu Buttons
    Private Sub MenuPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem6.Click, ButtonItem19.Click
        If TabItem1.IsSelected Then
            Show_Window(frm_Print_Contacts)
        ElseIf TabItem2.IsSelected Then
            Show_Window(frm_Print_Tasks)
        End If
    End Sub

    'Add Recent Document
    Private Sub Add_Recent_Document(ByVal doc As String)
        Try
            Dim unique As Boolean = True
            For Each bi As DevComponents.DotNetBar.ButtonItem In GalleryContainer1.SubItems.OfType(Of DevComponents.DotNetBar.ButtonItem)()
                If bi.Text = doc Then
                    unique = False
                End If
            Next
            If unique Then
                Dim rdbutton As New DevComponents.DotNetBar.ButtonItem
                rdbutton.Text = doc
                AddHandler rdbutton.Click, AddressOf myClickHandler
                GalleryContainer1.SubItems.Add(rdbutton)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub myClickHandler( _
    ByVal sender As DevComponents.DotNetBar.ButtonItem, _
    ByVal e As System.EventArgs)
        If MsgBox("Would you like to import this file?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ofd.FileName = sender.Text
            ImportContacts()
            ImportTasks()
        End If
    End Sub

    'Delete Functions
    Private Sub Delete()
        If (ContactBox.Focused And ContactBox.SelectedNodes.Count > 0) Or (GroupBox.Focused And GroupBox.SelectedItems.Count > 0) Then

            Try
                Dim selectedcontacts, selectedgroups As New List(Of String)
                Dim group As Boolean = False

                If Not GroupBox.Focused Then
                    For Each sn As DevComponents.AdvTree.Node In ContactBox.SelectedNodes
                        'Check if group
                        group = False
                        For Each c In db.Contacts
                            If sn.Text = c.Groups Then
                                group = True
                            End If
                        Next
                        If Not group Then
                            selectedcontacts.Add(sn.Text)
                        Else
                            selectedgroups.Add(sn.Text)
                        End If
                    Next
                Else
                    For Each si As ListViewItem In GroupBox.SelectedItems
                        selectedcontacts.Add(si.Text)
                    Next
                End If




                'Groups
                For Each g In selectedgroups
                    For Each c In db.Contacts
                        If c.Groups = g Then
                            selectedcontacts.Add(c.DisplayName)
                        End If
                    Next
                Next

                'Multiple Contacts
                If selectedcontacts.Count > 1 Then
                    If My.Settings.showcdeleteprompt Then
                        If MsgBox("Are you sure you want to delete these contacts?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                            'backup
                            Backup(selectedcontacts.ToArray, Nothing, 3)

                            'delete
                            For Each selectedc In selectedcontacts
                                db.ExecuteCommand("DELETE FROM Contacts WHERE DisplayName='" + selectedc + "'")
                            Next

                            Update_Contact_Box()
                            Reset_Contact_Summary()
                        End If
                    Else
                        'backup
                        Backup(selectedcontacts.ToArray, Nothing, 3)

                        ' Delete Without Prompt
                        For Each selectedc In selectedcontacts
                            db.ExecuteCommand("DELETE FROM Contacts WHERE DisplayName='" + selectedc + "'")
                        Next

                        Update_Contact_Box()
                        Reset_Contact_Summary()
                    End If
                ElseIf selectedcontacts.Count = 1 Then
                    'Single Contact
                    ' Show Delete Prompt
                    If My.Settings.showcdeleteprompt Then
                        If MsgBox("Are you sure you want to delete this contact?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                            'backup
                            Backup(selectedcontacts.ToArray, Nothing, 3)

                            'delete
                            db.ExecuteCommand("DELETE FROM Contacts WHERE DisplayName='" + selectedcontacts(0) + "'")

                            Update_Contact_Box()
                            Reset_Contact_Summary()
                        End If
                    Else
                        ' Delete Without Prompt

                        'backup
                        Backup(selectedcontacts.ToArray, Nothing, 3)

                        'delete
                        db.ExecuteCommand("DELETE FROM Contacts WHERE DisplayName='" + selectedcontacts(0) + "'")

                        Update_Contact_Box()
                        Reset_Contact_Summary()
                    End If
                End If

            Catch ex As Exception
                MsgBox("Error: " + ex.ToString)
            End Try

        End If

        If TaskBox.Focused And TaskBox.SelectedItems.Count > 0 Then
            Try
                Dim selectedtasks(TaskBox.SelectedItems.Count - 1) As String
                For x As Integer = 0 To TaskBox.SelectedItems.Count - 1
                    Dim selectedtask As String = TaskBox.SelectedItems.Item(x).SubItems.Item(1).Text
                    selectedtasks(x) = selectedtask
                Next

                'Multiple Tasks
                If selectedtasks.Count > 1 Then
                    If My.Settings.showtdeleteprompt Then
                        If MsgBox("Are you sure you want to delete these tasks?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                            'backup
                            Backup(Nothing, selectedtasks, 3)

                            'delete
                            For Each t In selectedtasks
                                db.ExecuteCommand("DELETE FROM Tasks WHERE name='" + t + "'")
                            Next

                            Update_Task_Box()
                        End If
                    Else
                        'backup
                        Backup(Nothing, selectedtasks, 3)

                        'delete
                        For Each t In selectedtasks
                            db.ExecuteCommand("DELETE FROM Tasks WHERE name='" + t + "'")
                        Next

                        Update_Task_Box()
                    End If
                Else
                    'Single Contact
                    ' Show Delete Prompt
                    If My.Settings.showtdeleteprompt Then
                        If MsgBox("Are you sure you want to delete this task?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                            'backup
                            Backup(Nothing, selectedtasks, 3)

                            'delete
                            db.ExecuteCommand("DELETE FROM Tasks WHERE name='" + selectedtasks(0) + "'")

                            Update_Task_Box()
                        End If
                    Else
                        ' Delete Without Prompt

                        'backup
                        Backup(Nothing, selectedtasks, 3)

                        'delete
                        db.ExecuteCommand("DELETE FROM Tasks WHERE name='" + selectedtasks(0) + "'")

                        Update_Task_Box()
                    End If
                End If
            Catch ex As Exception
                MsgBox("Error: " + ex.ToString)
            End Try

        End If
    End Sub

    Private Sub DeletePressed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ContactBox.KeyDown, TaskBox.KeyDown, GroupBox.KeyDown
        If e.KeyCode = Keys.Delete Then
            Delete()
        End If
    End Sub

    Private Sub DeleteRightClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteStripMenuItem1.Click
        Delete()
    End Sub

    'Import/Export Functions
    Private Sub ImportContacts()
        Dim list As New List(Of String)

        ' Import Contacts
        Try

            Using MyReader As New  _
            Microsoft.VisualBasic.FileIO.TextFieldParser(ofd.FileName)
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(", ")
                Dim currentRow As String()
                'Skip first row
                Dim firstrow As String() = MyReader.ReadFields()
                Dim x As Integer = 0
                While Not MyReader.EndOfData
                    Try
                        currentRow = MyReader.ReadFields
                        For Each currentField As String In currentRow
                            If x < 37 Then
                                list.Add(currentField)
                                x += 1
                            End If
                        Next
                        x = 0
                    Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                        MsgBox("Line " & ex.Message & _
                        "is not valid and will be skipped.")
                    End Try
                End While
            End Using

            If (list.Count Mod 37) = 0 Then

                Dim min, max As Integer
                min = 0
                max = 36
                For x As Integer = 1 To (list.Count / 37)

                    Dim sql As String = "INSERT INTO Contacts VALUES ('"

                    For i As Integer = min To max

                        If i = max Then
                            sql += list.Item(i) + "'"
                        Else
                            sql += list.Item(i) + "', '"
                        End If

                    Next
                    sql += ")"

                    db.ExecuteCommand(sql)

                    min += 37
                    max += 37

                Next


                Add_Recent_Document(ofd.FileName)

                StatusLabel.Text = "Added " + (list.Count / 37).ToString + " contacts from " + ofd.FileName

                Update_Contact_Box()
                Update_Contact_Summary()
            Else
                Exit Try
            End If

        Catch ex As Exception
            MsgBox("Could not open the contact file." & vbNewLine & ex.Message)
            StatusLabel.Text = "Error Opening File"
        End Try
        ' End Import Text File
    End Sub

    Private Sub ImportTasks()
        Dim list As New List(Of String)

        ' Import Tasks
        Try

            Using MyReader As New  _
            Microsoft.VisualBasic.FileIO.TextFieldParser(ofd.FileName)
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(", ")
                Dim currentRow As String()
                'Skip first row
                Dim firstrow As String() = MyReader.ReadFields()
                Dim x As Integer = 0
                While Not MyReader.EndOfData
                    Try
                        currentRow = MyReader.ReadFields
                        For Each currentField As String In currentRow
                            If x < 5 Then
                                list.Add(currentField)
                                x += 1
                            End If
                        Next
                        x = 0
                    Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                        MsgBox("Line " & ex.Message & _
                        "is not valid and will be skipped.")
                    End Try
                End While
            End Using

            If (list.Count Mod 5) = 0 Then

                Dim min, max As Integer
                min = 0
                max = 4
                For x As Integer = 1 To (list.Count / 5)

                    Dim sql As String = "INSERT INTO Tasks VALUES ('"

                    For i As Integer = min To max

                        If i = max Then
                            sql += list.Item(i) + "'"
                        Else
                            sql += list.Item(i) + "', '"
                        End If

                    Next
                    sql += ")"

                    db.ExecuteCommand(sql)

                    min += 5
                    max += 5

                Next

                Add_Recent_Document(ofd.FileName)

                StatusLabel.Text = "Added " + (list.Count / 5).ToString + " tasks from " + ofd.FileName

                Update_Task_Box()
            Else
                Exit Try
            End If

        Catch ex As Exception
            MsgBox("Could not open the task file." & vbNewLine & ex.Message)
            StatusLabel.Text = "Error Opening File."
        End Try
        ' End Import Text File
    End Sub

    Private Sub ExportAllContacts()
        ' Export to Text File
        If ContactBox.SelectedNodes.Count = 0 Then
            Try
                sfd.Title = "Export Contacts"
                If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then

                    Dim myStream As Stream = sfd.OpenFile
                    If (myStream IsNot Nothing) Then
                        Using sw As StreamWriter = New StreamWriter(myStream)
                            For Each p As System.Reflection.PropertyInfo In selected_contact.GetType().GetProperties()
                                If p.CanRead Then
                                    sw.Write(p.Name + ", ")
                                End If
                            Next
                            sw.Write(vbNewLine)
                            For Each contact In db.Contacts

                                For Each p As System.Reflection.PropertyInfo In contact.GetType().GetProperties()
                                    If p.CanRead Then
                                        sw.Write(p.GetValue(contact, Nothing) + ", ")
                                    End If
                                Next

                                sw.Write(vbNewLine)
                            Next

                        End Using

                        myStream.Close()

                        StatusLabel.Text = "Exported Contacts to " + sfd.FileName
                    End If
                End If

            Catch ex As Exception
                MsgBox("Could not save the file." & vbNewLine & vbNewLine & "Error: " + ex.Message)
                StatusLabel.Text = "Error Saving File"
            End Try
        Else
            ExportSelectedContacts()
        End If

    End Sub

    Private Sub ExportAllTasks()
        If TaskBox.SelectedItems.Count = 0 Then
            Try
                sfd.Title = "Export Tasks"
                If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then

                    Dim myStream As Stream = sfd.OpenFile
                    If (myStream IsNot Nothing) Then
                        Using sw As StreamWriter = New StreamWriter(myStream)
                            For Each p As System.Reflection.PropertyInfo In selected_task.GetType().GetProperties()
                                If p.CanRead Then
                                    sw.Write(p.Name + ", ")
                                End If
                            Next
                            sw.Write(vbNewLine)
                            For Each task In db.Tasks

                                For Each p As System.Reflection.PropertyInfo In task.GetType().GetProperties()
                                    If p.CanRead Then
                                        sw.Write(p.GetValue(task, Nothing) + ", ")
                                    End If
                                Next

                                sw.Write(vbNewLine)

                            Next
                        End Using

                        myStream.Close()

                        StatusLabel.Text = "Exported Tasks to " + sfd.FileName
                    End If
                End If


            Catch ex As Exception
                MsgBox("Could not save the file." & vbNewLine & vbNewLine & "Error: " + ex.Message)
                StatusLabel.Text = "Error Saving File"
            End Try

        Else
            ExportSelectedTasks()
        End If

    End Sub

    Private Sub ExportSelectedContacts()
        If Not group Then
            sfd.Title = "Export Selected Contacts"
            If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
                Try

                    Dim myStream As Stream = sfd.OpenFile
                    If (myStream IsNot Nothing) Then
                        Using sw As StreamWriter = New StreamWriter(myStream)

                            exported_contacts.Clear()

                            For Each c In db.Contacts
                                For Each sn As DevComponents.AdvTree.Node In ContactBox.SelectedNodes
                                    If c.DisplayName = sn.Text Then
                                        exported_contacts.Add(c)
                                    End If
                                Next
                            Next

                            For Each p As System.Reflection.PropertyInfo In GetType(Contact).GetProperties()
                                If p.CanRead Then
                                    sw.Write(p.Name + ", ")
                                End If
                            Next
                            sw.Write(vbNewLine)

                            For Each c In exported_contacts
                                For Each p As System.Reflection.PropertyInfo In c.GetType().GetProperties()
                                    If p.CanRead Then
                                        sw.Write(p.GetValue(c, Nothing) + ", ")
                                    End If
                                Next
                                sw.Write(vbNewLine)
                            Next

                        End Using

                        myStream.Close()

                        StatusLabel.Text = "Exported Selected Contacts to " + sfd.FileName
                    End If
                Catch ex As Exception
                    MsgBox("Could not save the file." & vbNewLine & vbNewLine & "Error: " + ex.Message)
                    StatusLabel.Text = "Error Saving File"
                End Try
            End If
        Else
            sfd.Title = "Export Selected Groups"
            If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
                Try

                    Dim myStream As Stream = sfd.OpenFile
                    If (myStream IsNot Nothing) Then
                        Using sw As StreamWriter = New StreamWriter(myStream)

                            exported_contacts.Clear()

                            For Each c In db.Contacts
                                For Each sn As DevComponents.AdvTree.Node In ContactBox.SelectedNodes
                                    If c.Groups = sn.Text Then
                                        exported_contacts.Add(c)
                                    End If
                                Next
                            Next

                            For Each p As System.Reflection.PropertyInfo In GetType(Contact).GetProperties()
                                If p.CanRead Then
                                    sw.Write(p.Name + ", ")
                                End If
                            Next
                            sw.Write(vbNewLine)

                            For Each c In exported_contacts
                                For Each p As System.Reflection.PropertyInfo In c.GetType().GetProperties()
                                    If p.CanRead Then
                                        sw.Write(p.GetValue(c, Nothing) + ", ")
                                    End If
                                Next
                                sw.Write(vbNewLine)
                            Next

                        End Using

                        myStream.Close()

                        StatusLabel.Text = "Exported Selected Groups to " + sfd.FileName

                    End If
                Catch ex As Exception
                    MsgBox("Could not save the file." & vbNewLine & vbNewLine & "Error: " + ex.Message)
                    StatusLabel.Text = "Error Saving File"
                End Try
            End If
        End If

    End Sub

    Private Sub ExportSelectedTasks()
        sfd.Title = "Export Selected Tasks"
        If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try

                Dim myStream As Stream = sfd.OpenFile
                If (myStream IsNot Nothing) Then
                    Using sw As StreamWriter = New StreamWriter(myStream)

                        exported_tasks.Clear()

                        For Each t In db.Tasks
                            For Each si As ListViewItem In TaskBox.SelectedItems
                                If t.name = si.SubItems(1).Text Then
                                    exported_tasks.Add(t)
                                End If
                            Next
                        Next

                        For Each p As System.Reflection.PropertyInfo In GetType(Task).GetProperties()
                            If p.CanRead Then
                                sw.Write(p.Name + ", ")
                            End If
                        Next
                        sw.Write(vbNewLine)

                        For Each t In exported_tasks
                            For Each p As System.Reflection.PropertyInfo In t.GetType().GetProperties()
                                If p.CanRead Then
                                    sw.Write(p.GetValue(t, Nothing) + ", ")
                                End If
                            Next
                            sw.Write(vbNewLine)
                        Next

                    End Using

                    myStream.Close()

                    StatusLabel.Text = "Exported Selected Tasks to " + sfd.FileName
                End If
            Catch ex As Exception
                MsgBox("Could not save the file." & vbNewLine & vbNewLine & "Error: " + ex.Message)
                StatusLabel.Text = "Error Saving File"
            End Try
        End If
    End Sub

    Private Sub ExportContactLink_Click(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles ExportContact.LinkClicked
        ExportSelectedContacts()
    End Sub

    Private Sub ExportTaskLink_Click(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Export_Task_Link.LinkClicked
        ExportSelectedTasks()
    End Sub

    'Database Queries
    Public Sub UpdateRows(ByVal c As Contact, ByVal t As Task, ByVal i As Integer)

        Dim index As Integer = Nothing

        If i = Nothing Then
            i = history.Count - 1
        Else
            index = i
        End If

        Dim hi As HistoryItem = history(i)

        If c IsNot Nothing Then

            Dim sql As String = "UPDATE Contacts SET "
            For Each p As System.Reflection.PropertyInfo In c.GetType().GetProperties()
                If p.CanRead Then
                    sql += p.Name + "='" + p.GetValue(c, Nothing)
                    If p.Name <> "Notes" Then
                        sql += "', "
                    Else
                        sql += "' "
                    End If
                End If
            Next

            If hi.contacts.Count = 1 Then
                sql += "WHERE DisplayName='" + c.DisplayName + "'"
            Else
                If i = (history.Count - 1) Then
                    i = hi.contacts.Count - 1
                Else
                    i = index
                End If
                sql += "WHERE DisplayName='" + hi.contacts(i).DisplayName + "'"
            End If

            db.ExecuteCommand(sql)
        End If

        If t IsNot Nothing Then
            Dim sql As String = "UPDATE Tasks SET "
            For Each p As System.Reflection.PropertyInfo In t.GetType().GetProperties()
                If p.CanRead Then
                    sql += p.Name + "='" + p.GetValue(t, Nothing)
                    If p.Name <> "status" Then
                        sql += "', "
                    Else
                        sql += "' "
                    End If
                End If
            Next

            sql += "WHERE name='" + hi.tasks(hi.tasks.Count - 1).name + "'"
            db.ExecuteCommand(sql)
        End If

    End Sub

    Public Sub InsertRows(ByVal c As Contact, ByVal t As Task)
        If c IsNot Nothing Then
            Dim sql As String = "INSERT INTO Contacts VALUES("
            For Each p As System.Reflection.PropertyInfo In c.GetType().GetProperties()
                If p.CanRead Then
                    sql += "'" + p.GetValue(c, Nothing).ToString
                    If p.Name <> "Notes" Then
                        sql += "', "
                    Else
                        sql += "'"
                    End If
                End If
            Next
            sql += ")"
            db.ExecuteCommand(sql)
        End If

        If t IsNot Nothing Then
            Dim sql As String = "INSERT INTO Tasks VALUES("
            For Each p As System.Reflection.PropertyInfo In t.GetType().GetProperties()
                If p.CanRead Then
                    sql += "'" + p.GetValue(t, Nothing).ToString
                    If p.Name <> "status" Then
                        sql += "', "
                    Else
                        sql += "'"
                    End If
                End If
            Next
            sql += ")"
            db.ExecuteCommand(sql)
        End If
    End Sub

    'Events
    Private Sub Date_Changed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaskDatePicker.DateChanged
        Update_Task_Box()
    End Sub

    Private Sub ContactBoxClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContactBox.Click
        TaskBox.SelectedItems.Clear()
    End Sub

    Private Sub TaskBoxClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaskBox.Click
        ContactBox.SelectedNodes.Clear()
        Reset_Contact_Summary()
    End Sub

    Private Sub ContactNodeClicked(ByVal sender As System.Object, ByVal e As DevComponents.AdvTree.AdvTreeNodeEventArgs) Handles ContactBox.AfterNodeSelect
        Try
            TaskBox.SelectedItems.Clear()
            Dim item As String = e.Node.Text
            group = True

            For Each c In db.Contacts
                If c.DisplayName = item Then
                    selected_contact = c
                    group = False
                End If
            Next

            EditContact.Visible = True
            ExportContact.Visible = True
            PrintContact.Visible = True

            GroupBox.Items.Clear()

            If Not group Then
                Update_Contact_Summary()

            Else
                SummaryBox.TitleText = item
                Hide_Summary_Labels()
                GroupBox.Visible = True

                'Add Contact Links in Group
                If group Then

                    For Each c In db.Contacts
                        If c.Groups = item Then
                            Dim i As New ListViewItem
                            i.Text = c.DisplayName
                            i.ImageIndex = 0
                            GroupBox.Items.Add(i)
                        End If
                    Next

                End If

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TaskClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles TaskBox.ItemSelectionChanged
        Edit_Task_Link.Visible = True
        Export_Task_Link.Visible = True
        Print_Task_Link.Visible = True

        For Each t In db.Tasks
            If t.name = e.Item.SubItems(1).Text And e.IsSelected Then
                selected_task = t
            End If
        Next

    End Sub

    'Edit
    Private Sub EditClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditStripMenuItem1.Click, ContactBox.DoubleClick, Ribbon_EditSelection.Click, TaskBox.DoubleClick, GroupBox.DoubleClick
        Edit()
    End Sub

    Private Sub EditContactTaskLink(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles EditContact.LinkClicked, Edit_Task_Link.LinkClicked
        Edit()
    End Sub

    Private Sub Edit()
        Try
            If ContactBox.Focused Or ContactBox.SelectedNodes.Count > 0 Then
                If selected_contact IsNot Nothing And Not group Then
                    Show_Window(Edit_Contact)
                    Update_Contact_Box()
                    Update_Contact_Summary()
                ElseIf group Then
                    ContactBox.SelectedNode.BeginEdit()
                End If
            End If


            If GroupBox.SelectedItems.Count > 0 Then
                Dim selecteditem As String = GroupBox.SelectedItems(0).Text
                For Each contact In db.Contacts
                    If (selecteditem = contact.DisplayName) Then
                        selected_contact = contact
                    End If
                Next
                If selected_contact IsNot Nothing Then
                    Show_Window(Edit_Contact)
                    Update_Contact_Box()
                    Update_Contact_Summary()
                End If
            End If

            If TaskBox.SelectedItems.Count > 0 Then
                If selected_task IsNot Nothing Then
                    Show_Window(Edit_Task)
                    Update_Task_Box()
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    ' Sorting Task Columns
    Dim m_SortinGroupBoxolumn As New ColumnHeader
    Private Sub TaskListView_ColumnClick(ByVal sender As  _
        System.Object, ByVal e As  _
        System.Windows.Forms.ColumnClickEventArgs) Handles TaskBox.ColumnClick

        ' Get the new sorting column.
        Dim new_sorting_column As ColumnHeader = _
            TaskBox.Columns(e.Column)

        ' Figure out the new sorting order.
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortinGroupBoxolumn Is Nothing Then
            ' New column. Sort ascending.
            sort_order = System.Windows.Forms.SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(m_SortinGroupBoxolumn) Then
                ' Same column. Switch the sort order.
                If m_SortinGroupBoxolumn.Text.StartsWith("> ") Then
                    sort_order = System.Windows.Forms.SortOrder.Descending
                Else
                    sort_order = System.Windows.Forms.SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = System.Windows.Forms.SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            m_SortinGroupBoxolumn.Text = _
                m_SortinGroupBoxolumn.Text.Substring(2)
        End If

        ' Display the new sort order.
        m_SortinGroupBoxolumn = new_sorting_column
        If sort_order = System.Windows.Forms.SortOrder.Ascending Then
            m_SortinGroupBoxolumn.Text = "> " & m_SortinGroupBoxolumn.Text
        Else
            m_SortinGroupBoxolumn.Text = "< " & m_SortinGroupBoxolumn.Text
        End If

        ' Create a comparer.
        TaskBox.ListViewItemSorter = New  _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        TaskBox.Sort()
    End Sub

    ' Minimize to Tray
    Private Sub Minimize_Open(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenMenuItem.Click
        Me.Visible = True
        nfi.Visible = False
    End Sub

    Private Sub Minimize_DoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles nfi.MouseDoubleClick
        Me.Visible = True
        nfi.Visible = False
    End Sub

    Private Sub Minimize_Exit(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitMenuItem.Click
        Me.Dispose()
    End Sub

    'Main Resize
    Private Sub Main_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Select Case Me.WindowState
            Case FormWindowState.Minimized
                If My.Settings.minimizetotray Then
                    Me.Visible = False
                    nfi.Visible = True
                End If
            Case Else
                If TaskBox.Items.Count > 0 Then
                    TaskBox.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
                End If
                GroupBox.Width = SplitContainer2.Panel1.Width + 5
                GroupBox.Height = SplitContainer2.Panel1.Height + 5
                GroupBox.Top = -1
        End Select
    End Sub

    'Contact Summary
    Private Sub ContactLinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles pemail.LinkClicked, semail.LinkClicked, wp1.LinkClicked, wp2.LinkClicked
        GoToLink(sender)
    End Sub

    Private Sub GoToLink(ByVal link As LinkLabel)
        Dim webAddress As String = link.Text
        If link.Name.Contains("email") Then
            webAddress = "mailto:" + link.Text
        End If
        Process.Start(webAddress)
    End Sub

    'Printing
    Private Sub PrintContacts(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ribbon_PrintContacts.Click
        Show_Window(frm_Print_Contacts)
    End Sub

    Private Sub PrintIContact(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles PrintContact.LinkClicked
        My.Settings.printindividualc = True
        Show_Window(frm_Print_Contacts)
    End Sub

    Private Sub PrintTasks(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ribbon_PrintTasks.Click
        Show_Window(frm_Print_Tasks)
    End Sub

    Private Sub PrintITask(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Print_Task_Link.LinkClicked
        My.Settings.printindividualt = True
        Show_Window(frm_Print_Tasks)
    End Sub

    'History Backup Function
    Public Sub Backup(ByVal selectedcontacts() As String, ByVal selectedtasks() As String, ByVal action As Integer)
        Try

            Dim hi As New HistoryItem
            hi.action = action

            For Each c In edited_contacts
                hi.edited_contacts.Add(c)
            Next
            For Each c In unedited_contacts
                hi.unedited_contacts.Add(c)
            Next
            For Each t In edited_tasks
                hi.edited_tasks.Add(t)
            Next
            For Each t In unedited_tasks
                hi.unedited_tasks.Add(t)
            Next

            'Backup selected contacts
            If selectedcontacts IsNot Nothing Then
                For Each sc In selectedcontacts
                    Dim contact As New Contact
                    For Each c In db.Contacts
                        If sc = c.DisplayName Then
                            contact = c
                        End If
                    Next
                    If contact Is Nothing Then
                        Return
                    Else
                        hi.contacts.Add(contact)
                    End If
                Next
            End If

            'Backup selected tasks
            If selectedtasks IsNot Nothing Then
                For Each t In selectedtasks
                    Dim task As New Task
                    For Each task1 In db.Tasks
                        If t = task1.name Then
                            task = task1
                        End If
                    Next
                    If task Is Nothing Then
                        Return
                    Else
                        hi.tasks.Add(task)
                    End If
                Next
            End If

            'Set status label
            Dim text As String = ""
            Select Case hi.action
                Case Is = 1
                    text = "Added "
                Case Is = 2
                    text = "Edited "
                Case Is = 3
                    text = "Deleted "
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
            StatusLabel.Text = text

            hi.time = Now

            history.Add(hi)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    'Show Window Function
    Public Sub Show_Window(ByVal window As Form)
        Me.Enabled = False
        If window.ShowDialog = DialogResult.OK Then
            Me.Enabled = True
        Else
            Me.Enabled = True
        End If
    End Sub

    'Task Options
    Private Sub TaskOptions(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowCTasks.CheckedChanged, ShowTaskColors.CheckedChanged
        Update_Task_Box()
    End Sub

    'Search Box
    Private Sub SearchBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBox.TextChanged
        SearchDelayTimer.Stop()
        SearchDelayTimer.Start()
    End Sub

    Private Sub SearchBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBox2.TextChanged
        SearchDelayTimer2.Stop()
        SearchDelayTimer2.Start()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchDelayTimer.Tick
        SearchDelayTimer.Stop()
        Update_Contact_Box()
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchDelayTimer2.Tick
        SearchDelayTimer2.Stop()
        Update_Task_Box()
    End Sub

    Private Sub SearchBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SearchBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            SearchDelayTimer.Stop()
            Update_Contact_Box()
        End If
    End Sub

    Private Sub SearchBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SearchBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            SearchDelayTimer2.Stop()
            Update_Task_Box()
        End If
    End Sub

    'Before Group Edit
    Private Sub BeforeContactGroupEdit(ByVal sender As System.Object, ByVal e As DevComponents.AdvTree.CellEditEventArgs) Handles ContactBox.BeforeCellEdit
        For Each c In db.Contacts
            If e.Cell.Text = c.DisplayName Then
                e.Cancel = True
            Else
                oldname = e.Cell.Text
            End If
        Next
    End Sub

    'ContactBox Group Edits
    Private Sub RenameGroup(ByVal sender As System.Object, ByVal e As DevComponents.AdvTree.CellEditEventArgs) Handles ContactBox.AfterCellEdit
        If oldname <> e.NewText Then
            unedited_contacts.Clear()
            selected_contacts.Clear()
            For Each c In db.Contacts
                If c.Groups = oldname Then
                    unedited_contacts.Add(c)
                    selected_contacts.Add(c.DisplayName)
                End If
            Next
            Backup(selected_contacts.ToArray, Nothing, 2)

            Dim sql As String = "UPDATE Contacts SET Groups = '" + e.NewText + "' WHERE Groups = '" + oldname + "'"

            db.ExecuteCommand(sql)

            edited_contacts.Clear()
            For Each c In db.Contacts
                If c.Groups = e.NewText Then
                    edited_contacts.Add(c)
                End If
            Next

            'set selected contact
            For Each c In db.Contacts
                If c.DisplayName = SummaryBox.TitleText Then
                    selected_contact = c
                End If
            Next

            Update_Contact_Box()
            Update_Contact_Summary()
        Else
            e.Cancel = True
        End If
    End Sub

    'ContactBox Drag and Drop
    Private Sub ContactBeforeDrop(ByVal sender As System.Object, ByVal e As DevComponents.AdvTree.TreeDragDropEventArgs) Handles ContactBox.BeforeNodeDrop
        For Each c In db.Contacts
            If e.NewParentNode.Text = c.DisplayName Or e.Node.Text = c.Groups Then
                e.Cancel = True
            End If
        Next
    End Sub

    Private Sub ContactAfterDrop(ByVal sender As System.Object, ByVal e As DevComponents.AdvTree.TreeDragDropEventArgs) Handles ContactBox.AfterNodeDrop
        For Each c In db.Contacts
            If e.Node.Text = c.DisplayName Then
                selected_contact = c
            End If
        Next
        selected_contacts.Clear()
        selected_contacts.Add(selected_contact.DisplayName)

        If selected_contact.Groups <> e.NewParentNode.Text Then
            Backup(selected_contacts.ToArray, Nothing, 2)
            selected_contact.Groups = e.NewParentNode.Text
            UpdateRows(selected_contact, Nothing, Nothing)
            Update_Contact_Summary()
        End If

    End Sub

    'Selected Tab Change
    Private Sub SelectedTabChanged(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControl1.SelectedTabChanged
        My.Settings.selectedtabi = TabControl1.Tabs.IndexOf(e.NewTab)
    End Sub

    'Insert SQL Debug
    'Insert SQL
    'Private Sub SQL_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SQL_Button.Click
    '    Try
    '        db.ExecuteCommand(InputBox("Insert some SQL:", "Insert SQL", "", , ))
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    'End Sub

    'New Context Item Clicked

    'New Option on Context Menu
    Private Sub NewStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewStripMenuItem.Click
        If TabControl1.SelectedTab.Text = "Contacts" Then
            ContactToolStripMenuItem.PerformClick()
        ElseIf TabControl1.SelectedTab.Text = "Tasks" Then
            TaskToolStripMenuItem.PerformClick()
        End If
    End Sub

    'Task Reminders
    Private Sub ReminderTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReminderTimer.Tick
        For Each Task In db.Tasks
            If My.Settings.reminders Then
                If Task.time.Year = Now.Year And Task.time.Month = Now.Month And Task.time.Day = Now.Day _
                    And Task.time.Hour = Now.Hour And Now.Minute = Task.time.Minute - My.Settings.reminders_min Then
                    Dim Sound As New System.Media.SoundPlayer()
                    Sound.SoundLocation = "sound.wav"
                    Sound.Load()
                    Sound.Play()
                    MsgBox(Task.name + " (" + String.Format("{0:t}", Task.time) + ")" & vbNewLine & vbNewLine & Task.description, MsgBoxStyle.OkOnly, Task.name + " in " + My.Settings.reminders_min.ToString + " minute(s).")
                End If
            End If
        Next
    End Sub
End Class