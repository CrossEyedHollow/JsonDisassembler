Imports Newtonsoft.Json.Linq

Public Class IDA
    Inherits Message

    Public Property EO_ID As String
    Public Property Event_Time As String
    Public Property Deact_Reason1 As DeactivationType
    Public Property Deact_Reason2 As String
    Public Property Deact_Reason3 As String
    Public Property Deact_Type As AggregationType
    Public Property Deact_upUI As String()
    Public Property Deact_aUI As String()

    Public Overrides Function GetReport() As String
        Return $"{Message_Type} message unpacked. JSON ID: '{GetJsonIndex}'"
    End Function

    Public Overrides Function GetSqlStatement() As String
        Select Case Deact_Type
            Case AggregationType.Unit_Packets_Only
                Return $"UPDATE `{DBBase.DBName}`.`tblprimarycodes` SET fldIDA = '{GetJsonIndex}' WHERE fldCode in ('{String.Join("','", Deact_upUI)}')"
            Case AggregationType.Aggregated_Only
                Return $"UPDATE `{DBBase.DBName}`.`tblaggregatedcodes` SET fldIDA = '{GetJsonIndex}' WHERE fldPrintCode in ('{String.Join("','", Deact_aUI)}')"
            Case Else
                Throw New Exception("Should be unreachable")
        End Select
    End Function
End Class

