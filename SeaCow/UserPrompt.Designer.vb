<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserPrompt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserPrompt))
        Me.Label1 = New DevComponents.DotNetBar.LabelX()
        Me.Label2 = New DevComponents.DotNetBar.LabelX()
        Me.Label3 = New DevComponents.DotNetBar.LabelX()
        Me.Button1 = New DevComponents.DotNetBar.ButtonX()
        Me.Button2 = New DevComponents.DotNetBar.ButtonX()
        Me.UserNameBox = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.UserPassBox = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(218, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Please enter your user name and password."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Username:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Password:"
        '
        'Button1
        '
        Me.Button1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button1.Location = New System.Drawing.Point(97, 103)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "&Login"
        '
        'Button2
        '
        Me.Button2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.Location = New System.Drawing.Point(178, 103)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "&Quit"
        '
        'UserNameBox
        '
        '
        '
        '
        Me.UserNameBox.Border.Class = "TextBoxBorder"
        Me.UserNameBox.Location = New System.Drawing.Point(74, 40)
        Me.UserNameBox.Name = "UserNameBox"
        Me.UserNameBox.Size = New System.Drawing.Size(179, 20)
        Me.UserNameBox.TabIndex = 7
        Me.UserNameBox.WatermarkText = "ex. John"
        '
        'UserPassBox
        '
        '
        '
        '
        Me.UserPassBox.Border.Class = "TextBoxBorder"
        Me.UserPassBox.Location = New System.Drawing.Point(74, 71)
        Me.UserPassBox.Name = "UserPassBox"
        Me.UserPassBox.Size = New System.Drawing.Size(179, 20)
        Me.UserPassBox.TabIndex = 8
        Me.UserPassBox.UseSystemPasswordChar = True
        '
        'UserPrompt
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.CancelButton = Me.Button2
        Me.ClientSize = New System.Drawing.Size(265, 138)
        Me.Controls.Add(Me.UserPassBox)
        Me.Controls.Add(Me.UserNameBox)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "UserPrompt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SeaCow Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Label2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Label3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Button1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Button2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents UserNameBox As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents UserPassBox As DevComponents.DotNetBar.Controls.TextBoxX
End Class
