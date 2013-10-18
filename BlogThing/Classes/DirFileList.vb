Imports System
Imports System.IO

Public Class DirFileList

    Protected Enum DateType As Integer
        CREATED = 1
        WRITTEN = 2
    End Enum

    Protected _start As String = ""

    Public Sub New()
    End Sub

    Public Sub New(ByVal home As String)
        If home.EndsWith("\") Then home.Remove(home.Length - 1, 1)
        Me._start = home
    End Sub

    Public Property Home() As String
        Get
            Return Me._start
        End Get
        Set(ByVal value As String)
            Me._start = value
        End Set
    End Property

    Public Function ListDirs() As String()
        Dim temp_dirs As String() = Directory.GetDirectories(Me._start)
        Dim dirs As String()
        ReDim dirs(temp_dirs.Length - 1)
        For c As Integer = 0 To temp_dirs.Length - 1
            dirs(c) = temp_dirs(c)
        Next
        Return dirs
    End Function

    Public Function ListDirNames() As String()
        Dim temp_dirs As String() = Directory.GetDirectories(Me._start)
        Dim dirs As String()
        ReDim dirs(temp_dirs.Length - 1)
        For c As Integer = 0 To temp_dirs.Length - 1
            Dim temp As String() = temp_dirs(c).Split("\")
            dirs(c) = temp(temp.Count - 1)
        Next
        Return dirs
    End Function

    Public Function ListDirsByCDate() As String()
        Return Me.ListDirsByDate(DateType.CREATED)
    End Function

    Public Function ListDirsByMDate() As String()
        Return Me.ListDirsByDate(DateType.WRITTEN)
    End Function

    Private Function ListDirsByDate(ByVal whichDate As Integer)
        Dim temp_dirs As String() = Me.ListDirs()
        Dim temp_hash As Hashtable = New Hashtable
        For c As Integer = 0 To temp_dirs.Count - 1
            Dim d As String = temp_dirs(c)
            Dim mdate As String = Me.DirByDate(d, whichDate)
            temp_hash(mdate + d) = d
        Next
        If temp_hash.Count <> temp_dirs.Count Then Throw New Exception("Hash count does not equal dir count.")
        Dim keyList As String()
        Dim dirs As String()
        ReDim keyList(temp_hash.Count - 1)
        ReDim dirs(temp_hash.Count - 1)
        temp_hash.Keys.CopyTo(keyList, 0)
        Array.Sort(keyList)
        For c As Integer = 0 To temp_hash.Count - 1
            dirs(c) = temp_hash(keyList(c))
        Next
        temp_hash = Nothing
        Return dirs
    End Function

    Private Function DirByDate(ByVal d As String, ByVal whichDate As Integer)
        Dim temp_date As Date = New Date
        If whichDate = DateType.CREATED Then
            temp_date = Directory.GetCreationTime(d)
        ElseIf whichDate = DateType.WRITTEN Then
            temp_date = Directory.GetLastWriteTime(d)
        End If
        Return temp_date.Ticks.ToString
    End Function

    Public Function ListFiles() As String()
        Return Me.ListFiles("*.*")
    End Function

    Public Function ListFiles(ByVal pattern As String) As String()
        Dim files As String() = Directory.GetFiles(Me._start, pattern)
        Return files
    End Function

    Public Function ListFileNames(ByVal pattern As String) As String()
        Dim temp_files As String() = Directory.GetFiles(Me._start, pattern)
        Dim files As String()
        ReDim files(temp_files.Count - 1)
        For c As Integer = 0 To temp_files.Length - 1
            files(c) = Me.GetName(temp_files(c))
        Next
        Return files
    End Function

    Public Function ListFilesByCDate() As String()
        Return Me.ListFilesByDate(DateType.CREATED)
    End Function

    Public Function ListFilesByMDate() As String()
        Return Me.ListFilesByDate(DateType.WRITTEN)
    End Function

    Private Function ListFilesByDate(ByVal whichDate As Integer) As String()
        Dim temp_files As String() = Directory.GetFiles(Me._start)
        Dim temp_hash As Hashtable = New Hashtable
        For c As Integer = 0 To temp_files.Count - 1
            Dim f As String = temp_files(c)
            Dim mdate As String = Me.FileByDate(f, whichDate)
            temp_hash(mdate + f) = f
        Next
        If temp_hash.Count <> temp_files.Count Then Throw New Exception("Hash count does not equal file count.")
        Dim keyList As String()
        Dim files As String()
        ReDim keyList(temp_hash.Count - 1)
        ReDim files(temp_hash.Count - 1)
        temp_hash.Keys.CopyTo(keyList, 0)
        Array.Sort(keyList)
        For c As Integer = 0 To temp_hash.Count - 1
            files(c) = temp_hash(keyList(c))
        Next
        temp_hash = Nothing
        Return files
    End Function

    Private Function FileByDate(ByVal f As String, ByVal whichDate As Integer) As String
        Dim temp_date As Date = New Date
        If whichDate = DateType.CREATED Then
            temp_date = File.GetCreationTime(f)
        ElseIf whichDate = DateType.WRITTEN Then
            temp_date = File.GetLastWriteTime(f)
        End If
        Return temp_date.Ticks.ToString
    End Function

    Protected Function GetName(ByVal value As String) As String
        Dim temp As String() = value.Split("\")
        Dim retval As String = temp(temp.Count - 1)
        If retval.Length = 0 Then retval = "\"
        Return retval
    End Function

End Class