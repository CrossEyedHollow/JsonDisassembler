Imports Newtonsoft.Json.Linq

Public Class EPA
    Inherits Message

    Public Property EO_ID As String
    Public Property F_ID As String
    Public Property Event_Time As String
    Public Property aUI As String
    Public Property Aggregation_Type As AggregationType
    Public Property Aggregated_UIs1 As String()
    Public Property Aggregated_UIs2 As String()
    Public Property aUI_comment As String

    Public Overrides Function GetSqlStatement() As String
        Dim output As String = ""

        output += $"INSERT IGNORE INTO `{DBBase.DBName}`.`tblaggregatedcodes` (fldPrintCode, fldPrintDate, fldJSONid) "
        output += $"VALUES ('{aUI}', '{JsonDatetime.ParseTime(Event_Time).ToMySQL()}', {GetJsonIndex}); "

        Select Case Aggregation_Type
            Case AggregationType.Unit_Packets_Only
                output += $"UPDATE `{DBBase.DBName}`.`tblprimarycodes` SET fldParentCode = '{aUI}' "
                output += $"WHERE fldPrintCode in ('{String.Join("','", Aggregated_UIs1)}');"
            Case AggregationType.Aggregated_Only
                output += $"UPDATE `{DBBase.DBName}`.`tblaggregatedcodes` SET fldParentCode = '{aUI}' "
                output += $"WHERE fldPrintCode in ('{String.Join("','", Aggregated_UIs2)}');"
            Case AggregationType.Both
                output += $"UPDATE `{DBBase.DBName}`.`tblprimarycodes` AS P, `{DBBase.DBName}`.`tblaggregatedcodes` AS A "
                output += $"SET P.fldParentCode = '{aUI}', A.fldParentCode = '{aUI}' "
                output += $"WHERE P.fldPrintCode in ('{String.Join("','", Aggregated_UIs1)}') "
                output += $"AND A.fldPrintCode in ('{String.Join("','", Aggregated_UIs2)}');"
            Case Else
                Throw New NotImplementedException($"AggregationType '{Aggregation_Type}' does not exist.")
        End Select
        Return output
    End Function

    Public Overrides Function GetReport() As String
        Return $"{Message_Type} message unpacked. JSON ID: '{GetJsonIndex}'"
    End Function
End Class

