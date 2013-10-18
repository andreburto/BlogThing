Imports System
Imports System.IO
Imports System.Text
Imports System.Xml

Public Class BlogSomething
    Inherits BlogPost

    Protected _baseDir As String = ""
    Protected _fileTitle As String = ""
    Protected _acceptable As String = "abcdefghijklmnopqrstuvwxyz1234567890"
    Protected _writeOver As Boolean = False

    Public Property FileTitle() As String
        Get
            Return Me._fileTitle
        End Get
        Set(ByVal value As String)
            Me._fileTitle = Me.MakeFileTitle(value)
        End Set
    End Property

    Public Property WriteOver() As Boolean
        Get
            Return Me._writeOver
        End Get
        Set(ByVal value As Boolean)
            Me._writeOver = value
        End Set
    End Property

    Public Property StartDir() As String
        Get
            Return Me._baseDir
        End Get
        Set(ByVal start As String)
            If start.EndsWith("\") Then start.Substring(0, start.Length - 1)
            Me._baseDir = start
        End Set
    End Property

    Public Sub New()
    End Sub

    Public Sub New(ByVal start As String)
        Me.New(start, True)
    End Sub

    Public Sub New(ByVal start As String, ByVal wo As String)
        If start.EndsWith("\") Then start.Substring(0, start.Length - 1)
        Me._baseDir = start
        Me._writeOver = wo
    End Sub

    Public Function MakeFullPath() As String
        If Me._title.Length = 0 Then
            Throw New Exception("No title text.")
            Return ""
        End If
        Dim bdate As DateTime = New DateTime(Me._created)
        Dim retval As String = Me._baseDir
        If Not Directory.Exists(retval) Then Return ""
        retval += "\" + bdate.Year.ToString
        If Not Directory.Exists(retval) Then Directory.CreateDirectory(retval)
        Dim mnth As String = bdate.Month.ToString
        If mnth.Length = 1 Then mnth = "0" + mnth
        retval += "\" + mnth
        If Not Directory.Exists(retval) Then Directory.CreateDirectory(retval)
        Dim day As String = bdate.Day.ToString
        If day.Length = 1 Then day = "0" + day
        retval += "\" + day
        If Not Directory.Exists(retval) Then Directory.CreateDirectory(retval)
        Dim temp As String = retval + "\" + Me.MakeFileTitle(Me._title)
        If Me._writeOver = False Then
            Dim count As Integer = 2
            While File.Exists(temp)
                temp = retval + "\" + Me.MakeFileTitle(Me._title + count.ToString)
                count += 1
            End While
        End If
        Return temp
    End Function

    Public Function MakeFileTitle(ByVal title As String)
        Dim retval As String = ""
        For c As Integer = 0 To title.Length - 1
            Dim temp As String = title.ToLower.Substring(c, 1)
            If Me._acceptable.Contains(temp) Then retval += temp
        Next
        Return retval + ".xml"
    End Function
End Class