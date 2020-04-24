Imports Newtonsoft.Json.Linq

Public Class EUD
    Inherits Message

    Public Property EO_ID As String
    Public Property F_ID As String
    Public Property Event_Time As String
    Public Property aUI As String
    Public Property disaUI_Comment As String
    Public Overrides Function GetReport() As String
        Return $"{Message_Type} message unpacked. JSON ID: '{GetJsonIndex}'"
    End Function
End Class

