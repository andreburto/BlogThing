Imports System
Imports System.IO
Imports System.Text
Imports System.Xml

Public Class BlogSettings

    Private _dirStore As String = ""
    Private _dirBlog As String = ""
    Private _title As String = ""
    Private _template As String = ""
    Private _templateVars As Hashtable = New Hashtable
    Protected _acceptable As String = "abcdefghijklmnopqrstuvwxyz1234567890"

    Public Property StoreDir() As String
        Get
            Return Me._dirStore
        End Get
        Set(ByVal value As String)
            Me._dirStore = value
        End Set
    End Property

    Public Property BlogDir() As String
        Get
            Return Me._dirBlog
        End Get
        Set(ByVal value As String)
            Me._dirBlog = value
        End Set
    End Property

    Public Property Title() As String
        Get
            Return Me._title
        End Get
        Set(ByVal value As String)
            Me._title = value
        End Set
    End Property

    Public Property Template() As String
        Get
            Return Me._template
        End Get
        Set(ByVal value As String)
            Me._template = value
        End Set
    End Property

    Public Sub New()
    End Sub

    Public Sub New(ByVal storedir As String, ByVal blogdir As String)
        Me.New("No title", storedir, blogdir)
    End Sub

    Public Sub New(ByVal title As String, ByVal storedir As String, ByVal blogdir As String)
        Me.New(title, storedir, blogdir, "")
    End Sub

    Public Sub New(ByVal title As String, ByVal storedir As String, ByVal blogdir As String, ByVal template As String)
        Me._title = title
        Me._dirStore = storedir
        Me._dirBlog = blogdir
        Me._template = template
    End Sub

    Public Sub LoadBlog(ByVal filename As String)
        If Not File.Exists(filename) Then
            Throw New Exception("Blog XML file does not exist.")
            Exit Sub
        End If
        Try
            Dim xmldoc As XmlDocument = New XmlDocument
            xmldoc.Load(filename)
            Dim blogNode As XmlNode = xmldoc.SelectSingleNode("/blog")
            Me._title = Me._XmlDecode(blogNode.Item("title").InnerText)
            Me._dirBlog = Me._XmlDecode(blogNode.Item("blogdir").InnerText)
            Me._dirStore = Me._XmlDecode(blogNode.Item("store").InnerText)

            If xmldoc.SelectNodes("/blog/template").Count > 0 Then
                Me._template = Me._XmlDecode(blogNode.Item("template").InnerText)
            End If

            If xmldoc.SelectNodes("/blog/variables/variable").Count > 0 Then
                Me._templateVars.Clear()
                For Each v As XmlNode In xmldoc.SelectNodes("/blog/variables/variable")
                    Dim name As String = Me._XmlDecode(v.Item("name").InnerText)
                    Dim value As String = Me._XmlDecode(v.Item("value").InnerText)
                    Me._templateVars(name) = value
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub SaveBlog()
        Me.SaveBlog(Me.MakeFileTitle(Me._title))
    End Sub

    Public Sub SaveBlog(ByVal file As String)
        Dim filename As String = file
        Dim sr As New StreamWriter(filename, False, Encoding.UTF8)
        sr.Write(Me.MakeXml())
        sr.Close()
        sr.Dispose()
    End Sub

    Protected Function MakeXml() As String
        Dim sb As New StringBuilder()
        sb.Append("<?xml version=""1.0"" encoding=""UTF-8""?>").Append(vbCrLf)
        sb.Append("<blog>").Append(vbCrLf)
        sb.Append("  <title>").Append(Me._XmlEncode(Me._title)).Append("</title>").Append(vbCrLf)
        sb.Append("  <blogdir>").Append(Me._XmlEncode(Me._dirBlog)).Append("</blogdir>").Append(vbCrLf)
        sb.Append("  <store>").Append(Me._XmlEncode(Me._dirStore)).Append("</store>").Append(vbCrLf)

        If Me._template.Length > 0 Then
            sb.Append("  <template>").Append(Me._XmlEncode(Me._template)).Append("</template>").Append(vbCrLf)
        End If

        If Me._templateVars.Keys.Count > 0 Then
            sb.Append("  <variables>").Append(vbCrLf)
            For Each k As String In Me._templateVars.Keys
                sb.Append("    <variable>").Append(vbCrLf)
                sb.Append("      <name>").Append(Me._XmlEncode(k)).Append("</name>").Append(vbCrLf)
                sb.Append("      <value>").Append(Me._XmlEncode(Me._templateVars(k))).Append("</value>").Append(vbCrLf)
                sb.Append("    </variable>").Append(vbCrLf)
            Next
            sb.Append("  </variables>").Append(vbCrLf)
        End If

        sb.Append("</blog>").Append(vbCrLf)
        Return sb.ToString
    End Function

    Public Function GetVariable(ByVal name As String) As String
        If Not Me._templateVars.Contains(name) Then Return ""
        Return Me._templateVars(name).ToString
    End Function

    Public Function GetVariableNames() As String()
        Dim vars() As String = {}
        If Me._templateVars.Keys.Count = 0 Then Return vars
        ReDim vars(Me._templateVars.Keys.Count - 1)
        Dim count As Integer = 0
        For Each k As String In Me._templateVars.Keys
            vars(count) = k
            count += 1
        Next
        Return vars
    End Function

    Public Sub SetVariable(ByVal name As String, ByVal value As String)
        If name.Length = 0 Or value.Length = 0 Then Exit Sub
        Me._templateVars(name) = value
    End Sub

    Public Sub RemoveVariable(ByVal name As String)
        If name.Length = 0 Then Exit Sub
        If Not Me._templateVars.Contains(name) Then Exit Sub
        Me._templateVars.Remove(name)
    End Sub

    Public Function MakeFileTitle() As String
        Return Me.MakeFileTitle(Me._title)
    End Function

    Public Function MakeFileTitle(ByVal title As String) As String
        Dim retval As String = ""
        For c As Integer = 0 To title.Length - 1
            Dim temp As String = title.ToLower.Substring(c, 1)
            If Me._acceptable.Contains(temp) Then retval += temp
        Next
        Return retval + ".xml"
    End Function

    Protected Function _XmlEncode(ByVal text As String) As String
        text = text.Replace("&", "&amp;")
        text = text.Replace("<", "&lt;")
        text = text.Replace(">", "&gt;")
        text = text.Replace("'", "&apos;")
        text = text.Replace("""", "&quot;")
        Return text
    End Function

    Protected Function _XmlDecode(ByVal text As String) As String
        text = text.Replace("&lt;", "<")
        text = text.Replace("&gt;", ">")
        text = text.Replace("&apos;", "'")
        text = text.Replace("&quot;", """")
        text = text.Replace("&amp;", "&")
        Return text
    End Function
End Class