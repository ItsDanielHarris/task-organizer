<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Options
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Options))
        Me.cd = New System.Windows.Forms.ColorDialog()
        Me.cancel = New DevComponents.DotNetBar.ButtonX()
        Me.ok = New DevComponents.DotNetBar.ButtonX()
        Me.fd = New System.Windows.Forms.FontDialog()
        Me.TabControl1 = New DevComponents.DotNetBar.TabControl()
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.SaveProfileButton = New DevComponents.DotNetBar.ButtonX()
        Me.Label3 = New DevComponents.DotNetBar.LabelX()
        Me.UserpassBox = New System.Windows.Forms.TextBox()
        Me.UsernameBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New DevComponents.DotNetBar.LabelX()
        Me.FontLink = New System.Windows.Forms.LinkLabel()
        Me.CheckBox2 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TabItem1 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel()
        Me.CheckBoxX1 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CheckBox1 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TabItem2 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel3 = New DevComponents.DotNetBar.TabControlPanel()
        Me.CheckBoxX5 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.ReminderMinutesSlider = New DevComponents.DotNetBar.Controls.Slider()
        Me.CheckBoxX4 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CheckBoxX3 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CheckBoxX2 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.HighFont = New System.Windows.Forms.LinkLabel()
        Me.Label5 = New DevComponents.DotNetBar.LabelX()
        Me.NormalFont = New System.Windows.Forms.LinkLabel()
        Me.Label6 = New DevComponents.DotNetBar.LabelX()
        Me.LowFont = New System.Windows.Forms.LinkLabel()
        Me.NormalColorBox = New mkc_ColorCombobox.mkc_ColorCombobox()
        Me.LowColorBox = New mkc_ColorCombobox.mkc_ColorCombobox()
        Me.HighColorBox = New mkc_ColorCombobox.mkc_ColorCombobox()
        Me.Label7 = New DevComponents.DotNetBar.LabelX()
        Me.CheckBox3 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TabItem3 = New DevComponents.DotNetBar.TabItem(Me.components)
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabControlPanel1.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.TabControlPanel2.SuspendLayout()
        Me.TabControlPanel3.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cancel
        '
        Me.cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cancel.Location = New System.Drawing.Point(323, 203)
        Me.cancel.Name = "cancel"
        Me.cancel.Size = New System.Drawing.Size(75, 23)
        Me.cancel.TabIndex = 3
        Me.cancel.Text = "&Cancel"
        '
        'ok
        '
        Me.ok.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ok.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ok.Location = New System.Drawing.Point(242, 203)
        Me.ok.Name = "ok"
        Me.ok.Size = New System.Drawing.Size(75, 23)
        Me.ok.TabIndex = 4
        Me.ok.Text = "&OK"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.AntiAlias = True
        Me.TabControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.TabControl1.CanReorderTabs = True
        Me.TabControl1.Controls.Add(Me.TabControlPanel1)
        Me.TabControl1.Controls.Add(Me.TabControlPanel2)
        Me.TabControl1.Controls.Add(Me.TabControlPanel3)
        Me.TabControl1.Location = New System.Drawing.Point(0, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControl1.SelectedTabIndex = 1
        Me.TabControl1.Size = New System.Drawing.Size(410, 180)
        Me.TabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Document
        Me.TabControl1.TabIndex = 5
        Me.TabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl1.Tabs.Add(Me.TabItem1)
        Me.TabControl1.Tabs.Add(Me.TabItem2)
        Me.TabControl1.Tabs.Add(Me.TabItem3)
        Me.TabControl1.Text = "TabControl1"
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.GroupPanel1)
        Me.TabControlPanel1.Controls.Add(Me.FontLink)
        Me.TabControlPanel1.Controls.Add(Me.CheckBox2)
        Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel1.Location = New System.Drawing.Point(0, 22)
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel1.Size = New System.Drawing.Size(410, 158)
        Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(157, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel1.Style.GradientAngle = 90
        Me.TabControlPanel1.TabIndex = 1
        Me.TabControlPanel1.TabItem = Me.TabItem1
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.SaveProfileButton)
        Me.GroupPanel1.Controls.Add(Me.Label3)
        Me.GroupPanel1.Controls.Add(Me.UserpassBox)
        Me.GroupPanel1.Controls.Add(Me.UsernameBox)
        Me.GroupPanel1.Controls.Add(Me.Label4)
        Me.GroupPanel1.Location = New System.Drawing.Point(23, 41)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(330, 100)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.GroupPanel1.TabIndex = 12
        Me.GroupPanel1.Text = "User Security (leave blank to disable)"
        '
        'SaveProfileButton
        '
        Me.SaveProfileButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.SaveProfileButton.Location = New System.Drawing.Point(231, 30)
        Me.SaveProfileButton.Name = "SaveProfileButton"
        Me.SaveProfileButton.Size = New System.Drawing.Size(75, 23)
        Me.SaveProfileButton.TabIndex = 4
        Me.SaveProfileButton.Text = "&Save"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 15)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Username:"
        '
        'UserpassBox
        '
        Me.UserpassBox.Location = New System.Drawing.Point(68, 32)
        Me.UserpassBox.Name = "UserpassBox"
        Me.UserpassBox.Size = New System.Drawing.Size(124, 20)
        Me.UserpassBox.TabIndex = 3
        '
        'UsernameBox
        '
        Me.UsernameBox.Location = New System.Drawing.Point(68, 3)
        Me.UsernameBox.Name = "UsernameBox"
        Me.UsernameBox.Size = New System.Drawing.Size(124, 20)
        Me.UsernameBox.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 15)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Password:"
        '
        'FontLink
        '
        Me.FontLink.AutoSize = True
        Me.FontLink.BackColor = System.Drawing.Color.Transparent
        Me.FontLink.Location = New System.Drawing.Point(20, 18)
        Me.FontLink.Name = "FontLink"
        Me.FontLink.Size = New System.Drawing.Size(80, 13)
        Me.FontLink.TabIndex = 11
        Me.FontLink.TabStop = True
        Me.FontLink.Text = "Set Global Font"
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox2.Location = New System.Drawing.Point(204, 18)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(137, 15)
        Me.CheckBox2.TabIndex = 10
        Me.CheckBox2.Text = "Minimize to system tray"
        '
        'TabItem1
        '
        Me.TabItem1.AttachedControl = Me.TabControlPanel1
        Me.TabItem1.Name = "TabItem1"
        Me.TabItem1.Text = "General"
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.CheckBoxX1)
        Me.TabControlPanel2.Controls.Add(Me.CheckBox1)
        Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel2.Location = New System.Drawing.Point(0, 22)
        Me.TabControlPanel2.Name = "TabControlPanel2"
        Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel2.Size = New System.Drawing.Size(410, 158)
        Me.TabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(157, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel2.Style.GradientAngle = 90
        Me.TabControlPanel2.TabIndex = 2
        Me.TabControlPanel2.TabItem = Me.TabItem2
        '
        'CheckBoxX1
        '
        Me.CheckBoxX1.AutoSize = True
        Me.CheckBoxX1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxX1.Location = New System.Drawing.Point(12, 36)
        Me.CheckBoxX1.Name = "CheckBoxX1"
        Me.CheckBoxX1.Size = New System.Drawing.Size(129, 15)
        Me.CheckBoxX1.TabIndex = 12
        Me.CheckBoxX1.Text = "Hide edit save prompt"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.Location = New System.Drawing.Point(12, 15)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(115, 15)
        Me.CheckBox1.TabIndex = 11
        Me.CheckBox1.Text = "Hide delete prompt"
        '
        'TabItem2
        '
        Me.TabItem2.AttachedControl = Me.TabControlPanel2
        Me.TabItem2.Name = "TabItem2"
        Me.TabItem2.Text = "Contacts"
        '
        'TabControlPanel3
        '
        Me.TabControlPanel3.Controls.Add(Me.CheckBoxX5)
        Me.TabControlPanel3.Controls.Add(Me.LabelX1)
        Me.TabControlPanel3.Controls.Add(Me.ReminderMinutesSlider)
        Me.TabControlPanel3.Controls.Add(Me.CheckBoxX4)
        Me.TabControlPanel3.Controls.Add(Me.CheckBoxX3)
        Me.TabControlPanel3.Controls.Add(Me.CheckBoxX2)
        Me.TabControlPanel3.Controls.Add(Me.GroupPanel2)
        Me.TabControlPanel3.Controls.Add(Me.CheckBox3)
        Me.TabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel3.Location = New System.Drawing.Point(0, 22)
        Me.TabControlPanel3.Name = "TabControlPanel3"
        Me.TabControlPanel3.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel3.Size = New System.Drawing.Size(410, 158)
        Me.TabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(157, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.TabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.TabControlPanel3.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel3.Style.GradientAngle = 90
        Me.TabControlPanel3.TabIndex = 3
        Me.TabControlPanel3.TabItem = Me.TabItem3
        '
        'CheckBoxX5
        '
        Me.CheckBoxX5.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxX5.Location = New System.Drawing.Point(12, 124)
        Me.CheckBoxX5.Name = "CheckBoxX5"
        Me.CheckBoxX5.Size = New System.Drawing.Size(21, 23)
        Me.CheckBoxX5.TabIndex = 25
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        Me.LabelX1.Location = New System.Drawing.Point(271, 124)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(79, 23)
        Me.LabelX1.TabIndex = 24
        Me.LabelX1.Text = "Minutes"
        '
        'ReminderMinutesSlider
        '
        Me.ReminderMinutesSlider.BackColor = System.Drawing.Color.Transparent
        Me.ReminderMinutesSlider.LabelWidth = 80
        Me.ReminderMinutesSlider.Location = New System.Drawing.Point(30, 124)
        Me.ReminderMinutesSlider.Name = "ReminderMinutesSlider"
        Me.ReminderMinutesSlider.Size = New System.Drawing.Size(235, 23)
        Me.ReminderMinutesSlider.TabIndex = 23
        Me.ReminderMinutesSlider.Text = "Remind me in:"
        Me.ReminderMinutesSlider.Value = 15
        '
        'CheckBoxX4
        '
        Me.CheckBoxX4.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxX4.Location = New System.Drawing.Point(12, 83)
        Me.CheckBoxX4.Name = "CheckBoxX4"
        Me.CheckBoxX4.Size = New System.Drawing.Size(145, 15)
        Me.CheckBoxX4.TabIndex = 22
        Me.CheckBoxX4.Text = "Show Task Colors"
        '
        'CheckBoxX3
        '
        Me.CheckBoxX3.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxX3.Location = New System.Drawing.Point(12, 62)
        Me.CheckBoxX3.Name = "CheckBoxX3"
        Me.CheckBoxX3.Size = New System.Drawing.Size(145, 15)
        Me.CheckBoxX3.TabIndex = 21
        Me.CheckBoxX3.Text = "Show Completed Tasks"
        '
        'CheckBoxX2
        '
        Me.CheckBoxX2.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxX2.Location = New System.Drawing.Point(12, 41)
        Me.CheckBoxX2.Name = "CheckBoxX2"
        Me.CheckBoxX2.Size = New System.Drawing.Size(129, 15)
        Me.CheckBoxX2.TabIndex = 20
        Me.CheckBoxX2.Text = "Hide edit save prompt"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.HighFont)
        Me.GroupPanel2.Controls.Add(Me.Label5)
        Me.GroupPanel2.Controls.Add(Me.NormalFont)
        Me.GroupPanel2.Controls.Add(Me.Label6)
        Me.GroupPanel2.Controls.Add(Me.LowFont)
        Me.GroupPanel2.Controls.Add(Me.NormalColorBox)
        Me.GroupPanel2.Controls.Add(Me.LowColorBox)
        Me.GroupPanel2.Controls.Add(Me.HighColorBox)
        Me.GroupPanel2.Controls.Add(Me.Label7)
        Me.GroupPanel2.Location = New System.Drawing.Point(158, 4)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(248, 114)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.GroupPanel2.TabIndex = 19
        Me.GroupPanel2.Text = "Priority Colors:"
        '
        'HighFont
        '
        Me.HighFont.AutoSize = True
        Me.HighFont.BackColor = System.Drawing.Color.Transparent
        Me.HighFont.Location = New System.Drawing.Point(208, 59)
        Me.HighFont.Name = "HighFont"
        Me.HighFont.Size = New System.Drawing.Size(28, 13)
        Me.HighFont.TabIndex = 16
        Me.HighFont.TabStop = True
        Me.HighFont.Text = "Font"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 15)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Low"
        '
        'NormalFont
        '
        Me.NormalFont.AutoSize = True
        Me.NormalFont.BackColor = System.Drawing.Color.Transparent
        Me.NormalFont.Location = New System.Drawing.Point(208, 28)
        Me.NormalFont.Name = "NormalFont"
        Me.NormalFont.Size = New System.Drawing.Size(28, 13)
        Me.NormalFont.TabIndex = 15
        Me.NormalFont.TabStop = True
        Me.NormalFont.Text = "Font"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(1, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 15)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Normal"
        '
        'LowFont
        '
        Me.LowFont.AutoSize = True
        Me.LowFont.BackColor = System.Drawing.Color.Transparent
        Me.LowFont.Location = New System.Drawing.Point(208, 0)
        Me.LowFont.Name = "LowFont"
        Me.LowFont.Size = New System.Drawing.Size(28, 13)
        Me.LowFont.TabIndex = 14
        Me.LowFont.TabStop = True
        Me.LowFont.Text = "Font"
        '
        'NormalColorBox
        '
        Me.NormalColorBox.ColorType = mkc_ColorCombobox.mkc_ColorCombobox.ColorEnum.KnownColor
        Me.NormalColorBox.FocusStyle = mkc_ColorCombobox.mkc_ColorCombobox.FocusStyleEnum.IDE
        Me.NormalColorBox.Location = New System.Drawing.Point(52, 28)
        Me.NormalColorBox.Name = "NormalColorBox"
        Me.NormalColorBox.SelectedColor = System.Drawing.Color.Empty
        Me.NormalColorBox.Size = New System.Drawing.Size(150, 22)
        Me.NormalColorBox.TabIndex = 11
        '
        'LowColorBox
        '
        Me.LowColorBox.ColorType = mkc_ColorCombobox.mkc_ColorCombobox.ColorEnum.KnownColor
        Me.LowColorBox.FocusStyle = mkc_ColorCombobox.mkc_ColorCombobox.FocusStyleEnum.IDE
        Me.LowColorBox.Location = New System.Drawing.Point(52, 0)
        Me.LowColorBox.Name = "LowColorBox"
        Me.LowColorBox.SelectedColor = System.Drawing.Color.Empty
        Me.LowColorBox.Size = New System.Drawing.Size(150, 22)
        Me.LowColorBox.TabIndex = 8
        '
        'HighColorBox
        '
        Me.HighColorBox.ColorType = mkc_ColorCombobox.mkc_ColorCombobox.ColorEnum.KnownColor
        Me.HighColorBox.FocusStyle = mkc_ColorCombobox.mkc_ColorCombobox.FocusStyleEnum.IDE
        Me.HighColorBox.Location = New System.Drawing.Point(52, 59)
        Me.HighColorBox.Name = "HighColorBox"
        Me.HighColorBox.SelectedColor = System.Drawing.Color.Empty
        Me.HighColorBox.Size = New System.Drawing.Size(150, 24)
        Me.HighColorBox.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 59)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(25, 15)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "High"
        '
        'CheckBox3
        '
        Me.CheckBox3.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox3.Location = New System.Drawing.Point(12, 20)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(115, 15)
        Me.CheckBox3.TabIndex = 18
        Me.CheckBox3.Text = "Hide delete prompt"
        '
        'TabItem3
        '
        Me.TabItem3.AttachedControl = Me.TabControlPanel3
        Me.TabItem3.Name = "TabItem3"
        Me.TabItem3.Text = "Tasks"
        '
        'Options
        '
        Me.AcceptButton = Me.ok
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.CancelButton = Me.cancel
        Me.ClientSize = New System.Drawing.Size(410, 238)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ok)
        Me.Controls.Add(Me.cancel)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Options"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SeaCow Options"
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabControlPanel1.ResumeLayout(False)
        Me.TabControlPanel1.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.TabControlPanel2.ResumeLayout(False)
        Me.TabControlPanel2.PerformLayout()
        Me.TabControlPanel3.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cd As System.Windows.Forms.ColorDialog
    Friend WithEvents cancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ok As DevComponents.DotNetBar.ButtonX
    Friend WithEvents fd As System.Windows.Forms.FontDialog
    Friend WithEvents TabControl1 As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem1 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel3 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem3 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem2 As DevComponents.DotNetBar.TabItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents SaveProfileButton As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents UserpassBox As System.Windows.Forms.TextBox
    Friend WithEvents UsernameBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents FontLink As System.Windows.Forms.LinkLabel
    Friend WithEvents CheckBox2 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents CheckBox1 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents HighFont As System.Windows.Forms.LinkLabel
    Friend WithEvents Label5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents NormalFont As System.Windows.Forms.LinkLabel
    Friend WithEvents Label6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LowFont As System.Windows.Forms.LinkLabel
    Friend WithEvents NormalColorBox As mkc_ColorCombobox.mkc_ColorCombobox
    Friend WithEvents LowColorBox As mkc_ColorCombobox.mkc_ColorCombobox
    Friend WithEvents HighColorBox As mkc_ColorCombobox.mkc_ColorCombobox
    Friend WithEvents Label7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents CheckBox3 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents CheckBoxX1 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents CheckBoxX2 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents CheckBoxX4 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents CheckBoxX3 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents CheckBoxX5 As DevComponents.DotNetBar.Controls.CheckBoxX
    Private WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ReminderMinutesSlider As DevComponents.DotNetBar.Controls.Slider
End Class
