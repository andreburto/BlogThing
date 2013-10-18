Imports System.Windows.Forms

Module ErrorMsg
    Public Sub Show(ByVal msg As String)
        MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    End Sub

    Public Sub Show(ByVal ex As Exception)
        Dim msg As String = ex.Message + vbCrLf + vbCrLf + _
                            ex.StackTrace + vbCrLf + vbCrLf + _
                            ex.Source
        ErrorMsg.Show(msg)
    End Sub

    Public Sub Die(ByVal msg As String)
        ErrorMsg.Show(msg)
        End
    End Sub

    Public Sub Die(ByVal ex As Exception)
        ErrorMsg.Show(ex)
        End
    End Sub
End Module
