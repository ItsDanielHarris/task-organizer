Public Class Add_Contact

    Private Sub ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok.Click
        Try

            Dim unique As Boolean = True
            Dim blank As Boolean = False

            Dim c As New Contact
            c.FirstName = first_nameTextBox.Text
            c.LastName = last_nameTextBox.Text
            c.DisplayName = displayname_TextBox.Text
            c.Nickname = nickname_TextBox.Text
            c.PrimaryEmail = primarymailTextBox.Text
            c.SecondaryEmail = secondarymailTextBox.Text
            c.ScreenName = screenTextBox.Text
            c.WorkPhone = wphoneTextBox.Text
            c.HomePhone = hphoneTextBox.Text
            c.FaxNumber = faxTextBox.Text
            c.PagerNumber = pagerTextBox.Text
            c.MobileNumber = mphoneTextBox.Text
            c.HomeAddress = hstreet1TextBox.Text
            c.HomeAddress2 = hstreet2TextBox.Text
            c.HomeCity = hcityTextBox.Text
            c.HomeState = hstateTextBox.Text
            c.HomeZipCode = hzipTextBox.Text
            c.HomeCountry = hcountryTextBox.Text
            c.WorkAddress = wstreet1TextBox.Text
            c.WorkAddress2 = wstreet2TextBox.Text
            c.WorkCity = wcityTextBox.Text
            c.WorkState = wstateTextBox.Text
            c.WorkZipCode = wzipTextBox.Text
            c.WorkCountry = wcountryTextBox.Text
            c.JobTitle = titleTextBox.Text
            c.Department = departmentTextBox.Text
            c.Organization = organizationTextBox.Text
            c.WebPage1 = page1TextBox.Text
            c.WebPage2 = page2TextBox.Text
            c.BirthYear = birthday_DateTimePicker.Value.Year
            c.BirthMonth = birthday_DateTimePicker.Value.Month
            c.BirthDay = birthday_DateTimePicker.Value.Day
            c.Groups = GroupTextBox.Text
            c.Gender = GenderBox.Text
            c.Picture = ""
            c.Custom4 = ""
            c.Notes = notesTextBox.Text

            For Each contact In Main.db.Contacts
                If c.DisplayName = contact.DisplayName Then
                    unique = False
                End If
            Next

            If c.DisplayName = "" Then
                blank = True
            End If

            If unique And Not blank Then
                Main.InsertRows(c, Nothing)

                'backup
                Dim displayname() As String = {c.DisplayName}
                Main.Backup(displayname, Nothing, 1)

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Dispose()
            Else
                If Not unique Then
                    MsgBox("There is another contact with the same display name.")
                End If
                If blank Then
                    MsgBox("Contact is missing a display name.")
                End If
            End If

        Catch ex As Exception
            MsgBox("There was a problem in creating the contact." & vbNewLine & "Error: " + ex.ToString)
        End Try

    End Sub

    Private Sub cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub Fill_Boxes()

        Dim unique As Boolean = True

        For Each contact In Main.db.Contacts
            'Groups
            Fill_Box(contact.Groups, unique, GroupTextBox)
            'Titles
            Fill_Box(contact.JobTitle, unique, titleTextBox)
            'Departments
            Fill_Box(contact.Department, unique, departmentTextBox)
            'Organizations
            Fill_Box(contact.Organization, unique, organizationTextBox)
            'Home Street 1
            Fill_Box(contact.HomeAddress, unique, hstreet1TextBox)
            'Home Street 2
            Fill_Box(contact.HomeAddress2, unique, hstreet2TextBox)
            'Home City
            Fill_Box(contact.HomeCity, unique, hcityTextBox)
            'Home State
            Fill_Box(contact.HomeState, unique, hstateTextBox)
            'Home Zip
            Fill_Box(contact.HomeZipCode, unique, hzipTextBox)
            'Home Country
            Fill_Box(contact.HomeCountry, unique, hcountryTextBox)
            'Work Street 1
            Fill_Box(contact.WorkAddress, unique, wstreet1TextBox)
            'Work Street 2
            Fill_Box(contact.WorkAddress2, unique, wstreet2TextBox)
            'Work City
            Fill_Box(contact.WorkCity, unique, wcityTextBox)
            'Work State
            Fill_Box(contact.WorkState, unique, wstateTextBox)
            'Work Zip
            Fill_Box(contact.WorkZipCode, unique, wzipTextBox)
            'Work Country
            Fill_Box(contact.WorkCountry, unique, wcountryTextBox)
            'Work Phone
            Fill_Box(contact.WorkPhone, unique, wphoneTextBox)
            'Home Phone
            Fill_Box(contact.HomePhone, unique, hphoneTextBox)
            'Fax
            Fill_Box(contact.FaxNumber, unique, faxTextBox)
            'Pager
            Fill_Box(contact.PagerNumber, unique, pagerTextBox)
            'Mobile
            Fill_Box(contact.MobileNumber, unique, mphoneTextBox)
            'Primary Email
            Fill_Box(contact.PrimaryEmail, unique, primarymailTextBox)
            'Secondary Email
            Fill_Box(contact.SecondaryEmail, unique, secondarymailTextBox)
            'Page 1
            Fill_Box(contact.WebPage1, unique, page1TextBox)
            'Page 2
            Fill_Box(contact.WebPage2, unique, page2TextBox)
            'Screenname
            Fill_Box(contact.ScreenName, unique, screenTextBox)
        Next
    End Sub

    Private Sub Fill_Box(ByVal contact_property As String, ByVal unique As Boolean, ByVal TextBox As ComboBox)
        If contact_property <> "" Or contact_property <> Nothing Then
            For Each item As String In TextBox.Items
                If item = contact_property Then
                    unique = False
                End If
            Next
            If unique Then
                TextBox.Items.Add(contact_property)
            End If
            unique = True
        End If
    End Sub

    Private Sub AutoDisplayName(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles first_nameTextBox.TextChanged, last_nameTextBox.TextChanged
        displayname_TextBox.Text = first_nameTextBox.Text + " " + last_nameTextBox.Text
        Me.Text = "Add Contact - " + displayname_TextBox.Text
    End Sub

    Private Sub Add_Contact_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Font = My.Settings.global_font
        Fill_Boxes()
        If Main.group Then
            GroupTextBox.Text = Main.cgroup
        End If
    End Sub

    Private Sub displayname_TextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles displayname_TextBox.TextChanged
        Me.Text = "Add Contact - " + displayname_TextBox.Text
    End Sub
End Class