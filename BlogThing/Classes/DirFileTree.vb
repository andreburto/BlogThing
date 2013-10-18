Imports System
Imports System.Collections
Imports System.IO

Public Class DirFileTree
    Inherits DirFileList

    Protected Enum ObjType As Integer
        FILE = 1
        DIR = 2
        BOTH = 3
    End Enum

    Private dflTable As Collection = New Collection
    Private objCounter As Long = 0
    Public Const ROOT As Integer = 0

    Public Sub New()
    End Sub

    Public Sub New(ByVal start As String)
        Me._start = start
        Me.BuildTable()
    End Sub

#Region " Initialize Table "
    Public Sub BuildTable()
        If Not Directory.Exists(Me._start) Then
            Throw New Exception("Directory does not exist.")
            Exit Sub
        End If

        Me.dflTable.Clear()
        Me.objCounter = 0
        Me.LoadLevel()
    End Sub

    Private Sub LoadLevel()
        Me.dflTable.Add(New DFLNode(Me.objCounter, Me._start, -1, ObjType.DIR))
        LoadLevel(Me._start, ROOT)
    End Sub

    Private Sub LoadLevel(ByVal d As String, ByVal parent As Integer)
        Dim temp_dfl As DirFileList = New DirFileList(d)

        For Each f As String In temp_dfl.ListFiles
            Me.objCounter += 1
            Me.dflTable.Add(New DFLNode(Me.objCounter, f, parent, ObjType.FILE))
        Next

        For Each ld As String In temp_dfl.ListDirs
            Me.objCounter += 1
            Me.dflTable.Add(New DFLNode(Me.objCounter, ld, parent, ObjType.DIR))
            LoadLevel(ld, Me.objCounter)
        Next
        temp_dfl = Nothing
    End Sub
#End Region

#Region " Find Items from the table "
    Public Function FindItem(ByVal id As Long) As DFLNode
        For Each i As DFLNode In dflTable
            If i.Id = id Then
                Return i
            End If
        Next
        Return New DFLNode
    End Function

    Public Function FindItem(ByVal path As String) As DFLNode
        For Each i As DFLNode In dflTable
            If i.Fullname Is path Then
                Return i
            End If
        Next
        Return New DFLNode
    End Function

    Public Function FindParent(ByVal id As Long) As DFLNode
        For Each i As DFLNode In dflTable
            If i.Id = id Then
                Return Me.FindItem(i.Parent)
            End If
        Next
        Return New DFLNode
    End Function

    Public Function FindParent(ByVal path As String) As DFLNode
        For Each i As DFLNode In dflTable
            If i.Fullname Is path Then
                Return Me.FindItem(i.Parent)
            End If
        Next
        Return New DFLNode
    End Function
#End Region

#Region " Get Items sorted by dates "
    Public Function GetDirFilesByCDate(ByVal path As String) As DFLNode()
        Return Me.GetObjectsByDate(path, ObjType.FILE, DateType.CREATED)
    End Function

    Public Function GetDirFilesByMDate(ByVal path As String) As DFLNode()
        Return Me.GetObjectsByDate(path, ObjType.FILE, DateType.WRITTEN)
    End Function

    Public Function GetDirSubdirsByCDate(ByVal path As String) As DFLNode()
        Return Me.GetObjectsByDate(path, ObjType.DIR, DateType.WRITTEN)
    End Function

    Public Function GetDirSubdirsByMDate(ByVal path As String) As DFLNode()
        Return Me.GetObjectsByDate(path, ObjType.DIR, DateType.WRITTEN)
    End Function

    Protected Function GetObjectsByDate(ByVal path As String, ByVal obj As Integer, ByVal type As Integer) As DFLNode()
        Dim temp As DFLNode() = {New DFLNode}

        If obj = ObjType.DIR Then
            temp = Me.GetDirSubdirs(path)
        ElseIf obj = ObjType.FILE Then
            temp = Me.GetDirFiles(path)
        ElseIf obj = ObjType.BOTH Then
            temp = Me.GetDirContents(path)
        End If

        Dim temp_hash As Hashtable = New Hashtable
        For Each f As DFLNode In temp
            If type = DateType.CREATED Then
                temp_hash(f.Created.ToString + f.Name) = f
            ElseIf type = DateType.WRITTEN Then
                temp_hash(f.Modified.ToString + f.Name) = f
            End If
        Next
        Dim keyList As String()
        Dim files As DFLNode()
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
#End Region

#Region " Get the contents of directories "
    Public Function GetAllFiles() As DFLNode()
        Dim array_size As Integer = Me.CountAllFiles()
        Dim files(array_size - 1) As DFLNode
        Dim count As Integer = 0
        For Each f As DFLNode In dflTable
            If f.Type = ObjType.FILE Then
                files(count) = f
                count += 1
            End If
        Next
        Return files
    End Function

    Public Function GetAllDirs() As DFLNode()
        Dim array_size As Integer = Me.CountAllDirs()
        Dim ds(array_size) As DFLNode
        Dim count As Integer = 0
        For Each d As DFLNode In dflTable
            If d.Type = ObjType.DIR Then
                ds(count) = d
                count += 1
            End If
        Next
        Return ds
    End Function

    Public Function GetDirFiles(ByVal path As String) As DFLNode()
        Dim temp As DFLNode() = Me.GetDirContents(path)
        Dim count As Integer = 0
        Dim retval(Me.CountFilesInDir(Me.FindItem(path)) - 1) As DFLNode
        For Each dfl As DFLNode In temp
            If dfl.Type = ObjType.FILE Then
                retval(count) = dfl
                count += 1
            End If
        Next
        Return retval
    End Function

    Public Function GetDirSubdirs(ByVal path As String) As DFLNode()
        Dim temp As DFLNode() = Me.GetDirContents(path)
        Dim count As Integer = 0
        Dim retval(Me.CountSubdirsInDir(Me.FindItem(path)) - 1) As DFLNode
        For Each dfl As DFLNode In temp
            If dfl.Type = ObjType.DIR Then
                retval(count) = dfl
                count += 1
            End If
        Next
        Return retval
    End Function

    Public Function GetDirContents(ByVal path As String) As DFLNode()
        Dim retval As DFLNode()
        Dim temp As Collection = New Collection
        Dim dir As DFLNode = Me.FindItem(path)
        For Each dfl As DFLNode In dflTable
            If dir.Id = dfl.Parent Then
                temp.Add(dfl)
            End If
        Next
        ReDim retval(temp.Count - 1)
        For count As Integer = 1 To temp.Count
            retval(count - 1) = temp.Item(count)
        Next
        temp = Nothing
        Return retval
    End Function
#End Region

#Region " Counting Objects "
    Public Function CountAllDirs() As Long
        Return Me.CountAllDirs(ROOT)
    End Function

    Public Function CountAllDirs(ByVal id As Long) As Long
        Dim temp As DFLNode = Me.FindItem(id)
        Dim count As Long = Me.CountSubdirsInDir(temp)
        If count > 0 Then
            For Each d As DFLNode In Me.GetDirSubdirs(temp.Fullname)
                count += CountAllDirs(d.Id)
            Next
        End If
        Return count
    End Function

    Public Function CountAllFiles() As Long
        Return Me.CountAllFiles(ROOT)
    End Function

    Public Function CountAllFiles(ByVal id As Long) As Long
        Dim temp As DFLNode = Me.FindItem(id)
        Dim count As Long = Me.CountFilesInDir(temp)
        Dim dcount As Long = Me.CountSubdirsInDir(temp)
        If dcount > 0 Then
            For Each f As DFLNode In Me.GetDirSubdirs(temp.Fullname)
                count += CountAllFiles(f.Id)
            Next
        End If
        Return count
    End Function

    Public Function CountSubdirsInDir(ByVal obj As DFLNode) As Long
        Return CountObjectsInDir(obj, ObjType.DIR)
    End Function

    Public Function CountFilesInDir(ByVal obj As DFLNode) As Long
        Return CountObjectsInDir(obj, ObjType.FILE)
    End Function

    Public Function CountObjectsInDir(ByVal obj As DFLNode) As Long
        Return CountObjectsInDir(obj, ObjType.BOTH)
    End Function

    Public Function CountObjectsInDir(ByVal obj As DFLNode, ByVal type As String) As Long
        Dim dcount As Long = 0
        Dim fcount As Long = 0
        For Each dfl As DFLNode In dflTable
            If dfl.Parent = obj.Id Then
                If dfl.Type = ObjType.DIR Then dcount += 1
                If dfl.Type = ObjType.FILE Then fcount += 1
            End If
        Next
        If type = ObjType.DIR Then Return dcount
        If type = ObjType.FILE Then Return fcount
        Return dcount + fcount
    End Function
#End Region

#Region " Miscellaneous Public Functions "
    Public Function DumpTable() As String
        Dim temp As String = ""
        For Each x As DFLNode In dflTable
            temp += x.Id.ToString + ". " + x.Fullname + " (" + x.Parent.ToString + ")" + vbCrLf
        Next
        Return temp
    End Function

    Public Function Breadcrumbs(ByVal id As Long) As DFLNode()
        Dim temp As DFLNode = Me.FindItem(id)
        Return Me.Breadcrumbs(temp)
    End Function

    Public Function Breadcrumbs(ByVal path As String) As DFLNode()
        Dim temp As DFLNode = Me.FindItem(path)
        Return Me.Breadcrumbs(temp)
    End Function

    Public Function Breadcrumbs(ByVal node As DFLNode) As DFLNode()
        Dim temp As Collection = New Collection
        Dim temp_node As DFLNode = node
        temp.Add(node)
        While temp_node.Id <> 0
            Dim pnode = Me.FindParent(temp_node.Id)
            temp.Add(pnode)
            temp_node = pnode
        End While
        Dim retval() As DFLNode
        ReDim retval(temp.Count - 1)
        For n As Long = 1 To temp.Count
            retval(n - 1) = temp.Item(n)
        Next
        temp = Nothing
        Array.Reverse(retval)
        Return retval
    End Function

    Public Function StripStart(ByVal node As DFLNode) As String
        Dim retval As String = node.Fullname
        retval = retval.Substring(Me._start.Length)
        If retval.Length = 0 Then retval = "\"
        Return retval
    End Function

    Public Function WebPath(ByVal node As DFLNode) As String
        Dim retval As String = Me.StripStart(node)
        Return retval.Replace("\", "/")
    End Function
#End Region

End Class