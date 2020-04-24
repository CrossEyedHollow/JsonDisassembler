Imports Newtonsoft.Json.Linq

Public Class EUA
    Inherits Message

    Public Property EO_ID As String
    Public Property F_ID As String
    Public Property Event_Time As String
    Public Property upUI_1 As String()
    Public Property upUI_2 As String()
    Public Property upUI_comment As String

    Public Overrides Function GetSqlStatement() As String
        If upUI_1.Length <> upUI_2.Length Then Throw New Exception("UpUI_1 count doesnt match UpUI_2.")
        Dim output As String = ""
        output += $"UPDATE `{DBBase.DBName}`.`tblprimarycodes` SET fldPrintCode = (CASE "
        For i As Integer = 0 To upUI_1.Length - 1
            output += $"WHEN fldCode = '{upUI_2(i)}' THEN '{upUI_1(i)}' "
        Next
        output += $"end), fldPrintDate = '{ParseTime(Event_Time).ToMySQL()}', fldEUA = {GetJsonIndex} "
        output += $"WHERE fldCode IN ('{String.Join("','", upUI_2)}');"
        Return output
    End Function

    Public Overrides Function GetReport() As String
        Return $"{Message_Type} message unpacked. JSON ID: '{GetJsonIndex}'. Printed codes count: {upUI_1.Length}"
    End Function
End Class
