<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Print_Tasks
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Print_Tasks))
        Me.TasksBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SeaCowDatabaseDataSet = New SeaCowDatabaseDataSet1
        Me.SelectAll = New DevComponents.DotNetBar.ButtonX()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SelectNone = New DevComponents.DotNetBar.ButtonX()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ListView1 = New DevComponents.DotNetBar.Controls.ListViewEx()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.setup_button = New DevComponents.DotNetBar.ButtonX()
        Me.close_button = New DevComponents.DotNetBar.ButtonX()
        Me.print_button = New DevComponents.DotNetBar.ButtonX()
        Me.TasksTableAdapter = New SeaCowDatabaseDataSet1TableAdapters.TasksTableAdapter()
        CType(Me.TasksBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeaCowDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TasksBindingSource
        '
        Me.TasksBindingSource.DataMember = "Tasks"
        Me.TasksBindingSource.DataSource = Me.SeaCowDatabaseDataSet
        '
        'SeaCowDatabaseDataSet
        '
        Me.SeaCowDatabaseDataSet.DataSetName = "SeaCowDatabaseDataSet"
        Me.SeaCowDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SelectAll
        '
        Me.SelectAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.SelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SelectAll.Location = New System.Drawing.Point(204, 415)
        Me.SelectAll.Name = "SelectAll"
        Me.SelectAll.Size = New System.Drawing.Size(75, 23)
        Me.SelectAll.TabIndex = 6
        Me.SelectAll.Text = "Select All"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Date"
        Me.ColumnHeader3.Width = 57
        '
        'SelectNone
        '
        Me.SelectNone.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.SelectNone.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SelectNone.Location = New System.Drawing.Point(285, 415)
        Me.SelectNone.Name = "SelectNone"
        Me.SelectNone.Size = New System.Drawing.Size(75, 23)
        Me.SelectNone.TabIndex = 5
        Me.SelectNone.Text = "Select None"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Name"
        Me.ColumnHeader1.Width = 70
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.ListView1.Border.Class = "ListViewBorder"
        Me.ListView1.CheckBoxes = True
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader3, Me.ColumnHeader2})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(3, 3)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(357, 406)
        Me.ListView1.TabIndex = 3
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Time"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(12, 13)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ListView1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.SelectAll)
        Me.SplitContainer1.Panel1.Controls.Add(Me.SelectNone)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ReportViewer1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.setup_button)
        Me.SplitContainer1.Panel2.Controls.Add(Me.close_button)
        Me.SplitContainer1.Panel2.Controls.Add(Me.print_button)
        Me.SplitContainer1.Size = New System.Drawing.Size(935, 445)
        Me.SplitContainer1.SplitterDistance = 363
        Me.SplitContainer1.TabIndex = 8
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.TasksBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "SeaCow.Report_Tasks.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(4, 4)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(560, 405)
        Me.ReportViewer1.TabIndex = 11
        '
        'setup_button
        '
        Me.setup_button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.setup_button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.setup_button.Location = New System.Drawing.Point(408, 415)
        Me.setup_button.Name = "setup_button"
        Me.setup_button.Size = New System.Drawing.Size(75, 23)
        Me.setup_button.TabIndex = 10
        Me.setup_button.Text = "Page &Setup"
        '
        'close_button
        '
        Me.close_button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.close_button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.close_button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.close_button.Location = New System.Drawing.Point(489, 415)
        Me.close_button.Name = "close_button"
        Me.close_button.Size = New System.Drawing.Size(75, 23)
        Me.close_button.TabIndex = 7
        Me.close_button.Text = "&Close"
        '
        'print_button
        '
        Me.print_button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.print_button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.print_button.Location = New System.Drawing.Point(327, 415)
        Me.print_button.Name = "print_button"
        Me.print_button.Size = New System.Drawing.Size(75, 23)
        Me.print_button.TabIndex = 8
        Me.print_button.Text = "&Print"
        '
        'TasksTableAdapter
        '
        Me.TasksTableAdapter.ClearBeforeFill = True
        '
        'frm_Print_Tasks
        '
        Me.AcceptButton = Me.print_button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.CancelButton = Me.close_button
        Me.ClientSize = New System.Drawing.Size(959, 470)
        Me.Controls.Add(Me.SplitContainer1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_Print_Tasks"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Print Tasks"
        CType(Me.TasksBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeaCowDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SelectAll As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents SelectNone As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents setup_button As DevComponents.DotNetBar.ButtonX
    Friend WithEvents close_button As DevComponents.DotNetBar.ButtonX
    Friend WithEvents print_button As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ListView1 As DevComponents.DotNetBar.Controls.ListViewEx
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents TasksBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SeaCowDatabaseDataSet As SeaCowDatabaseDataSet1
    Friend WithEvents TasksTableAdapter As SeaCowDatabaseDataSet1TableAdapters.TasksTableAdapter
End Class
