Imports System
Imports System.IO
Imports System.Text
Imports System.Xml

Public Class BlogPost
    Protected _title As String = ""
    Protected _entry As String = ""
    Protected _created As Long = 0
    Protected _modified As Long = 0
    Protected _filename As String = ""

    Public Property Title() As String
        Get
            Return Me._title
        End Get
        Set(ByVal value As String)
            Me._modified = Date.Now.Ticks
            Me._title = value
        End Set
    End Property

    Public Property Entry() As String
        Get
            Return Me._entry
        End Get
        Set(ByVal value As String)
            Me._modified = Date.Now.Ticks
            Me._entry = value
        End Set
    End Property

    Public Property Filename() As String
        Get
            Return Me._filename
        End Get
        Set(ByVal value As String)
            Me._filename = value
        End Set
    End Property

    Public ReadOnly Property Basename() As String
        Get
            Dim temp() As String = Me._filename.Split("\")
            Return temp(temp.Length - 1)
        End Get
    End Property

    Public Property Created() As Long
        Get
            Return Me._created
        End Get
        Set(ByVal value As Long)
            Me._created = value
        End Set
    End Property

    Public Property Modified() As Long
        Get
            Return Me._modified
        End Get
        Set(ByVal value As Long)
            Me._modified = value
        End Set
    End Property

    Public Sub New()
        Me.New("", "No Title", Date.Now.Ticks, Date.Now.Ticks)
    End Sub

    Public Sub New(ByVal entry As String)
        Me.New(entry, "No Title", Date.Now.Ticks, Date.Now.Ticks)
    End Sub

    Public Sub New(ByVal entry As String, ByVal title As String)
        Me.New(entry, title, Date.Now.Ticks, Date.Now.Ticks)
    End Sub

    Public Sub New(ByVal entry As String, ByVal title As String, _
                   ByVal c As Long, ByVal m As Long)
        Me._entry = entry
        Me._title = title
        Me._created = c
        Me._modified = m
    End Sub

    Public Sub LoadXml(ByVal filename As String)
        If Not File.Exists(filename) Then
            Throw New Exception("Blog XML file does not exist.")
            Exit Sub
        End If
        Try
            Dim xmldoc As XmlDocument = New XmlDocument
            xmldoc.Load(filename)
            Dim blogNode As XmlNode = xmldoc.SelectSingleNode("/blog")
            Me._entry = Me._XmlDecode(blogNode.Item("entry").InnerText)
            Me._title = Me._XmlDecode(blogNode.Item("title").InnerText)
            Me._created = Long.Parse(blogNode.Item("created").InnerText)
            Me._modified = Long.Parse(blogNode.Item("modified").InnerText)
            Me._filename = filename
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub SaveXml()
        Me.SaveXml(Me._filename)
    End Sub

    Public Sub SaveXml(ByVal filename As String)
        Dim parts() As String = filename.Split("\")
        Dim start As String = parts(0)
        If parts.Length > 2 Then
            For c As Integer = 1 To parts.Length - 2
                start += "\" + parts(c)
                If Not Directory.Exists(start) Then Directory.CreateDirectory(start)
            Next
        End If
        Dim sr As New StreamWriter(filename, False, Encoding.UTF8)
        sr.Write(Me.MakeXml())
        sr.Close()
        sr.Dispose()
    End Sub

    Protected Function MakeXml() As String
        Dim sb As New StringBuilder()
        sb.Append("<?xml version=""1.0"" encoding=""UTF-8""?>").Append(vbCrLf)
        sb.Append("<blog>").Append(vbCrLf)
        sb.Append("<title>").Append(Me._XmlEncode(Me._title)).Append("</title>").Append(vbCrLf)
        sb.Append("<entry>").Append(Me._XmlEncode(Me._entry)).Append("</entry>").Append(vbCrLf)
        sb.Append("<created>").Append(Me._created.ToString).Append("</created>").Append(vbCrLf)
        sb.Append("<modified>").Append(Me._modified.ToString).Append("</modified>").Append(vbCrLf)
        sb.Append("</blog>").Append(vbCrLf)
        Return sb.ToString
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