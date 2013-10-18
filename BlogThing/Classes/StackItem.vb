Public Class StackItem
    Private _item As String
    Private _type As Byte

    Public Enum ItemType As Byte
        HTML = 0
        COMMAND = 1
    End Enum

    Public Sub New(ByVal i As String, ByVal t As Byte)
        If t = 1 Then Me._item = cleanCommand(i) Else Me._item = i
        Me._type = t
    End Sub

    Public ReadOnly Property Item() As String
        Get
            Return Me._item
        End Get
    End Property

    Public ReadOnly Property Type() As Byte
        Get
            Return Me._type
        End Get
    End Property

    Private Function cleanCommand(ByVal cmd As String) As String
        cmd = cmd.Substring(2)
        cmd = cmd.Substring(0, cmd.Length - 2)
        While cmd.Substring(0, 1) = " "
            cmd = cmd.Substring(1)
        End While
        While cmd.Substring(cmd.Length - 1, 1) = " "
            cmd = cmd.Substring(0, cmd.Length - 1)
        End While
        Return cmd
    End Function
End Class
