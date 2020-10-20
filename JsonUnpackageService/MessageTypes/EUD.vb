Imports Newtonsoft.Json.Linq

Public Class EUD
    Inherits Message

    Public Property EO_ID As String
    Public Property F_ID As String
    Public Property Event_Time As String
    Public Property aUI As String
    Public Property disaUI_Comment As String

    Public Overrides Function GetReport() As String
        Return $"{Message_Type} message unpacked. JSON ID: '{Code}'"
    End Function

    Public Overrides Function GetSqlStatement() As String
        Dim output As String = ""
        output += $"UPDATE `{DBBase.DBName}`.`tblaggregatedcodes` SET fldEUD = '{Code}' WHERE fldPrintCode = '{aUI}';"
        output += $"UPDATE `{DBBase.DBName}`.`tblprimarycodes` AS P, `{DBBase.DBName}`.`tblaggregatedcodes` AS A "
        output += $"SET P.fldParentCode = NULL, A.fldParentCode = NULL "
        output += $"WHERE P.fldParentCode = '{aUI}' "
        output += $"AND A.fldParentCode = '{aUI}';"
        Return output
    End Function
End Class

