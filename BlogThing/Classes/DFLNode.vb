Imports System
Imports System.IO

Public Class DFLNode
    Private _id As Long
    Private _fullname As String
    Private _name As String
    Private _parent As Long
    Private _type As Integer
    Private _cdate As Long
    Private _mdate As Long

    Private Enum ObjType As Integer
        FILE = 1
        DIR = 2
    End Enum

    Public Sub New()
    End Sub

    Public Sub New(ByVal id As Long, ByVal fn As String, _
                   ByVal parent As Long, ByVal type As Integer)
        Me._id = id
        Me._fullname = fn
        Me._parent = parent
        Me._type = type

        Dim temp() As String = fn.Split("\")
        Me._name = temp(temp.Length - 1)

        If type = ObjType.DIR Then
            Me._cdate = Directory.GetCreationTime(fn).Ticks
            Me._mdate = Directory.GetLastWriteTime(fn).Ticks
        ElseIf type = ObjType.FILE Then
            Me._cdate = File.GetCreationTime(fn).Ticks
            Me._mdate = File.GetLastWriteTime(fn).Ticks
        End If
    End Sub

    Public ReadOnly Property Id() As Integer
        Get
            Return Me._id
        End Get
    End Property

    Public ReadOnly Property Fullname() As String
        Get
            Return Me._fullname
        End Get
    End Property

    Public ReadOnly Property Name() As String
        Get
            Return Me._name
        End Get
    End Property

    Public ReadOnly Property Parent() As Integer
        Get
            Return Me._parent
        End Get
    End Property

    Public ReadOnly Property Type() As Integer
        Get
            Return Me._type
        End Get
    End Property

    Public ReadOnly Property Created() As Long
        Get
            Return Me._cdate
        End Get
    End Property

    Public ReadOnly Property Modified() As Long
        Get
            Return Me._mdate
        End Get
    End Property
End Class