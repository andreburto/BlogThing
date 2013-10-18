Imports System
Imports System.Threading

Public Class Form1

    Private loadVariableData As Boolean = False

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If GlobalVars.blogfile.Length > 0 Then
            SaveBlogSettings()
        End If
    End Sub

#Region " New / Load Blog "
    Private Sub btnNewBlog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewBlog.Click
        Dim newBlog As frmBlogWizard = New frmBlogWizard
        If Not newBlog.ShowDialog = Windows.Forms.DialogResult.OK Then Exit Sub
        GlobalVars.blogset = New BlogSettings
        GlobalVars.blogset.LoadBlog(dlgOpenBlog.FileName)
        GlobalVars.blogfile = dlgOpenBlog.FileName
        UpdateForms()
    End Sub

    Private Sub btnLoadBlog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadBlog.Click
        If Not dlgOpenBlog.ShowDialog = Windows.Forms.DialogResult.OK Then Exit Sub
        ClearForms()
        GlobalVars.blogset = New BlogSettings
        GlobalVars.blogset.LoadBlog(dlgOpenBlog.FileName)
        GlobalVars.blogfile = dlgOpenBlog.FileName
        UpdateForms()
    End Sub

#End Region

#Region " First Tab Events "
    Private Sub btnSaveBlog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveBlog.Click
        SaveBlogSettings()
        UpdateForms()
    End Sub

    Private Sub btnGenerateHtml_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateHtml.Click
        btnGenerateHtml.Enabled = False
        SaveBlogSettings()
        BlogFunctions.GenerateHtml(GlobalVars.blogfile)
        btnGenerateHtml.Enabled = True
    End Sub

    Private Sub btnVarSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SelectVariableFromList()
    End Sub

    Private Sub btnVarRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVarRemove.Click
        Dim name As String = cmbVariables.SelectedValue
        GlobalVars.blogset.RemoveVariable(name)
        LoadVariableList()
    End Sub

    Private Sub btnVarSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVarSave.Click
        If txtVarVal.Text.Length = 0 Or txtVarKey.Text.Length = 0 Then Exit Sub
        GlobalVars.blogset.SetVariable(txtVarKey.Text, txtVarVal.Text)
        txtVarKey.Text = ""
        txtVarVal.Text = ""
        LoadVariableList()
    End Sub
#End Region

#Region " Second Tab Events "
    Private Sub btnSaveNewPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveNewPost.Click
        If txtPostTitle.Text.Length = 0 Or txtPostContent.Text.Length = 0 Then Exit Sub
        GlobalVars.blogsome = New BlogSomething(GlobalVars.blogset.StoreDir, True)
        GlobalVars.blogsome.Title = txtPostTitle.Text
        GlobalVars.blogsome.Entry = txtPostContent.Text
        Dim filename As String = GlobalVars.blogsome.MakeFullPath()
        GlobalVars.blogsome.SaveXml(filename)
    End Sub

    Private Sub btnSavePost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSavePost.Click
        If txtPostTitle.Text.Length = 0 Or txtPostContent.Text.Length = 0 Then Exit Sub
        If GlobalVars.blogsome.Filename.Length = 0 Then Exit Sub
        GlobalVars.blogsome.Title = txtPostTitle.Text
        GlobalVars.blogsome.Entry = txtPostContent.Text
        GlobalVars.blogsome.SaveXml(GlobalVars.blogsome.Filename)
    End Sub

    Private Sub btnClearPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearPost.Click
        txtPostTitle.Text = ""
        txtPostContent.Text = ""
        GlobalVars.blogsome = New BlogSomething
    End Sub

    Private Sub btnLoadPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPost.Click
        dlgOpenPost.InitialDirectory = GlobalVars.blogset.StoreDir
        If Not dlgOpenPost.ShowDialog = Windows.Forms.DialogResult.OK Then Exit Sub
        GlobalVars.blogsome = New BlogSomething
        GlobalVars.blogsome.LoadXml(dlgOpenPost.FileName)
        txtPostTitle.Text = GlobalVars.blogsome.Title
        txtPostContent.Text = GlobalVars.blogsome.Entry
    End Sub
#End Region

#Region " General Subs and Functions "
    Private Sub UpdateForms()
        txtBlogTitle.Text = GlobalVars.blogset.Title
        txtBlogDirectory.Text = GlobalVars.blogset.BlogDir
        txtStorePath.Text = GlobalVars.blogset.StoreDir
        txtTemplate.Text = GlobalVars.blogset.Template
        lblBlogTitle.Text = GlobalVars.blogset.Title.ToUpper
        LoadVariableList()
        grpManipulateBlog.Enabled = True
    End Sub

    Private Sub ClearForms()
        txtBlogTitle.Text = ""
        txtBlogDirectory.Text = ""
        txtStorePath.Text = ""
        txtTemplate.Text = ""
        lblBlogTitle.Text = ""
        txtPostTitle.Text = ""
        txtPostContent.Text = ""
        cmbVariables.DataSource = Nothing
        cmbVariables.Text = ""
    End Sub

    Private Sub LoadVariableList()
        cmbVariables.DataSource = GlobalVars.blogset.GetVariableNames()
        cmbVariables.Refresh()
    End Sub

    Private Sub SelectVariableFromList()
        Dim name As String = cmbVariables.SelectedValue
        Dim value As String = GlobalVars.blogset.GetVariable(name)
        If name.Length = 0 Or value.Length = 0 Then Exit Sub
        txtVarKey.Text = name
        txtVarVal.Text = value
    End Sub

    Private Sub SaveBlogSettings()
        GlobalVars.blogset.Title = txtBlogTitle.Text
        GlobalVars.blogset.BlogDir = txtBlogDirectory.Text
        GlobalVars.blogset.StoreDir = txtStorePath.Text
        GlobalVars.blogset.Template = txtTemplate.Text
        GlobalVars.blogset.SaveBlog(GlobalVars.blogfile)
    End Sub
#End Region

End Class