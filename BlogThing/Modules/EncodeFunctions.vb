Module EncodeFunctions

    Public Function XmlEncode(ByVal text As String) As String
        text = text.Replace("&", "&amp;")
        text = text.Replace("<", "&lt;")
        text = text.Replace(">", "&gt;")
        text = text.Replace("'", "&apos;")
        text = text.Replace("""", "&quot;")
        Return text
    End Function

    Public Function XmlDecode(ByVal text As String) As String
        text = text.Replace("&lt;", "<")
        text = text.Replace("&gt;", ">")
        text = text.Replace("&apos;", "'")
        text = text.Replace("&quot;", """")
        text = text.Replace("&amp;", "&")
        Return text
    End Function

End Module
