<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBlogWizard
    Inherits System.Windows.Forms.Form

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
        Me.btnSaved = New System.Windows.Forms.Button
        Me.btnStore = New System.Windows.Forms.Button
        Me.btnCreate = New System.Windows.Forms.Button
        Me.txtSaved = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtStore = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtTitle = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.fldrDialogBox = New System.Windows.Forms.FolderBrowserDialog
        Me.dlgSaveBlog = New System.Windows.Forms.SaveFileDialog
        Me.SuspendLayout()
        '
        'btnSaved
        '
        Me.btnSaved.Location = New System.Drawing.Point(248, 160)
        Me.btnSaved.Name = "btnSaved"
        Me.btnSaved.Size = New System.Drawing.Size(32, 20)
        Me.btnSaved.TabIndex = 12
        Me.btnSaved.Text = "..."
        Me.btnSaved.UseVisualStyleBackColor = True
        '
        'btnStore
        '
        Me.btnStore.Location = New System.Drawing.Point(248, 111)
        Me.btnStore.Name = "btnStore"
        Me.btnStore.Size = New System.Drawing.Size(32, 20)
        Me.btnStore.TabIndex = 10
        Me.btnStore.Text = "..."
        Me.btnStore.UseVisualStyleBackColor = True
        '
        'btnCreate
        '
        Me.btnCreate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreate.Location = New System.Drawing.Point(12, 193)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(268, 27)
        Me.btnCreate.TabIndex = 13
        Me.btnCreate.Text = "CREATE"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'txtSaved
        '
        Me.txtSaved.Location = New System.Drawing.Point(12, 160)
        Me.txtSaved.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.txtSaved.Name = "txtSaved"
        Me.txtSaved.Size = New System.Drawing.Size(230, 20)
        Me.txtSaved.TabIndex = 16
        Me.txtSaved.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 141)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(156, 16)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Blog Saved Location:"
        '
        'txtStore
        '
        Me.txtStore.Location = New System.Drawing.Point(12, 111)
        Me.txtStore.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.txtStore.Name = "txtStore"
        Me.txtStore.Size = New System.Drawing.Size(230, 20)
        Me.txtStore.TabIndex = 14
        Me.txtStore.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(148, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Blog Store Location:"
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(12, 62)
        Me.txtTitle.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(268, 20)
        Me.txtTitle.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 16)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "New Blog Title:"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 10)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3, 0, 3, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(268, 23)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "CREATE NEW BLOG"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dlgSaveBlog
        '
        Me.dlgSaveBlog.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|(*.*)"
        '
        'frmBlogWizard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 231)
        Me.Controls.Add(Me.btnSaved)
        Me.Controls.Add(Me.btnStore)
        Me.Controls.Add(Me.btnCreate)
        Me.Controls.Add(Me.txtSaved)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtStore)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(300, 265)
        Me.MinimumSize = New System.Drawing.Size(300, 265)
        Me.Name = "frmBlogWizard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create New Blog"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSaved As System.Windows.Forms.Button
    Friend WithEvents btnStore As System.Windows.Forms.Button
    Friend WithEvents btnCreate As System.Windows.Forms.Button
    Friend WithEvents txtSaved As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtStore As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fldrDialogBox As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents dlgSaveBlog As System.Windows.Forms.SaveFileDialog
End Class
