Public Class Options

    Private Sub Options_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Contact Task Delete Prompt
        CheckBox1.Checked = Not My.Settings.showcdeleteprompt
        CheckBox3.Checked = Not My.Settings.showtdeleteprompt

        'Contact Task Edit Save Prompt
        CheckBoxX1.Checked = My.Settings.hidecsavechanges
        CheckBoxX2.Checked = My.Settings.hidetsavechanges

        'Global Font
        Me.Font = My.Settings.global_font
        fd.Font = My.Settings.global_font

        'Priority Colors
        LowColorBox.SelectedColor = My.Settings.priority_low
        NormalColorBox.SelectedColor = My.Settings.priority_normal
        HighColorBox.SelectedColor = My.Settings.priority_high
        LowFont.LinkColor = My.Settings.priorityf_low
        LowFont.BackColor = My.Settings.priority_low
        NormalFont.LinkColor = My.Settings.priorityf_normal
        NormalFont.BackColor = My.Settings.priority_normal
        HighFont.LinkColor = My.Settings.priorityf_high
        HighFont.BackColor = My.Settings.priority_high

        'Task View Options
        CheckBoxX3.Checked = My.Settings.showtaskcompletions
        CheckBoxX4.Checked = My.Settings.showtaskcolors

        'Minimize to Tray
        CheckBox2.Checked = My.Settings.minimizetotray

        'Username and Password
        UsernameBox.Text = My.Settings.username
        UserpassBox.Text = My.Settings.userpassword

        'Task Reminders
        CheckBoxX5.Checked = My.Settings.reminders
        ReminderMinutesSlider.Value = My.Settings.reminders_min

        TabControl1.SelectedTabIndex = 0

    End Sub

    Private Sub ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok.Click
        'Contact Task Delete Prompt
        My.Settings.showcdeleteprompt = Not CheckBox1.Checked
        My.Settings.showtdeleteprompt = Not CheckBox3.Checked

        'Contact Task Edit Save Prompt
        My.Settings.hidecsavechanges = CheckBoxX1.Checked
        My.Settings.hidetsavechanges = CheckBoxX2.Checked

        'Priority Colors
        My.Settings.priority_low = LowColorBox.SelectedColor
        My.Settings.priority_normal = NormalColorBox.SelectedColor
        My.Settings.priority_high = HighColorBox.SelectedColor
        My.Settings.priorityf_low = LowFont.LinkColor
        My.Settings.priorityf_normal = NormalFont.LinkColor
        My.Settings.priorityf_high = HighFont.LinkColor

        'Task View Options
        My.Settings.showtaskcompletions = CheckBoxX3.Checked
        My.Settings.showtaskcolors = CheckBoxX4.Checked
        Main.ShowCTasks.Checked = My.Settings.showtaskcompletions
        Main.ShowTaskColors.Checked = My.Settings.showtaskcolors

        'Task Reminders
        My.Settings.reminders = CheckBoxX5.Checked
        My.Settings.reminders_min = ReminderMinutesSlider.Value

        'Minimize to tray
        My.Settings.minimizetotray = CheckBox2.Checked

        'User Security
        My.Settings.username = UsernameBox.Text
        My.Settings.userpassword = UserpassBox.Text

        Me.Close()
    End Sub

    Private Sub cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancel.Click
        Me.Close()
    End Sub

    'Username and Password
    Private Sub SetButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveProfileButton.Click
        My.Settings.username = UsernameBox.Text
        My.Settings.userpassword = UserpassBox.Text
    End Sub

    'Task Back Color
    Private Sub FontBackColorChanged() Handles LowColorBox.SelectedColorChanged, NormalColorBox.SelectedColorChanged, HighColorBox.SelectedColorChanged
        LowFont.BackColor = LowColorBox.SelectedColor
        NormalFont.BackColor = NormalColorBox.SelectedColor
        HighFont.BackColor = HighColorBox.SelectedColor
    End Sub

    'Task Font Color
    Private Sub FontColorClicked(ByVal sender As LinkLabel, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LowFont.LinkClicked, NormalFont.LinkClicked, HighFont.LinkClicked
        ChooseColor(sender)
    End Sub

    Private Function ChooseColor(ByVal link As LinkLabel) As Color
        If cd.ShowDialog = DialogResult.OK Then
            link.LinkColor = cd.Color
        End If
    End Function

    'Global Font
    Private Sub FontLink_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles FontLink.LinkClicked
        If fd.ShowDialog = DialogResult.OK Then
            My.Settings.global_font = fd.Font
            Me.Font = My.Settings.global_font
            Main.Font = My.Settings.global_font
        End If
    End Sub

    'Reminder Value Changed
    Private Sub ReminderMinutesSlider_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReminderMinutesSlider.ValueChanged
        LabelX1.Text = ReminderMinutesSlider.Value.ToString + " Minutes"
    End Sub

End Class