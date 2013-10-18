<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim btnVarSelect As System.Windows.Forms.Button
        Me.btnNewBlog = New System.Windows.Forms.Button
        Me.btnLoadBlog = New System.Windows.Forms.Button
        Me.lblBlogTitle = New System.Windows.Forms.Label
        Me.grpManipulateBlog = New System.Windows.Forms.GroupBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.btnGenerateHtml = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnVarRemove = New System.Windows.Forms.Button
        Me.btnVarSave = New System.Windows.Forms.Button
        Me.txtVarVal = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtVarKey = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbVariables = New System.Windows.Forms.ComboBox
        Me.txtBlogDirectory = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtStorePath = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtBlogTitle = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnSaveBlog = New System.Windows.Forms.Button
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.btnClearPost = New System.Windows.Forms.Button
        Me.btnSaveNewPost = New System.Windows.Forms.Button
        Me.btnLoadPost = New System.Windows.Forms.Button
        Me.txtPostContent = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnSavePost = New System.Windows.Forms.Button
        Me.txtPostTitle = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.txtTemplate = New System.Windows.Forms.TextBox
        Me.dlgOpenBlog = New System.Windows.Forms.OpenFileDialog
        Me.dlgOpenPost = New System.Windows.Forms.OpenFileDialog
        btnVarSelect = New System.Windows.Forms.Button
        Me.grpManipulateBlog.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnVarSelect
        '
        btnVarSelect.Location = New System.Drawing.Point(306, 19)
        btnVarSelect.Name = "btnVarSelect"
        btnVarSelect.Size = New System.Drawing.Size(69, 21)
        btnVarSelect.TabIndex = 6
        btnVarSelect.TabStop = False
        btnVarSelect.Text = "Select"
        btnVarSelect.UseVisualStyleBackColor = True
        AddHandler btnVarSelect.Click, AddressOf Me.btnVarSelect_Click
        '
        'btnNewBlog
        '
        Me.btnNewBlog.Location = New System.Drawing.Point(12, 12)
        Me.btnNewBlog.Name = "btnNewBlog"
        Me.btnNewBlog.Size = New System.Drawing.Size(75, 23)
        Me.btnNewBlog.TabIndex = 1
        Me.btnNewBlog.Text = "New"
        Me.btnNewBlog.UseVisualStyleBackColor = True
        '
        'btnLoadBlog
        '
        Me.btnLoadBlog.Location = New System.Drawing.Point(93, 12)
        Me.btnLoadBlog.Name = "btnLoadBlog"
        Me.btnLoadBlog.Size = New System.Drawing.Size(75, 23)
        Me.btnLoadBlog.TabIndex = 2
        Me.btnLoadBlog.Text = "Load"
        Me.btnLoadBlog.UseVisualStyleBackColor = True
        '
        'lblBlogTitle
        '
        Me.lblBlogTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBlogTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlogTitle.Location = New System.Drawing.Point(174, 15)
        Me.lblBlogTitle.Name = "lblBlogTitle"
        Me.lblBlogTitle.Size = New System.Drawing.Size(406, 16)
        Me.lblBlogTitle.TabIndex = 2
        '
        'grpManipulateBlog
        '
        Me.grpManipulateBlog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpManipulateBlog.Controls.Add(Me.TabControl1)
        Me.grpManipulateBlog.Enabled = False
        Me.grpManipulateBlog.Location = New System.Drawing.Point(12, 41)
        Me.grpManipulateBlog.Name = "grpManipulateBlog"
        Me.grpManipulateBlog.Size = New System.Drawing.Size(568, 313)
        Me.grpManipulateBlog.TabIndex = 3
        Me.grpManipulateBlog.TabStop = False
        Me.grpManipulateBlog.Text = "Manipulate your blog"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(6, 19)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(556, 288)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnGenerateHtml)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.txtBlogDirectory)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.txtStorePath)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtBlogTitle)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.btnSaveBlog)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(548, 262)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Blog Settings"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnGenerateHtml
        '
        Me.btnGenerateHtml.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerateHtml.Location = New System.Drawing.Point(392, 35)
        Me.btnGenerateHtml.Name = "btnGenerateHtml"
        Me.btnGenerateHtml.Size = New System.Drawing.Size(150, 23)
        Me.btnGenerateHtml.TabIndex = 7
        Me.btnGenerateHtml.Text = "Generate HTML"
        Me.btnGenerateHtml.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnVarRemove)
        Me.GroupBox1.Controls.Add(btnVarSelect)
        Me.GroupBox1.Controls.Add(Me.btnVarSave)
        Me.GroupBox1.Controls.Add(Me.txtVarVal)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtVarKey)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmbVariables)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 156)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(533, 100)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Template Variables"
        '
        'btnVarRemove
        '
        Me.btnVarRemove.Location = New System.Drawing.Point(381, 19)
        Me.btnVarRemove.Name = "btnVarRemove"
        Me.btnVarRemove.Size = New System.Drawing.Size(69, 21)
        Me.btnVarRemove.TabIndex = 7
        Me.btnVarRemove.TabStop = False
        Me.btnVarRemove.Text = "Remove"
        Me.btnVarRemove.UseVisualStyleBackColor = True
        '
        'btnVarSave
        '
        Me.btnVarSave.Location = New System.Drawing.Point(458, 70)
        Me.btnVarSave.Name = "btnVarSave"
        Me.btnVarSave.Size = New System.Drawing.Size(69, 20)
        Me.btnVarSave.TabIndex = 5
        Me.btnVarSave.TabStop = False
        Me.btnVarSave.Text = "Save"
        Me.btnVarSave.UseVisualStyleBackColor = True
        '
        'txtVarVal
        '
        Me.txtVarVal.Location = New System.Drawing.Point(204, 70)
        Me.txtVarVal.Name = "txtVarVal"
        Me.txtVarVal.Size = New System.Drawing.Size(248, 20)
        Me.txtVarVal.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(204, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Variable Value"
        '
        'txtVarKey
        '
        Me.txtVarKey.Location = New System.Drawing.Point(6, 70)
        Me.txtVarKey.Name = "txtVarKey"
        Me.txtVarKey.Size = New System.Drawing.Size(186, 20)
        Me.txtVarKey.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Variable Key"
        '
        'cmbVariables
        '
        Me.cmbVariables.FormattingEnabled = True
        Me.cmbVariables.Location = New System.Drawing.Point(6, 19)
        Me.cmbVariables.Name = "cmbVariables"
        Me.cmbVariables.Size = New System.Drawing.Size(294, 21)
        Me.cmbVariables.TabIndex = 0
        '
        'txtBlogDirectory
        '
        Me.txtBlogDirectory.Location = New System.Drawing.Point(9, 123)
        Me.txtBlogDirectory.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.txtBlogDirectory.Name = "txtBlogDirectory"
        Me.txtBlogDirectory.Size = New System.Drawing.Size(300, 20)
        Me.txtBlogDirectory.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Blog Directory"
        '
        'txtStorePath
        '
        Me.txtStorePath.Location = New System.Drawing.Point(9, 74)
        Me.txtStorePath.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.txtStorePath.Name = "txtStorePath"
        Me.txtStorePath.Size = New System.Drawing.Size(300, 20)
        Me.txtStorePath.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Store Path"
        '
        'txtBlogTitle
        '
        Me.txtBlogTitle.Location = New System.Drawing.Point(9, 25)
        Me.txtBlogTitle.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.txtBlogTitle.Name = "txtBlogTitle"
        Me.txtBlogTitle.Size = New System.Drawing.Size(300, 20)
        Me.txtBlogTitle.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Blog Title"
        '
        'btnSaveBlog
        '
        Me.btnSaveBlog.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveBlog.Location = New System.Drawing.Point(392, 6)
        Me.btnSaveBlog.Name = "btnSaveBlog"
        Me.btnSaveBlog.Size = New System.Drawing.Size(150, 23)
        Me.btnSaveBlog.TabIndex = 6
        Me.btnSaveBlog.Text = "Save Settings"
        Me.btnSaveBlog.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnClearPost)
        Me.TabPage2.Controls.Add(Me.btnSaveNewPost)
        Me.TabPage2.Controls.Add(Me.btnLoadPost)
        Me.TabPage2.Controls.Add(Me.txtPostContent)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.btnSavePost)
        Me.TabPage2.Controls.Add(Me.txtPostTitle)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(548, 262)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Blog Posts"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnClearPost
        '
        Me.btnClearPost.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearPost.Location = New System.Drawing.Point(310, 35)
        Me.btnClearPost.Name = "btnClearPost"
        Me.btnClearPost.Size = New System.Drawing.Size(113, 23)
        Me.btnClearPost.TabIndex = 15
        Me.btnClearPost.Text = "Clear"
        Me.btnClearPost.UseVisualStyleBackColor = True
        '
        'btnSaveNewPost
        '
        Me.btnSaveNewPost.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveNewPost.Location = New System.Drawing.Point(310, 6)
        Me.btnSaveNewPost.Name = "btnSaveNewPost"
        Me.btnSaveNewPost.Size = New System.Drawing.Size(113, 23)
        Me.btnSaveNewPost.TabIndex = 13
        Me.btnSaveNewPost.Text = "Save New Post"
        Me.btnSaveNewPost.UseVisualStyleBackColor = True
        '
        'btnLoadPost
        '
        Me.btnLoadPost.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLoadPost.Location = New System.Drawing.Point(429, 35)
        Me.btnLoadPost.Name = "btnLoadPost"
        Me.btnLoadPost.Size = New System.Drawing.Size(113, 23)
        Me.btnLoadPost.TabIndex = 16
        Me.btnLoadPost.Text = "Load Post"
        Me.btnLoadPost.UseVisualStyleBackColor = True
        '
        'txtPostContent
        '
        Me.txtPostContent.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPostContent.Location = New System.Drawing.Point(9, 71)
        Me.txtPostContent.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.txtPostContent.MaxLength = 128000
        Me.txtPostContent.Multiline = True
        Me.txtPostContent.Name = "txtPostContent"
        Me.txtPostContent.Size = New System.Drawing.Size(533, 178)
        Me.txtPostContent.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Post Content"
        '
        'btnSavePost
        '
        Me.btnSavePost.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSavePost.Location = New System.Drawing.Point(429, 6)
        Me.btnSavePost.Name = "btnSavePost"
        Me.btnSavePost.Size = New System.Drawing.Size(113, 23)
        Me.btnSavePost.TabIndex = 14
        Me.btnSavePost.Text = "Update Post"
        Me.btnSavePost.UseVisualStyleBackColor = True
        '
        'txtPostTitle
        '
        Me.txtPostTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPostTitle.Location = New System.Drawing.Point(9, 22)
        Me.txtPostTitle.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.txtPostTitle.Name = "txtPostTitle"
        Me.txtPostTitle.Size = New System.Drawing.Size(295, 20)
        Me.txtPostTitle.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 16)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Post Title"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.txtTemplate)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(548, 262)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Edit Template"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'txtTemplate
        '
        Me.txtTemplate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTemplate.Location = New System.Drawing.Point(3, 3)
        Me.txtTemplate.MaxLength = 128000
        Me.txtTemplate.Multiline = True
        Me.txtTemplate.Name = "txtTemplate"
        Me.txtTemplate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTemplate.Size = New System.Drawing.Size(542, 256)
        Me.txtTemplate.TabIndex = 1
        '
        'dlgOpenBlog
        '
        Me.dlgOpenBlog.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*"
        '
        'dlgOpenPost
        '
        Me.dlgOpenPost.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 366)
        Me.Controls.Add(Me.grpManipulateBlog)
        Me.Controls.Add(Me.lblBlogTitle)
        Me.Controls.Add(Me.btnLoadBlog)
        Me.Controls.Add(Me.btnNewBlog)
        Me.MinimumSize = New System.Drawing.Size(600, 400)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BlogThing"
        Me.grpManipulateBlog.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnNewBlog As System.Windows.Forms.Button
    Friend WithEvents btnLoadBlog As System.Windows.Forms.Button
    Friend WithEvents lblBlogTitle As System.Windows.Forms.Label
    Friend WithEvents grpManipulateBlog As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents txtTemplate As System.Windows.Forms.TextBox
    Friend WithEvents txtBlogDirectory As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtStorePath As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBlogTitle As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSaveBlog As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbVariables As System.Windows.Forms.ComboBox
    Friend WithEvents txtVarKey As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtVarVal As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnVarSave As System.Windows.Forms.Button
    Friend WithEvents txtPostContent As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnSavePost As System.Windows.Forms.Button
    Friend WithEvents txtPostTitle As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnLoadPost As System.Windows.Forms.Button
    Friend WithEvents btnClearPost As System.Windows.Forms.Button
    Friend WithEvents btnSaveNewPost As System.Windows.Forms.Button
    Friend WithEvents dlgOpenBlog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnGenerateHtml As System.Windows.Forms.Button
    Friend WithEvents btnVarRemove As System.Windows.Forms.Button
    Friend WithEvents dlgOpenPost As System.Windows.Forms.OpenFileDialog
End Class
