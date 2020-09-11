Imports ReportTools

Public Class DBManager
    Inherits DBBase

    Public Sub New()
        Init()
    End Sub

#Region "Functions"
    'Public Function CheckIRUs() As DataTable
    '    Dim query As String = CheckForNewJSONs("tbljsonsecondary")
    '    Return ReadDatabase(query)
    'End Function

    'Public Function CheckTableJSON() As DataTable
    '    Dim query As String = CheckForNewJSONs("tbljson")
    '    Return ReadDatabase(query)
    'End Function
    'Public Function CheckTableJSON(searchType As String) As DataTable
    '    Dim query As String = CheckForNewJSONs("tbljson", searchType)
    '    Return ReadDatabase(query)
    'End Function

    Public Function CheckSecondaryTable() As DataTable
        Dim query As String = $"SELECT * FROM `{DBName}`.`tbljsonsecondary` WHERE fldUnpacked IS NULL AND (fldType = 'IRU' OR fldType = 'ERP') ORDER BY FIELD(fldType, 'IRU', 'ERP'); "
        Return ReadDatabase(query)
    End Function

    Public Function CheckPrimaryTable() As DataTable
        Dim query As String = $"SELECT * FROM `{DBName}`.`tbljson` WHERE fldUnpacked IS NULL ORDER BY FIELD(fldType, 'EPA', 'EUA') DESC; "
        Return ReadDatabase(query)
    End Function

    Public Sub UpdateJsonStatus(index As Integer, table As String)
        Dim query As String = $"UPDATE `{DBName}`.`{table}` SET fldUnpacked = NOW() WHERE fldIndex = {index};"
        Execute(query)
    End Sub

    'Public Function CheckForType(type As String) As DataTable
    '    Select Case type.ToUpper()
    '        Case "IRU"
    '            Return CheckIRUs()
    '        Case "EUA", "EPA", "RCL", "EDP", "EIV", "EPO", "EPR", "ERP", "ETL", "EUD", "EVR", "IDA"
    '            Return CheckTableJSON(type)
    '        Case ""
    '            Return CheckTableJSON()
    '        Case Else
    '            Throw New NotImplementedException($"Type: {type} not implemented. CheckForType() failed to execute.")
    '    End Select
    'End Function

    'Public Sub UpdateJsonType(index As Integer, type As String)
    '    Select Case type.ToUpper()
    '        Case "IRU"
    '            UpdateJsonStatus(index, "tbljsonsecondary")
    '        Case "EUA", "EPA", "RCL", "EDP", "EIV", "EPO", "EPR", "ERP", "ETL", "EUD", "EVR", "IDA", ""
    '            UpdateJsonStatus(index, "tbljson")
    '        Case Else
    '            Throw New NotImplementedException($"Type: {type} not implemented. UpdateJsonType() failed to execute.")
    '    End Select
    'End Sub
#End Region

#Region "Queries"
    'Private Function CheckForNewJSONs(table As String) As String
    '    Return $"SELECT * FROM `{DBName}`.{table} WHERE fldUnpacked is null and fldType = 'IRU' ORDER BY fldType, fldIndex;"
    'End Function

    'Private Function CheckForNewJSONs(table As String, msgType As String) As String
    '    Return $"SELECT * FROM `{DBName}`.{table} WHERE fldUnpacked is null AND fldType = '{msgType}';"
    'End Function

    'Private Function UpdateJSONStatusQuery(index As Integer, table As String) As String
    '    Return $"UPDATE `{DBName}`.`{table}` SET fldUnpacked = NOW() WHERE fldIndex = {index};"
    'End Function
#End Region
End Class
