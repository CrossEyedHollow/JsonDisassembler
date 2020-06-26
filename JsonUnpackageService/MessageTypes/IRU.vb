Imports Newtonsoft.Json.Linq

Public Class IRU
    Inherits Message

    Public Property EO_ID As String
    Public Property F_ID As String
    Public Property Event_Time As String
    Public Property Process_Type As Integer
    Public Property M_ID As String
    Public Property P_Type As String
    Public Property P_OtherType As String
    Public Property P_CN As String
    Public Property P_Brand As String
    Public Property TP_ID As String
    Public Property TP_PN As String
    Public Property Intended_Market As String
    Public Property Intended_Route1 As Integer
    Public Property Intended_Route2 As String
    Public Property Import As Integer
    Public Property Req_Quantity As Integer
    Public Property P_OtherID As String
    Public Property upUI As String()
    Public Property P_weight As Decimal
    Public Property Order_Req_Quantity As String
    Public Property Order_number As String

    Public Overrides Function GetSqlStatement() As String
        Dim output As String = ""
        Dim eTime = If(Event_Time = Nothing, "NOW()", $"'{JsonDatetime.ParseTime(Event_Time).ToMySQL()}'")
        output += $"INSERT IGNORE INTO `{DBBase.DBName}`.`tblprimarycodes` "
        output += "(fldCode, fldIssueDate, fldJSONid) "
        output += "VALUES ('"
        output += String.Join($"',{eTime},{GetJsonIndex}),('", upUI)
        output += $"',{eTime},{GetJsonIndex}); "
        Dim second As String = ""
        'Add insert to 2nd IRU specific table
        second += $"INSERT INTO `{DBBase.DBName}`.`tbliru` "
        second += "(fldJSON, fldEvent_Time, fldEO_ID, fldF_ID, fldM_ID, fldProcess_Type, fldP_Type, fldP_OtherType, "
        second += "fldP_CN, fldP_Brand, fldTP_ID, fldTP_PN, fldIntended_Market, fldIntended_Route1, fldIntended_Route2, "
        second += "fldImport, fldReq_Quantity, fldP_OtherID, fldPWeight, fldOrderReqQuantity, fldOrderNumber) VALUES "
        second += $"({GetJsonIndex}, {eTime}, '{EO_ID}', '{F_ID}', '{M_ID}', {Process_Type}, {P_Type}, '{P_OtherType}', "
        second += $"'{P_CN}', '{P_Brand}', '{TP_ID}', '{TP_PN}', '{Intended_Market}', {Intended_Route1}, '{Intended_Route2}', "
        second += $"{Import}, {Req_Quantity}, '{P_OtherID}', '{P_weight}', '{Order_Req_Quantity}', '{Order_number}');"
        second = second.Replace("''", "null")
        output += second
        Return output
    End Function

    Public Overrides Function GetReport() As String
        Return $"{Message_Type} message unpacked. JSON ID: '{GetJsonIndex}', upUI count: {upUI.Length}."
    End Function
End Class
