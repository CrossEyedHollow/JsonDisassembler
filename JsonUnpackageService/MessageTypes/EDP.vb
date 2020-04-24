Imports Newtonsoft.Json.Linq

Public Class EDP
    Inherits Message

    Public Property EO_ID As String
    Public Property F_ID As String
    Public Property Event_Time As String
    Public Property Destination_ID1 As Integer
    Public Property Destination_ID2 As String
    Public Property Destination_ID3 As String()
    Public Property Destination_ID4 As String()
    Public Property Destination_ID5 As String
    Public Property Destination_ID5_Address_StreetOne As String
    Public Property Destination_ID5_Address_StreetTwo As String
    Public Property Destination_ID5_Address_City As String
    Public Property Destination_ID5_Address_PostCode As String
    Public Property Transport_mode As TransportMode
    Public Property Transport_vehicle As String
    Public Property Transport_cont1 As Integer
    Public Property Transport_cont2 As String
    Public Property Transport_s1 As Integer
    Public Property Transport_s2 As String
    Public Property EMCS As Integer
    Public Property EMCS_ARC As String
    Public Property SAAD As Integer
    Public Property SAAD_number As String
    Public Property Exp_Declaration As Integer
    Public Property Exp_DeclarationNumber As String
    Public Property UI_Type As AggregationType
    Public Property upUIs As String()
    Public Property aUIs As String()
    Public Property Dispatch_comment As String


    Public Overrides Function GetSqlStatement() As String
        Dim output As String = ""
        output += $"INSERT INTO `{DBBase.DBName}`.`tbldeployment` "
        output += "(fldEvent_Time,fldEO_ID,fldF_ID,fldDestID1,fldDestID2,fldDestID3,fldDestID4,fldDestAddress,fldDestinationStreet1,fldDestinationStreet2,fldDestinationCity,fldDestPostCode,fldTransportMode,fldTransportVehicle,fldTransportCont1,fldTransporCont2,fldTransportS1,fldTransportS2,fldEMCS,fldEMCS_ARC,fldSAAD,fldSAAD_Num,fldExpDeclaration,fldExpDeclNumber,fldComment,fldJsonID) "
        output += $"VALUES ('{JsonDatetime.ParseTime(Event_Time).ToMySQL()}','{EO_ID}','{F_ID}','{Destination_ID1}','{Destination_ID2}','{String.Join("','", If(Destination_ID3, New String() {}))}','{String.Join("','", If(Destination_ID4, New String() {}))}','{Destination_ID5}','{Destination_ID5_Address_StreetOne}','{Destination_ID5_Address_StreetTwo}','{Destination_ID5_Address_City}','{Destination_ID5_Address_PostCode}'," &
            $"'{CInt(Transport_mode)}','{Transport_vehicle}','{Transport_cont1}','{Transport_cont2}','{Transport_s1}','{Transport_s2}'," &
            $"'{EMCS}','{EMCS_ARC}','{SAAD}','{SAAD_number}','{Exp_Declaration}','{Exp_DeclarationNumber}','{Dispatch_comment}','{GetJsonIndex}'); "
        output = output.Replace("''", "null")

        Select Case UI_Type
            Case AggregationType.Unit_Packets_Only
                output += $"UPDATE `{DBBase.DBName}`.`tblprimarycodes` SET fldEDP = '{GetJsonIndex}' "
                output += $"WHERE fldPrintCode in ('{String.Join("','", upUIs)}');"
            Case AggregationType.Aggregated_Only
                output += $"UPDATE `{DBBase.DBName}`.`tblaggregatedcodes` SET fldEDP = '{GetJsonIndex}' "
                output += $"WHERE fldPrintCode in ('{String.Join("','", aUIs)}');"
            Case AggregationType.Both
                output += $"UPDATE `{DBBase.DBName}`.`tblprimarycodes` AS P, `{DBBase.DBName}`.`tblaggregatedcodes` AS A "
                output += $"SET P.fldEDP = '{GetJsonIndex}', A.fldEDP = '{GetJsonIndex}' "
                output += $"WHERE P.fldPrintCode in ('{String.Join("','", upUIs)}') "
                output += $"AND A.fldPrintCode in ('{String.Join("','", aUIs)}');"
            Case Else
                Throw New NotImplementedException($"Ui_type '{UI_Type}' does not exist.")
        End Select
        Return output
    End Function

    Public Overrides Function GetReport() As String
        Return $"{Message_Type} message unpacked. JSON ID: '{GetJsonIndex}'. Dispatched UIs count: { If(upUIs Is Nothing, 0, upUIs.Length) + If(aUIs Is Nothing, 0, aUIs.Length)}"
    End Function
End Class

