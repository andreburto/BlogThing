Imports System
Imports System.Collections
Imports System.IO

Public Class Templarse

    Private _template As String = ""
    Private _stack As Collection
    Private _commands As Hashtable

    Public ReadOnly Property Template() As String
        Get
            Return Me._template
        End Get
    End Property

    Public Sub New(ByVal html As String, ByRef cmds As Hashtable)
        Me._template = html
        Me._stack = ParseTemplate(html)
        Me._commands = cmds
    End Sub

    Public Function ExecuteTemplate() As String
        Dim retval As String = ""
        For Each i As StackItem In Me._stack
            If i.Type = 0 Then
                retval += i.Item
            ElseIf i.Type = 1 Then
                retval += Me.Commands(i.Item)
            End If
        Next
        Return retval
    End Function

    Public Overridable Function Commands(ByVal c As String) As String
        Dim retval As String = ""
        Dim parts() As String = c.Split(" ")
        Dim cmd As String = parts(0).ToLower

        If Not Me._commands.Contains(cmd) Then Return ""

        ' Copies the command table except for the current command
        Dim temp_cmds As Hashtable = New Hashtable
        For Each k As String In Me._commands.Keys
            If k <> cmd Then temp_cmds(k) = Me._commands(k)
        Next

        Dim temp_tp As Templarse = New Templarse(Me._commands(cmd), temp_cmds)
        temp_cmds = Nothing
        Return temp_tp.ExecuteTemplate()
    End Function

    Private Function ParseTemplate(ByVal html As String) As Collection
        Dim retval As Collection = New Collection
        Dim temp_str As String = ""
        Dim temp_type As Byte = 0
        Dim strlen As Integer = html.Length
        Dim strcnt As Integer = 0

        While strcnt < strlen
            Dim temp_chr As String = html.Substring(strcnt, 1)
            Dim do_this As Integer = 0

            If temp_chr = "<" Then
                If html.Substring(strcnt, 2) = "<%" Then do_this = 1
            End If

            If temp_chr = ">" Then
                If html.Substring(strcnt - 1, 2) = "%>" Then do_this = 2
            End If

            If do_this = 1 Then
                retval.Add(New StackItem(temp_str, temp_type))
                temp_str = temp_chr
                temp_type = StackItem.ItemType.COMMAND
            ElseIf do_this = 2 Then
                temp_str += temp_chr
                retval.Add(New StackItem(temp_str, temp_type))
                temp_str = ""
                temp_type = StackItem.ItemType.HTML
            Else
                temp_str += temp_chr
            End If

            strcnt += 1
        End While

        retval.Add(New StackItem(temp_str, temp_type))

        Return retval
    End Function
End Class