Public Class Edit_Contact

    Dim edited As New Boolean

    Private Sub ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok.Click
        Try
            Main.unedited_contacts.Clear()
            Main.unedited_contacts.Add(Main.selected_contact)

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
            c.Gender = GenderBox.SelectedItem.ToString
            c.Picture = ""
            c.Custom4 = ""
            c.Notes = notesTextBox.Text

            Dim unique As Boolean = True
            Dim blank As Boolean = False
            For Each contact In Main.db.Contacts
                If c.DisplayName = contact.DisplayName And c.DisplayName <> Main.selected_contact.DisplayName Then
                    unique = False
                End If
            Next
            If c.DisplayName = "" Then
                blank = True
            End If

            If unique And Not blank Then
                Main.edited_tasks.Clear()
                Main.unedited_tasks.Clear()
                Main.edited_contacts.Clear()
                Main.edited_contacts.Add(c)

                Dim displayname() As String = {Main.selected_contact.DisplayName}
                Main.Backup(displayname, Nothing, 2)

                Main.UpdateRows(c, Nothing, Nothing)
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
            MsgBox("There was a problem in editing the contact." & vbNewLine & "Error: " + ex.ToString)
        End Try

    End Sub

    Private Sub cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancel.Click
        If My.Settings.hidecsavechanges Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Dispose()
        Else
            If MsgBox("Do you want to save the contact first?", MsgBoxStyle.YesNo, "Save Contact?") = MsgBoxResult.Yes Then
                ok.PerformClick()
            Else
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Dispose()
            End If
        End If

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

    Private Sub Edit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Font = My.Settings.global_font

            Fill_Boxes()

            Dim contact As Contact = Main.selected_contact

            Me.Text += " - " + contact.DisplayName

            first_nameTextBox.Text = contact.FirstName
            last_nameTextBox.Text = contact.LastName
            displayname_TextBox.Text = contact.DisplayName
            GenderBox.Text = contact.Gender
            nickname_TextBox.Text = contact.Nickname
            primarymailTextBox.Text = contact.PrimaryEmail
            secondarymailTextBox.Text = contact.SecondaryEmail
            screenTextBox.Text = contact.ScreenName
            wphoneTextBox.Text = contact.WorkPhone
            hphoneTextBox.Text = contact.HomePhone
            faxTextBox.Text = contact.FaxNumber
            pagerTextBox.Text = contact.PagerNumber
            mphoneTextBox.Text = contact.MobileNumber
            hstreet1TextBox.Text = contact.HomeAddress
            hstreet2TextBox.Text = contact.HomeAddress2
            hcityTextBox.Text = contact.HomeCity
            hstateTextBox.Text = contact.HomeState
            hzipTextBox.Text = contact.HomeZipCode
            hcountryTextBox.Text = contact.HomeCountry
            wstreet1TextBox.Text = contact.WorkAddress
            wstreet2TextBox.Text = contact.WorkAddress2
            wcityTextBox.Text = contact.WorkCity
            wstateTextBox.Text = contact.WorkState
            wzipTextBox.Text = contact.WorkZipCode
            wcountryTextBox.Text = contact.WorkCountry
            titleTextBox.Text = contact.JobTitle
            departmentTextBox.Text = contact.Department
            organizationTextBox.Text = contact.Organization
            page1TextBox.Text = contact.WebPage1
            page2TextBox.Text = contact.WebPage2
            notesTextBox.Text = contact.Notes
            GroupTextBox.Text = contact.Groups
            If contact.BirthMonth <> "" Or contact.BirthDay <> "" Or contact.BirthYear <> "" Then
                Dim birthdate As Date = New Date(Integer.Parse(contact.BirthYear), Integer.Parse(contact.BirthMonth), Integer.Parse(contact.BirthDay))
                birthday_DateTimePicker.Value = birthdate
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub AutoDisplayName(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles first_nameTextBox.TextChanged, last_nameTextBox.TextChanged
        displayname_TextBox.Text = first_nameTextBox.Text + " " + last_nameTextBox.Text
    End Sub

End Class