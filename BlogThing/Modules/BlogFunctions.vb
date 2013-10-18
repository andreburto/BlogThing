Imports System
Imports System.IO
Imports System.Text

Module BlogFunctions

    Sub GenerateHtml(ByVal theblog As String)

        Dim blogset As BlogSettings = New BlogSettings()
        blogset.LoadBlog(theblog)
        Dim dfl As DirFileTree = New DirFileTree(blogset.StoreDir)
        Dim archives As String = BlogArchivesByYear(dfl.GetDirSubdirs(blogset.StoreDir))

        ' Renders posts
        For Each post As DFLNode In dfl.GetAllFiles
            Dim bsom As BlogSomething = New BlogSomething
            bsom.LoadXml(post.Fullname)
            Dim hr As HtmlRender = New HtmlRender(blogset, bsom)
            hr.AddVariable("content", "<% post_content %>")
            hr.AddVariable("title", "<% post_title %>")
            hr.AddVariable("created", "<% post_created %>")
            hr.AddVariable("up", "<a href=""index.html"">Up</a>")
            hr.AddVariable("bread", MakeBreadCrumbs(dfl.Breadcrumbs(post)))
            Dim html As String = hr.Render()
            Dim blogfile As String = post.Fullname.Replace(blogset.StoreDir, blogset.BlogDir).Replace(".xml", ".html")
            EnsureBlogDir(blogfile)
            Dim sr As New StreamWriter(blogfile, False, Encoding.UTF8)
            sr.Write(html)
            sr.Close()
            sr.Dispose()
        Next

        ' Renders directory indeces
        For Each index As DFLNode In dfl.GetAllDirs()
            Dim bsom As BlogSomething = New BlogSomething
            Dim hr As HtmlRender = New HtmlRender(blogset, bsom)
            Dim html As String = ""
            Dim ct As DateTime = New DateTime(Now.Ticks)
            Dim gentime = Lz(ct.Month.ToString) + "/" + Lz(ct.Day.ToString) + _
                          "/" + Lz(ct.Year.ToString) + " @ " + Lz(ct.Hour.ToString) + _
                          ":" + Lz(ct.Minute.ToString)

            hr.AddVariable("title", index.Name)
            hr.AddVariable("created", gentime)
            hr.AddVariable("up", "<a href=""../index.html"">Up</a>")

            If dfl.CountSubdirsInDir(index) > 0 Then
                hr.AddVariable("content", ListSubDirs(dfl.GetDirSubdirs(index.Fullname)))
            Else
                hr.AddVariable("content", ListFiles(dfl.GetDirFilesByCDate(index.Fullname)))
            End If

            html = hr.Render()
            Dim blogfile As String = index.Fullname.Replace(blogset.StoreDir, blogset.BlogDir) + "\index.html"
            Dim sr As New StreamWriter(blogfile, False, Encoding.UTF8)
            sr.Write(html)
            sr.Close()
            sr.Dispose()
        Next

        ' Renders the home page
        Dim homepage As String = blogset.BlogDir + "\index.html"
        Dim bp As BlogSomething = HomeFile(dfl.GetAllFiles)
        Console.WriteLine(bp.Title)
        Dim hphr As HtmlRender = New HtmlRender(blogset, bp)
        hphr.AddVariable("content", "<% post_content %>")
        hphr.AddVariable("title", "<% post_title %>")
        hphr.AddVariable("created", "<% post_created %>")
        hphr.AddVariable("created", "<% post_created %>")
        hphr.AddVariable("archives", archives)
        Dim hphtml = hphr.Render()
        Dim hpsr As New StreamWriter(homepage, False, Encoding.UTF8)
        hpsr.Write(hphtml)
        hpsr.Close()
        hpsr.Dispose()
    End Sub

    Private Function HomeFile(ByVal files As DFLNode()) As BlogSomething
        Dim temp As DFLNode = New DFLNode
        Dim ctime As Long = 0
        For Each f As DFLNode In files
            If f.Created > ctime Then
                temp = f
                ctime = f.Created
            End If
        Next
        Dim retval As BlogSomething = New BlogSomething
        If File.Exists(temp.Fullname) Then retval.LoadXml(temp.Fullname)
        Return retval
    End Function

    Private Function ListFiles(ByVal sf() As DFLNode) As String
        Dim retval As String = "<ul>" + vbCrLf
        Array.Reverse(sf)
        For Each f As DFLNode In sf
            Dim blogp As BlogPost = New BlogPost
            blogp.LoadXml(f.Fullname)
            Dim ct As DateTime = New DateTime(blogp.Created)
            Dim gentime = Lz(ct.Month.ToString) + "/" + Lz(ct.Day.ToString) + _
                          "/" + Lz(ct.Year.ToString) + " @ " + Lz(ct.Hour.ToString) + _
                          ":" + Lz(ct.Minute.ToString)

            retval += "<li><a href=""" + f.Name.Replace(".xml", ".html") + _
                      """>" + blogp.Title + "</a> - <i>" + gentime + _
                      "</i></li>" + vbCrLf
        Next
        Return retval + "</ul>" + vbCrLf
    End Function

    Private Function ListSubDirs(ByVal sd() As DFLNode) As String
        Dim retval As String = "<ul>" + vbCrLf
        Array.Reverse(sd)
        For Each d As DFLNode In sd
            retval += "<li><a href=""" + d.Name + "/index.html"">" + d.Name + _
                      "</a></li>" + vbCrLf
        Next
        Return retval + "</ul>"
    End Function

    Private Function MakeBreadCrumbs(ByVal bc() As DFLNode) As String
        Dim retval As String = ""
        Array.Reverse(bc)
        For c As Integer = 1 To bc.Length - 2
            retval = " / " + MakeCrumb(c, bc(c).Name) + retval
        Next
        Dim h As String = MakeCrumb(bc.Length - 2, "")
        h = h.Replace("""></a>", """>Home</a>")
        h = h.Replace("..//", "../")
        retval = h + retval
        Return retval
    End Function

    Private Function MakeCrumb(ByVal uc As Integer, ByVal name As String) As String
        Dim temp As String = "<a href="""
        For ic As Integer = 1 To uc
            temp += "../"
        Next
        temp += name + "/index.html"">" + name + "</a>"
        Return temp
    End Function

    Private Function EnsureBlogDir(ByVal path As String)
        Dim parts As String() = path.Split("\")
        Dim start As String = parts(0)
        For c As Integer = 1 To parts.Length - 2
            start += "\" + parts(c)
            If Not Directory.Exists(start) Then Directory.CreateDirectory(start)
            If Not Directory.Exists(start) Then Return False
        Next
        Return True
    End Function

    Private Function BlogArchivesByYear(ByVal y As DFLNode()) As String
        Dim retval As String = "<b>ARCHIVES:</B>"
        For Each i As DFLNode In y
            retval += " <a href=""" + i.Name + "/index.html"">" + i.Name + "</a>"
        Next
        Return retval
    End Function

    Private Function Lz(ByVal n As String) As String
        Dim i As Integer = Integer.Parse(n)
        If i < 10 Then n = "0" + n
        Return n
    End Function

End Module