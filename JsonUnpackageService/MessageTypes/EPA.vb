﻿Imports Newtonsoft.Json.Linq

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
        Dim eTime As String = ParseTime(Event_Time).ToMySQL()
        output += $"INSERT IGNORE INTO `{DBBase.DBName}`.`tblaggregatedcodes` (fldPrintCode, fldLocation, fldPrintDate, fldJSONid) "
        output += $"VALUES ('{aUI}', '{F_ID}', '{eTime}', '{Code}'); "

        Select Case Aggregation_Type
            Case AggregationType.Unit_Packets_Only
                output += $"UPDATE `{DBBase.DBName}`.`tblprimarycodes` SET fldEPA = '{Code}', fldParentCode = '{aUI}', fldAggregatedDate = '{eTime}' "
                output += $"WHERE fldPrintCode in ('{String.Join("','", Aggregated_UIs1)}');"
            Case AggregationType.Aggregated_Only
                output += $"UPDATE `{DBBase.DBName}`.`tblaggregatedcodes` SET fldEPA = '{Code}', fldParentCode = '{aUI}', fldAggregatedDate = '{eTime}' "
                output += $"WHERE fldPrintCode in ('{String.Join("','", Aggregated_UIs2)}');"
            Case AggregationType.Both
                output += $"UPDATE `{DBBase.DBName}`.`tblprimarycodes` AS P, `{DBBase.DBName}`.`tblaggregatedcodes` AS A "
                output += $"SET P.fldEPA = '{Code}', P.fldParentCode = '{aUI}', P.fldAggregatedDate = '{eTime}', A.fldEPA = '{Code}', A.fldParentCode = '{aUI}', A.fldAggregatedDate = '{eTime}' "
                output += $"WHERE P.fldPrintCode in ('{String.Join("','", Aggregated_UIs1)}') "
                output += $"AND A.fldPrintCode in ('{String.Join("','", Aggregated_UIs2)}');"
            Case Else
                Throw New NotImplementedException($"AggregationType '{Aggregation_Type}' does not exist.")
        End Select
        Return output
    End Function

    Public Overrides Function GetReport() As String
        Return $"{Message_Type} message unpacked. JSON ID: '{Code}'"
    End Function
End Class

