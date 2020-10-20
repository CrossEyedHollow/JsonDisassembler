Imports Newtonsoft.Json.Linq

Public Class ERP
    Inherits Message

    Public Property EO_ID As String
    Public Property F_ID As String
    Public Property Event_Time As String
    Public Property Product_Return As Integer
    Public Property UI_Type As AggregationType
    Public Property upUIs As String()
    Public Property aUIs As String()
    Public Property Arrival_comment As String

    Public Overrides Function GetSqlStatement() As String
        Dim output As String = ""
        Dim eventTime As String = JsonDatetime.ParseTime(Event_Time).ToMySQL()
        output += $"INSERT INTO `{DBBase.DBName}`.`tblarrival` (fldEvent_Time,fldEO_ID,fldF_ID,fldReturnType,fldComment,fldJsonID) "
        output += $"VALUES ('{eventTime}','{EO_ID}','{F_ID}','{Product_Return}','{Arrival_comment}','{Code}'); "

        Select Case Product_Return
            Case 0 'New products
                'Insert as new codes
                Select Case UI_Type
                    Case AggregationType.Unit_Packets_Only
                        output += $"INSERT IGNORE INTO `{DBBase.DBName}`.`tblprimarycodes` (fldCode, fldIssueDate, fldERP) VALUES ('"
                        output += String.Join($"','{eventTime}','{Code}'),('", upUIs)
                        output += $"','{eventTime}','{Code}'); "
                    Case AggregationType.Aggregated_Only
                        output += $"INSERT IGNORE INTO `{DBBase.DBName}`.`tblaggregatedcodes` (fldPrintCode, fldPrintDate, fldERP) VALUES ('"
                        output += String.Join($"','{eventTime}','{Code}'),('", aUIs)
                        output += $"','{eventTime}','{Code}'); "
                    Case AggregationType.Both
                        output += $"INSERT IGNORE INTO `{DBBase.DBName}`.`tblprimarycodes` (fldCode, fldIssueDate, fldERP) VALUES ('"
                        output += String.Join($"','{eventTime}','{Code}'),('", upUIs)
                        output += $"','{eventTime}','{Code}'); "
                        output += $"INSERT IGNORE INTO `{DBBase.DBName}`.`tblaggregatedcodes` (fldPrintCode, fldPrintDate, fldERP) VALUES ('"
                        output += String.Join($"','{eventTime}','{Code}'),('", aUIs)
                        output += $"','{eventTime}','{Code}'); "
                    Case Else
                        Throw New NotImplementedException($"Ui_type '{UI_Type}' does not exist.")
                End Select
            Case 1 'Products are complete or partial return
                'Update all codes ERP column, clean Dispatchment (fldEDP)
                Select Case UI_Type
                    Case AggregationType.Unit_Packets_Only
                        output += $"UPDATE `{DBBase.DBName}`.`tblprimarycodes` SET fldERP = '{Code}', fldEDP = NULL, fldLocation = '{F_ID}' "
                        output += $"WHERE fldPrintCode in ('{String.Join("','", upUIs)}');"
                    Case AggregationType.Aggregated_Only
                        output += $"UPDATE `{DBBase.DBName}`.`tblaggregatedcodes` SET fldERP = '{Code}', fldEDP = NULL, fldLocation = '{F_ID}' "
                        output += $"WHERE fldPrintCode in ('{String.Join("','", aUIs)}');"
                    Case AggregationType.Both
                        output += $"UPDATE `{DBBase.DBName}`.`tblprimarycodes` AS P, `{DBBase.DBName}`.`tblaggregatedcodes` AS A "
                        output += $"SET P.fldERP = '{Code}', P.fldEDP = NULL, P.fldLocation = '{F_ID}', "
                        output += $"A.fldERP = '{Code}', A.fldEDP = NULL, A.fldLocation = '{F_ID}' "
                        output += $"WHERE P.fldPrintCode in ('{String.Join("','", upUIs)}') "
                        output += $"AND A.fldPrintCode in ('{String.Join("','", aUIs)}');"
                    Case Else
                        Throw New NotImplementedException($"Ui_type '{UI_Type}' does not exist.")
                End Select
            Case Else 'Wrong value
                Throw New Exception($"Product_Return must be in the range 0 to 1, received value: {Product_Return}")
        End Select
        output = output.Replace("''", "null")

        Return output
    End Function

    Public Overrides Function GetReport() As String
        Return $"{Message_Type} message unpacked. JSON ID: '{Code}'"
    End Function
End Class

