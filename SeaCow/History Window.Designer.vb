<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class History_Window
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
        Me.Close_Button = New DevComponents.DotNetBar.ButtonX()
        Me.Undo_Button = New DevComponents.DotNetBar.ButtonX()
        Me.Redo_Button = New DevComponents.DotNetBar.ButtonX()
        Me.HistoryBox = New DevComponents.DotNetBar.Controls.ListViewEx()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'Close_Button
        '
        Me.Close_Button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Close_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Close_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close_Button.Location = New System.Drawing.Point(168, 211)
        Me.Close_Button.Name = "Close_Button"
        Me.Close_Button.Size = New System.Drawing.Size(75, 23)
        Me.Close_Button.TabIndex = 1
        Me.Close_Button.Text = "&Close"
        '
        'Undo_Button
        '
        Me.Undo_Button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Undo_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Undo_Button.Enabled = False
        Me.Undo_Button.Location = New System.Drawing.Point(13, 211)
        Me.Undo_Button.Name = "Undo_Button"
        Me.Undo_Button.Size = New System.Drawing.Size(75, 23)
        Me.Undo_Button.TabIndex = 2
        Me.Undo_Button.Text = "Undo"
        '
        'Redo_Button
        '
        Me.Redo_Button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Redo_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Redo_Button.Enabled = False
        Me.Redo_Button.Location = New System.Drawing.Point(94, 211)
        Me.Redo_Button.Name = "Redo_Button"
        Me.Redo_Button.Size = New System.Drawing.Size(68, 23)
        Me.Redo_Button.TabIndex = 3
        Me.Redo_Button.Text = "&Redo"
        '
        'HistoryBox
        '
        Me.HistoryBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.HistoryBox.Border.Class = "ListViewBorder"
        Me.HistoryBox.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.HistoryBox.FullRowSelect = True
        Me.HistoryBox.Location = New System.Drawing.Point(0, 0)
        Me.HistoryBox.MultiSelect = False
        Me.HistoryBox.Name = "HistoryBox"
        Me.HistoryBox.Size = New System.Drawing.Size(255, 192)
        Me.HistoryBox.TabIndex = 4
        Me.HistoryBox.UseCompatibleStateImageBehavior = False
        Me.HistoryBox.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Time"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Action"
        Me.ColumnHeader2.Width = 167
        '
        'History_Window
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.CancelButton = Me.Close_Button
        Me.ClientSize = New System.Drawing.Size(255, 246)
        Me.Controls.Add(Me.HistoryBox)
        Me.Controls.Add(Me.Redo_Button)
        Me.Controls.Add(Me.Undo_Button)
        Me.Controls.Add(Me.Close_Button)
        Me.DoubleBuffered = True
        Me.Name = "History_Window"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "History"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Close_Button As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Undo_Button As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Redo_Button As DevComponents.DotNetBar.ButtonX
    Friend WithEvents HistoryBox As DevComponents.DotNetBar.Controls.ListViewEx
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
End Class
