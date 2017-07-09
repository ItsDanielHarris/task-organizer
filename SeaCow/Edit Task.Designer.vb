<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Edit_Task
    Inherits DevComponents.DotNetBar.Office2007Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Edit_Task))
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.ok = New DevComponents.DotNetBar.ButtonX()
        Me.cancel = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.TaskNameTxtBox = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TaskDescTxtBox = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ComboItem3 = New DevComponents.Editors.ComboItem()
        Me.StatusBox = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem4 = New DevComponents.Editors.ComboItem()
        Me.ComboItem5 = New DevComponents.Editors.ComboItem()
        Me.ComboItem6 = New DevComponents.Editors.ComboItem()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.ComboItem2 = New DevComponents.Editors.ComboItem()
        Me.ComboItem1 = New DevComponents.Editors.ComboItem()
        Me.TaskPriority = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.timebox = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.datebox = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        CType(Me.timebox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datebox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelX1
        '
        Me.LabelX1.Location = New System.Drawing.Point(27, 9)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(45, 23)
        Me.LabelX1.TabIndex = 59
        Me.LabelX1.Text = "Name:"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'ok
        '
        Me.ok.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ok.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ok.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ok.Location = New System.Drawing.Point(192, 203)
        Me.ok.Name = "ok"
        Me.ok.Size = New System.Drawing.Size(75, 23)
        Me.ok.TabIndex = 56
        Me.ok.Text = "&OK"
        '
        'cancel
        '
        Me.cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cancel.Location = New System.Drawing.Point(273, 203)
        Me.cancel.Name = "cancel"
        Me.cancel.Size = New System.Drawing.Size(75, 23)
        Me.cancel.TabIndex = 55
        Me.cancel.Text = "&Cancel"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        Me.LabelX4.Location = New System.Drawing.Point(7, 82)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(65, 23)
        Me.LabelX4.TabIndex = 60
        Me.LabelX4.Text = "Description:"
        Me.LabelX4.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        Me.LabelX5.Location = New System.Drawing.Point(27, 156)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(45, 23)
        Me.LabelX5.TabIndex = 61
        Me.LabelX5.Text = "Priority:"
        Me.LabelX5.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'TaskNameTxtBox
        '
        '
        '
        '
        Me.TaskNameTxtBox.Border.Class = "TextBoxBorder"
        Me.TaskNameTxtBox.Location = New System.Drawing.Point(78, 12)
        Me.TaskNameTxtBox.Name = "TaskNameTxtBox"
        Me.TaskNameTxtBox.Size = New System.Drawing.Size(270, 20)
        Me.TaskNameTxtBox.TabIndex = 57
        '
        'TaskDescTxtBox
        '
        '
        '
        '
        Me.TaskDescTxtBox.Border.Class = "TextBoxBorder"
        Me.TaskDescTxtBox.Location = New System.Drawing.Point(78, 85)
        Me.TaskDescTxtBox.Multiline = True
        Me.TaskDescTxtBox.Name = "TaskDescTxtBox"
        Me.TaskDescTxtBox.Size = New System.Drawing.Size(270, 68)
        Me.TaskDescTxtBox.TabIndex = 54
        '
        'ComboItem3
        '
        Me.ComboItem3.Text = "High"
        '
        'StatusBox
        '
        Me.StatusBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.StatusBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.StatusBox.DisplayMember = "Text"
        Me.StatusBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.StatusBox.FormattingEnabled = True
        Me.StatusBox.ItemHeight = 14
        Me.StatusBox.Items.AddRange(New Object() {Me.ComboItem4, Me.ComboItem5, Me.ComboItem6})
        Me.StatusBox.Location = New System.Drawing.Point(246, 159)
        Me.StatusBox.Name = "StatusBox"
        Me.StatusBox.Size = New System.Drawing.Size(102, 20)
        Me.StatusBox.TabIndex = 52
        '
        'ComboItem4
        '
        Me.ComboItem4.Text = "Started"
        '
        'ComboItem5
        '
        Me.ComboItem5.Text = "Working"
        '
        'ComboItem6
        '
        Me.ComboItem6.Text = "Completed"
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        Me.LabelX6.Location = New System.Drawing.Point(200, 156)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(40, 23)
        Me.LabelX6.TabIndex = 62
        Me.LabelX6.Text = "Status:"
        Me.LabelX6.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "Normal"
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "Low"
        '
        'TaskPriority
        '
        Me.TaskPriority.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TaskPriority.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TaskPriority.DisplayMember = "Text"
        Me.TaskPriority.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.TaskPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TaskPriority.FormattingEnabled = True
        Me.TaskPriority.ItemHeight = 14
        Me.TaskPriority.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2, Me.ComboItem3})
        Me.TaskPriority.Location = New System.Drawing.Point(78, 159)
        Me.TaskPriority.Name = "TaskPriority"
        Me.TaskPriority.Size = New System.Drawing.Size(80, 20)
        Me.TaskPriority.TabIndex = 53
        '
        'timebox
        '
        '
        '
        '
        Me.timebox.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.timebox.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
        Me.timebox.Location = New System.Drawing.Point(260, 50)
        '
        '
        '
        Me.timebox.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.timebox.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.timebox.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.timebox.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.timebox.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.timebox.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.timebox.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.timebox.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.timebox.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.timebox.MonthCalendar.DisplayMonth = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.timebox.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.timebox.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.timebox.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.timebox.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.timebox.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.timebox.MonthCalendar.TodayButtonVisible = True
        Me.timebox.Name = "timebox"
        Me.timebox.ShowUpDown = True
        Me.timebox.Size = New System.Drawing.Size(88, 20)
        Me.timebox.TabIndex = 63
        '
        'LabelX2
        '
        Me.LabelX2.Location = New System.Drawing.Point(4, 47)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(68, 23)
        Me.LabelX2.TabIndex = 64
        Me.LabelX2.Text = "Due/Date:"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'datebox
        '
        '
        '
        '
        Me.datebox.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.datebox.ButtonDropDown.Visible = True
        Me.datebox.Format = DevComponents.Editors.eDateTimePickerFormat.[Long]
        Me.datebox.Location = New System.Drawing.Point(78, 50)
        '
        '
        '
        Me.datebox.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.datebox.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.datebox.MonthCalendar.DisplayMonth = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.datebox.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.datebox.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        Me.datebox.Name = "datebox"
        Me.datebox.Size = New System.Drawing.Size(176, 20)
        Me.datebox.TabIndex = 76
        '
        'Edit_Task
        '
        Me.AcceptButton = Me.ok
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.CancelButton = Me.cancel
        Me.ClientSize = New System.Drawing.Size(360, 238)
        Me.Controls.Add(Me.datebox)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.timebox)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.ok)
        Me.Controls.Add(Me.cancel)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.TaskNameTxtBox)
        Me.Controls.Add(Me.TaskDescTxtBox)
        Me.Controls.Add(Me.StatusBox)
        Me.Controls.Add(Me.LabelX6)
        Me.Controls.Add(Me.TaskPriority)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Edit_Task"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit Task"
        CType(Me.timebox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datebox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ok As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TaskNameTxtBox As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TaskDescTxtBox As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ComboItem3 As DevComponents.Editors.ComboItem
    Friend WithEvents StatusBox As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem4 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem5 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem6 As DevComponents.Editors.ComboItem
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents TaskPriority As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents timebox As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents datebox As DevComponents.Editors.DateTimeAdv.DateTimeInput
End Class
