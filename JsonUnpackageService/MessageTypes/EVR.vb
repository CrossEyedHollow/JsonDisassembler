Imports Newtonsoft.Json.Linq

Public Class EVR
    Inherits Message

    Public Property EO_ID As String
    Public Property F_ID As String
    Public Property Event_Time As String
    Public Property UI_Type As AggregationType
    Public Property upUIs As String()
    Public Property aUIs As String()
    Public Property Delivery_comment As String
    Public Overrides Function GetReport() As String
        Return $"{Message_Type} message unpacked. JSON ID: '{GetJsonIndex}'"
    End Function
End Class

