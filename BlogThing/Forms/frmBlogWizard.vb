Public Class frmBlogWizard

    Private Sub frmBlogWizard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckTextCounter()
    End Sub

    Private Sub btnStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStore.Click
        If Not txtStore.Text = "" Then
            fldrDialogBox.SelectedPath = txtStore.Text
        End If

        If fldrDialogBox.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtStore.Text = fldrDialogBox.SelectedPath
        End If
    End Sub

    Private Sub btnSaved_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaved.Click
        If Not txtSaved.Text = "" Then
            fldrDialogBox.SelectedPath = txtSaved.Text
        End If

        If fldrDialogBox.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtSaved.Text = fldrDialogBox.SelectedPath
        End If
    End Sub

    Private Sub txtTitle_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTitle.TextChanged
        CheckTextCounter()
    End Sub

    Private Sub txtStore_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStore.TextChanged
        CheckTextCounter()
    End Sub

    Private Sub txtSaved_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSaved.TextChanged
        CheckTextCounter()
    End Sub

    Private Sub btnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreate.Click
        Dim bs As BlogSettings = New BlogSettings(txtTitle.Text, txtStore.Text, txtSaved.Text)
        dlgSaveBlog.FileName = bs.MakeFileTitle()
        If dlgSaveBlog.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
        bs.SaveBlog(dlgSaveBlog.FileName)
        GlobalVars.blogfile = dlgSaveBlog.FileName
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub CheckTextCounter()
        Dim textCounter As Integer = 0
        If Not txtTitle.Text = "" Then textCounter += 1 Else textCounter -= 1
        If Not txtStore.Text = "" Then textCounter += 1 Else textCounter -= 1
        If Not txtSaved.Text = "" Then textCounter += 1 Else textCounter -= 1
        If textCounter = 3 Then btnCreate.Enabled = True Else btnCreate.Enabled = False
    End Sub

End Class