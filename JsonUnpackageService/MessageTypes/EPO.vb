Imports Newtonsoft.Json.Linq

Public Class EPO
    Inherits Message

    Public Property EO_ID As String
    Public Property Event_Time As String
    Public Property Order_Number As String
    Public Property Order_Date As String
    Public Property UI_Type As AggregationType
    Public Property upUIs As String()
    Public Property aUIs As String()
    Public Property Comments As String

    Public Overrides Function GetReport() As String
        Return $"{Message_Type} message unpacked. JSON ID: '{Code}'"
    End Function

    Public Overrides Function GetSqlStatement() As String
        Return MyBase.GetSqlStatement()
    End Function
End Class

