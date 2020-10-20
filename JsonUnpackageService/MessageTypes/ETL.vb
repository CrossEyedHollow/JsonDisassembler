Imports Newtonsoft.Json.Linq

Public Class ETL
    Inherits Message

    Public Property EO_ID As String
    Public Property Event_Time As String
    Public Property Destination_ID1 As Integer
    Public Property Destination_ID2 As String
    Public Property Destination_ID3 As String
    Public Property Destination_ID3_Address_StreetOne As String
    Public Property Destination_ID3_Address_StreetTwo As String
    Public Property Destination_ID3_Address_City As String
    Public Property Destination_ID3_Address_PostCode As String
    Public Property Transport_mode As TransportMode
    Public Property Transport_vehicle As String
    Public Property Transport_cont1 As Integer
    Public Property Transport_cont2 As String
    Public Property EMCS As Integer
    Public Property EMCS_ARC As String
    Public Property UI_Type As AggregationType
    Public Property upUIs As String()
    Public Property aUIs As String()
    Public Property Transloading_comment As String

    Public Overrides Function GetReport() As String
        Return $"{Message_Type} message unpacked. JSON ID: '{Code}'"
    End Function
End Class

