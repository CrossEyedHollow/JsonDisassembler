Imports Newtonsoft.Json.Linq

Public Class RCL
    Inherits Message

    Public Property EO_ID As String
    Public Property Recall_CODE As String
    Public Property Recall_Reason1 As RecallReasonType
    Public Property Recall_Reason2 As String
    Public Property Recall_Reason3 As String

    Public Overrides Function GetSqlStatement() As String
        Dim output As String = ""
        output += $"INSERT INTO `{DBBase.DBName}`.`tblrecall` (fldEO_ID,fldTargetID,fldRecallReason1,fldRecallReason2,fldRecallReason3,fldJsonID) "
        output += $"VALUES ('{EO_ID}','{Recall_CODE}','{CInt(Recall_Reason1)}','{Recall_Reason2}','{Recall_Reason3}','{GetJsonIndex}'); "
        Return output
    End Function

    Public Overrides Function GetReport() As String
        Return $"{Message_Type} message unpacked. JSON ID: '{GetJsonIndex}'"
    End Function
End Class
