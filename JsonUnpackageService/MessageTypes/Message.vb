Imports Newtonsoft.Json.Linq

Public Class Message
    'Public Property GetJsonIndex() As Integer
    Public Property Code As String
    Public Property Message_Type As String

    Public Overridable Function GetSqlStatement() As String
        Throw New InvalidOperationException($"Message Type: {Message_Type} not implemented")
    End Function

    Public Overridable Function GetReport() As String
        Throw New InvalidOperationException()
    End Function
End Class
