Public Class HtmlRender

    Private _blogSets As BlogSettings
    Private _blogSome As BlogSomething
    Private _variables As Hashtable
    Private _temparse As Templarse

    Public Sub New(ByVal bset As BlogSettings)
        Me.New(bset, New BlogSomething)
    End Sub

    Public Sub New(ByVal bset As BlogSettings, ByVal bsom As BlogSomething)
        Me._blogSets = bset
        Me._blogSome = bsom
        Me._variables = New Hashtable
        Dim mt As DateTime = New DateTime(Me._blogSome.Modified)
        Dim ct As DateTime = New DateTime(Me._blogSome.Created)

        For Each k As String In bset.GetVariableNames
            Me._variables(k) = bset.GetVariable(k)
        Next

        Me._variables("blog_title") = bset.Title
        Me._variables("post_title") = bsom.Title

        If bsom.Entry.Length > 0 Then
            Me._variables("post_content") = "<p>" + bsom.Entry.Replace(vbCrLf, "</p><p>") + "</p>"
        End If

        Me._variables("post_created") = Lz(ct.Month.ToString) + "/" + Lz(ct.Day.ToString) + _
                                        "/" + Lz(ct.Year.ToString) + " @ " + Lz(ct.Hour.ToString) + _
                                        ":" + Lz(ct.Minute.ToString)
        Me._variables("post_updated") = Lz(mt.Month.ToString) + "/" + Lz(mt.Day.ToString) + _
                                        "/" + Lz(mt.Year.ToString) + " @ " + Lz(mt.Hour.ToString) + _
                                        ":" + Lz(mt.Minute.ToString)


    End Sub

    Public Sub AddVariable(ByVal name As String, ByVal value As String)
        If name.Length = 0 Or value.Length = 0 Then Exit Sub
        Me._variables(name) = value
    End Sub

    Public Sub RemoveVariable(ByVal name As String)
        If name.Length = 0 Then Exit Sub
        If Not Me._variables.ContainsKey(name) Then Exit Sub
        Me._variables.Remove(name)
    End Sub

    Public Function Render() As String
        _temparse = New Templarse(Me._blogSets.Template, Me._variables)
        Return Me._temparse.ExecuteTemplate()
    End Function

    Private Function Lz(ByVal n As String) As String
        Dim i As Integer = Integer.Parse(n)
        If i < 10 Then n = "0" + n
        Return n
    End Function

End Class
