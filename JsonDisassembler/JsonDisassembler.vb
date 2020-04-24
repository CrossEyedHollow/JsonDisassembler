Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class JsonUnpackager
    Shared Property TimeFormat As String = "yyMMddHH"
    Shared Property DateFormat As String = "yyyy-MM-dd"


    Private Sub New()
    End Sub

#Region "Operationals"
    ''' <summary>
    ''' Application of unit level UIs on unit packets event
    ''' </summary>
    ''' <returns></returns>
    Shared Function EUA(json As JObject) As EUAStruct

        'Get variables
        Dim EO_ID As String = json("EO_ID")
        Dim F_ID As String = json("F_ID")
        Dim eventTime As Date = DateTime.ParseExact(json("Event_Time"), TimeFormat, Nothing)
        Dim upUI_1 As String() = json.Item("upUI_1").ToObject(Of String())
        Dim upUI_2 As String() = json.Item("upUI_2").ToObject(Of String())
        Dim comment As String = json("upUI_comment")
        Dim recallCode As String = json("Code")

        'Put variables into structure
        Dim output As New EUAStruct With
        {
            .EO_ID = EO_ID,
            .F_ID = F_ID,
            .EventTime = eventTime,
            .UpUI_1 = upUI_1,
            .UpUI_2 = upUI_2,
            .Comment = comment,
            .RecallCode = recallCode
        }
        Return output
    End Function
    Shared Function EUA(json As String) As EUAStruct
        Dim j As JObject = JObject.Parse(json)
        Return EUA(j)
    End Function

    ''' <summary>
    ''' Message to report an aggregation event
    ''' </summary>
    ''' <returns></returns>
    Shared Function EPA(json As JObject) As EPAStruct
        'Get variables
        Dim EO_ID As String = json("EO_ID")
        Dim F_ID As String = json("F_ID")
        Dim eventTime As Date = DateTime.ParseExact(json("Event_Time"), TimeFormat, Nothing)
        Dim aUI As String = json("aUI")
        Dim aggregationType As AggregationType = Convert.ToInt32(json("Aggregation_Type"))
        Dim aggregatedUIs1 As String() = json.Item("Aggregated_UIs1").ToObject(Of String())
        Dim aggregatedUIs2 As String() = json.Item("Aggregated_UIs2").ToObject(Of String())
        Dim comment As String = json("aUI_comment")
        Dim recallCode As String = json("Code")

        'Put variables into structure
        Dim output As New EPAStruct With
        {
            .EO_ID = EO_ID,
            .F_ID = F_ID,
            .EventTime = eventTime,
            .AggregationType = aggregationType,
            .Aggregated_UIs1 = aggregatedUIs1,
            .Aggregated_UIs2 = aggregatedUIs2,
            .AUI = aUI,
            .Comment = comment,
            .RecallCode = recallCode
        }
        Return output
    End Function
    Shared Function EPA(json As String) As EPAStruct
        Dim j As JObject = JObject.Parse(json)
        Return EPA(j)
    End Function

    ''' <summary>
    '''  Message to report a dispatch event
    ''' </summary>
    ''' <returns></returns>
    Shared Function EDP(json As JObject) As EDPStruct
        Dim EO_ID As String = json("EO_ID")
        Dim F_ID As String = json("F_ID")
        Dim eventTime As Date = DateTime.ParseExact(json("Event_Time"), TimeFormat, Nothing)
        Dim destinationID1 As Integer = Convert.ToInt32(json("Destination_ID1"))
        Dim destinationID2 As String = json("Destination_ID2")
        Dim destinationID3 As String() = json.Item("Destination_ID3").ToObject(Of String())
        Dim destinationID4 As String() = json.Item("Destination_ID4").ToObject(Of String())
        Dim destinationAddress As String = json("Destination_ID5")
        Dim transport_mode As TransportMode = Convert.ToInt32(json("Transport_mode"))
        Dim transportVehicle As String = json("Transport_vehicle")
        Dim transport_cont1 As Integer = Convert.ToInt32(json("Transport_cont1"))
        Dim transport_cont2 As String = json("Transport_cont2")
        Dim transport_s1 As Integer = Convert.ToInt32(json("Transport_s1"))
        Dim transport_s2 As String = json("Transport_s2")
        Dim EMCS As Integer = Convert.ToInt32(json("EMCS"))
        Dim EMCS_ARC As String = json("EMCS_ARC")
        Dim SAAD As Integer = Convert.ToInt32(json("SAAD"))
        Dim SAAD_number As String = json("SAAD_number")
        Dim Exp_Declaration As Integer = Convert.ToInt32(json("Exp_Declaration"))
        Dim Exp_DeclarationNumber As String = json("Exp_DeclarationNumber")
        Dim ui_type As AggregationType = Convert.ToInt32(json("UI_Type"))
        Dim upUIs As String() = json.Item("upUIs").ToObject(Of String())
        Dim aUIs As String() = json.Item("aUIs").ToObject(Of String())
        Dim comment As String = json("Dispatch_comment")
        Dim recallCode As String = json("Code")

        'Put variables into structure
        Dim output As New EDPStruct With
            {
                .EO_ID = EO_ID,
                .F_ID = F_ID,
                .EventTime = eventTime,
                .DestinationID1 = destinationID1,
                .DestinationID2 = destinationID2,
                .DestinationID3 = destinationID3,
                .DestinationID4 = destinationID4,
                .DestinationAddress = destinationAddress,
                .Transport_mode = transport_mode,
                .TransportVehicle = transportVehicle,
                .Transport_cont1 = transport_cont1,
                .Transport_cont2 = transport_cont2,
                .Transport_s1 = transport_s1,
                .Transport_s2 = transport_s2,
                .EMCS = EMCS,
                .EMCS_ARC = EMCS_ARC,
                .SAAD = SAAD,
                .SAAD_number = SAAD_number,
                .Exp_Declaration = Exp_Declaration,
                .Exp_DeclarationNumber = Exp_DeclarationNumber,
                .Ui_type = ui_type,
                .UpUIs = upUIs,
                .AUIs = aUIs,
                .Comment = comment,
                .RecallCode = recallCode
            }
        Return output
    End Function
    Shared Function EDP(json As String) As EDPStruct
        Dim j As JObject = JObject.Parse(json)
        Return EDP(j)
    End Function

    ''' <summary>
    ''' Message to report a reception event
    ''' </summary>
    ''' <returns></returns>
    Shared Function ERP(json As JObject) As ERPStruct
        Dim EO_ID As String = json("EO_ID")
        Dim F_ID As String = json("F_ID")
        Dim eventTime As Date = DateTime.ParseExact(json("Event_Time"), TimeFormat, Nothing)
        Dim product_return As Integer = Convert.ToInt32(json("Product_Return"))
        Dim ui_type As AggregationType = Convert.ToInt32(json("UI_Type"))
        Dim upUIs As String() = json.Item("upUIs").ToObject(Of String())
        Dim aUIs As String() = json.Item("aUIs").ToObject(Of String())
        Dim comment As String = json("Arrival_comment")
        Dim recallCode As String = json("Code")

        'Put variables into structure
        Dim output As New ERPStruct With
        {
            .EO_ID = EO_ID,
            .F_ID = F_ID,
            .EventTime = eventTime,
            .Product_Return = product_return,
            .Ui_type = ui_type,
            .UpUIs = upUIs,
            .AUIs = aUIs,
            .Comment = comment,
            .RecallCode = recallCode
        }
        Return output
    End Function
    Shared Function ERP(json As String) As ERPStruct
        Dim j As JObject = JObject.Parse(json)
        Return ERP(j)
    End Function

    ''' <summary>
    ''' Message to report a trans-loading event
    ''' </summary>
    ''' <returns></returns>
    Shared Function ETL(json As JObject) As ETLStruct
        Dim EO_ID As String = json("EO_ID")
        Dim eventTime As Date = DateTime.ParseExact(json("Event_Time"), TimeFormat, Nothing)
        Dim destinationID1 As Integer = Convert.ToInt32(json("Destination_ID1"))
        Dim destinationID2 As String = json("Destination_ID2")
        Dim destinationAddress As String = json("Destination_ID3")
        Dim transport_mode As TransportMode = Convert.ToInt32(json("Transport_mode"))
        Dim transportVehicle As String = json("Transport_vehicle")
        Dim transport_cont1 As Integer = Convert.ToInt32(json("Transport_cont1"))
        Dim transport_cont2 As String = json("Transport_cont2")
        Dim EMCS As Integer = Convert.ToInt32(json("EMCS"))
        Dim EMCS_ARC As String = json("EMCS_ARC")
        Dim ui_type As AggregationType = Convert.ToInt32(json("UI_Type"))
        Dim upUIs As String() = json.Item("upUIs").ToObject(Of String())
        Dim aUIs As String() = json.Item("aUIs").ToObject(Of String())
        Dim comment As String = json("Transloading_comment")
        Dim recallCode As String = json("Code")

        'Put variables into structure
        Dim output As New ETLStruct With
            {
                .EO_ID = EO_ID,
                .EventTime = eventTime,
                .DestinationID1 = destinationID1,
                .DestinationID2 = destinationID2,
                .DestinationAddress = destinationAddress,
                .Transport_mode = transport_mode,
                .TransportVehicle = transportVehicle,
                .Transport_cont1 = transport_cont1,
                .Transport_cont2 = transport_cont2,
                .EMCS = EMCS,
                .EMCS_ARC = EMCS_ARC,
                .Ui_type = ui_type,
                .UpUIs = upUIs,
                .AUIs = aUIs,
                .Comment = comment,
                .RecallCode = recallCode
            }
        Return output
    End Function
    Shared Function ETL(json As String) As ETLStruct
        Dim j As JObject = JObject.Parse(json)
        Return ETL(j)
    End Function

    ''' <summary>
    ''' Message to report an UID disaggregation
    ''' </summary>
    ''' <returns></returns>
    Shared Function EUD(json As JObject) As EUDStruct
        Dim EO_ID As String = json("EO_ID")
        Dim F_ID As String = json("F_ID")
        Dim eventTime As Date = DateTime.ParseExact(json("Event_Time"), TimeFormat, Nothing)
        Dim aUI As String = json("aUI")
        Dim comment As String = json("disaUI_Comment")
        Dim recallCode As String = json("Code")

        'Put variables into structure
        Dim output As New EUDStruct With
            {
                .EO_ID = EO_ID,
                .F_ID = F_ID,
                .EventTime = eventTime,
                .AUI = aUI,
                .Comment = comment,
                .RecallCode = recallCode
            }
        Return output
    End Function
    Shared Function EUD(json As String) As EUDStruct
        Dim j As JObject = JObject.Parse(json)
        Return EUD(j)
    End Function

    ''' <summary>
    ''' Message to report the delivery carried out with a vending van to retail outlet
    ''' </summary>
    ''' <returns></returns>
    Shared Function EVR(json As JObject) As EVRStruct
        Dim EO_ID As String = json("EO_ID")
        Dim F_ID As String = json("F_ID")
        Dim eventTime As Date = DateTime.ParseExact(json("Event_Time"), TimeFormat, Nothing)
        Dim ui_type As AggregationType = Convert.ToInt32(json("UI_Type"))
        Dim upUIs As String() = json.Item("upUIs").ToObject(Of String())
        Dim aUIs As String() = json.Item("aUIs").ToObject(Of String())
        Dim comment As String = json("Delivery_comment")
        Dim recallCode As String = json("Code")

        'Put variables into structure
        Dim output As New EVRStruct With
            {
                .EO_ID = EO_ID,
                .F_ID = F_ID,
                .EventTime = eventTime,
                .Ui_type = ui_type,
                .UpUIs = upUIs,
                .AUIs = aUIs,
                .Comment = comment,
                .RecallCode = recallCode
            }
        Return output
    End Function
    Shared Function EVR(json As String) As EVRStruct
        Dim j As JObject = JObject.Parse(json)
        Return EVR(j)
    End Function

    ''' <summary>
    ''' Message to request a UID deactivation
    ''' </summary>
    ''' <returns></returns>
    Shared Function IDA(json As JObject) As IDAStruct
        Dim EO_ID As String = json("EO_ID")
        Dim eventTime As Date = DateTime.ParseExact(json("Event_Time"), TimeFormat, Nothing)
        Dim deact_reason1 As DeactivationType = Convert.ToInt32(json("Deact_Reason1"))
        Dim deact_reason2 As String = json("Deact_Reason2")
        Dim deact_reason3 As String = json("Deact_Reason3")
        Dim deact_type As AggregationType = Convert.ToInt32(json("Deact_Type"))
        Dim upUIs As String() = json.Item("Deact_upUI").ToObject(Of String())
        Dim aUIs As String() = json.Item("Deact_aUI").ToObject(Of String())
        Dim recallCode As String = json("Code")

        'Put variables into structure
        Dim output As New IDAStruct With
            {
                .EO_ID = EO_ID,
                .EventTime = eventTime,
                .Deact_Reason1 = deact_reason1,
                .Deact_Reason2 = deact_reason2,
                .Deact_Reason3 = deact_reason3,
                .Deact_Type = deact_type,
                .Deact_upUI = upUIs,
                .Deact_aUI = aUIs,
                .RecallCode = recallCode
            }
        Return output
    End Function
    Shared Function IDA(json As String) As IDAStruct
        Dim j As JObject = JObject.Parse(json)
        Return IDA(j)
    End Function

    Shared Function IRU(json As JObject) As IRUStruct
        Dim EO_ID As String = json("EO_ID")
        Dim F_ID As String = json("F_ID")
        Dim eventTime As Date = DateTime.ParseExact(json("Event_Time"), TimeFormat, Nothing)
        Dim Process_Type As Integer = Convert.ToInt32(json("Process_Type"))
        Dim M_ID As String = json("M_ID")
        Dim P_Type As String = Convert.ToInt32(json("P_Type"))
        Dim P_OtherType As String = json("P_OtherType")
        Dim P_CN As String = json("P_CN")
        Dim P_Brand As String = json("P_Brand")
        Dim TP_ID As String = json("TP_ID")
        Dim TP_PN As String = json("TP_PN")
        Dim Intended_Market As String = json("Intended_Market")
        Dim Intended_Route1 As Integer = Convert.ToInt32(json("Intended_Route1"))
        Dim Intended_Route2 As String = json("Intended_Route2")
        Dim Import As Integer = Convert.ToInt32(json("Import"))
        Dim Req_Quantity As Integer = Convert.ToInt32(json("Req_Quantity"))
        Dim P_OtherID As String = json("P_OtherID")
        Dim upUIs As String() = json("upUI").ToObject(Of String())
        Dim recallCode As String = json("Code")

        Dim output As New IRUStruct With
            {
                .EO_ID = EO_ID,
                .F_ID = F_ID,
                .EventTime = eventTime,
                .Process_Type = Process_Type,
                .M_ID = M_ID,
                .P_Type = P_Type,
                .P_OtherType = P_OtherType,
                .P_CN = P_CN,
                .P_Brand = P_Brand,
                .TP_ID = TP_ID,
                .TP_PN = TP_PN,
                .Intended_Market = Intended_Market,
                .Intended_Route1 = Intended_Route1,
                .Intended_Route2 = Intended_Route2,
                .Import = Import,
                .Req_Quantity = Req_Quantity,
                .P_OtherID = P_OtherID,
                .UpUIs = upUIs,
                .RecallCode = recallCode
            }
        Return output
    End Function
    Shared Function IRU(json As String) As IRUStruct
        Dim j As JObject = JObject.Parse(json)
        Return IRU(j)
    End Function
#End Region
#Region "Transactionals"
    ''' <summary>
    ''' Message to report an invoice
    ''' </summary>
    ''' <returns></returns>
    Shared Function EIV(json As JObject) As EIVStruct
        Dim EO_ID As String = json("EO_ID")
        Dim eventTime As Date = DateTime.ParseExact(json("Event_Time"), TimeFormat, Nothing)
        Dim invoice_type1 As InvoiceType = Convert.ToInt32(json("Invoice_Type1"))
        Dim invoice_type2 As String = json("Invoice_Type2")
        Dim invoice_number As String = json("Invoice_Number")
        Dim invoice_date As Date = DateTime.ParseExact(json("Invoice_Date"), DateFormat, Nothing)
        Dim invoice_seller As String = json("Invoice_Seller")
        Dim invoice_buyer1 As Integer = Convert.ToInt32(json("Invoice_Buyer1"))
        Dim invoice_buyer2 As String = json("Invoice_Buyer2")
        Dim buyer_name As String = json("Buyer_Name")
        Dim buyer_countryreg As String = json("Buyer_CountryReg")
        Dim buyer_address As String = json("Buyer_Address")
        Dim buyer_tax_n As String = json("Buyer_TAX_N")
        Dim first_seller_eu As Integer = Convert.ToInt32(json("First_Seller_EU"))
        Dim product_items1 As String() = json.Item("Product_Items_1").ToObject(Of String())
        Dim product_items2 As Integer() = json.Item("Product_Items_2").ToObject(Of Integer())
        Dim product_price As Decimal() = json.Item("Product_Price").ToObject(Of Decimal())
        Dim invoice_net As String = json("Invoice_Net")
        Dim invoice_currency As String = json("Invoice_Currency")
        Dim ui_type As AggregationType = Convert.ToInt32(json("UI_Type"))
        Dim upUIs As String() = json.Item("upUIs").ToObject(Of String())
        Dim aUIs As String() = json.Item("aUIs").ToObject(Of String())
        Dim comment As String = json("Invoice_comment")
        Dim recallCode As String = json("Code")

        'Put variables into structure
        Dim output As New EIVStruct With
            {
                .EO_ID = EO_ID,
                .EventTime = eventTime,
                .Invoice_type1 = invoice_type1,
                .Invoice_type2 = invoice_type2,
                .Invoice_number = invoice_number,
                .Invoice_date = invoice_date,
                .Invoice_seller = invoice_seller,
                .Invoice_buyer1 = invoice_buyer1,
                .Invoice_buyer2 = invoice_buyer2,
                .Buyer_name = buyer_name,
                .Buyer_countryreg = buyer_countryreg,
                .Buyer_address = buyer_address,
                .Buyer_tax_n = buyer_tax_n,
                .First_seller_eu = first_seller_eu,
                .Product_items1 = product_items1,
                .Product_items2 = product_items2,
                .Product_price = product_price,
                .Invoice_net = invoice_net,
                .Invoice_currency = invoice_currency,
                .Ui_type = ui_type,
                .UpUIs = upUIs,
                .AUIs = aUIs,
                .Comment = comment,
                .RecallCode = recallCode
            }
        Return output
    End Function
    Shared Function EIV(json As String) As EIVStruct
        Dim j As JObject = JObject.Parse(json)
        Return EIV(j)
    End Function

    ''' <summary>
    ''' Receipt of the payment
    ''' </summary>
    ''' <returns></returns>
    Shared Function EPR(json As JObject) As EPRStruct
        Dim EO_ID As String = json("EO_ID")
        Dim eventTime As Date = DateTime.ParseExact(json("Event_Time"), TimeFormat, Nothing)
        Dim payment_date As Date = DateTime.ParseExact(json("Payment_Date"), DateFormat, Nothing)
        Dim payment_type As Integer = Convert.ToInt32(json("Payment_Type"))
        Dim payment_amount As Double = Convert.ToDouble(json("Payment_Amount"))
        Dim payment_currency As String = json("Payment_Currency")
        Dim payment_payer1 As Integer = Convert.ToInt32(json("Payment_Payer1"))
        Dim payment_payer2 As String = json("Payment_Payer2")
        Dim payer_name As String = json("Payer_Name")
        Dim payer_address As String = json("Payer_Address")
        Dim payer_countryreg As String = json("Payer_CountryReg")
        Dim payer_tax_n As String = json("Payer_TAX_N")
        Dim payment_recipient As String = json("Payment_Recipient")
        Dim payment_invoice As Integer = Convert.ToInt32(json("Payment_Invoice"))
        Dim invoice_paid As String = json("Invoice_Paid")
        Dim ui_type As AggregationType = Convert.ToInt32(json("UI_Type"))
        Dim upUIs As String() = json.Item("upUIs").ToObject(Of String())
        Dim aUIs As String() = json.Item("aUIs").ToObject(Of String())
        Dim comment As String = json("Payment_comment")
        Dim recallCode As String = json("Code")

        'Put variables into structure
        Dim output As New EPRStruct With
            {
                .EO_ID = EO_ID,
                .EventTime = eventTime,
                .Payment_date = payment_date,
                .Payment_type = payment_type,
                .Payment_amount = payment_amount,
                .Payment_currency = payment_currency,
                .Payment_payer1 = payment_payer1,
                .Payment_payer2 = payment_payer2,
                .Payer_name = payer_name,
                .Payer_address = payer_address,
                .Payer_countryreg = payer_countryreg,
                .Payer_tax_n = payer_tax_n,
                .Payment_recipient = payment_recipient,
                .Payment_invoice = payment_invoice,
                .Invoice_paid = invoice_paid,
                .Ui_type = ui_type,
                .UpUIs = upUIs,
                .AUIs = aUIs,
                .Comment = comment,
                .RecallCode = recallCode
            }
        Return output
    End Function
    Shared Function EPR(json As String) As EPRStruct
        Dim j As JObject = JObject.Parse(json)
        Return EPR(j)
    End Function

    ''' <summary>
    ''' Issuing of the order number
    ''' </summary>
    ''' <returns></returns>
    Shared Function EPO(json As JObject) As EPOStruct
        Dim EO_ID As String = json("EO_ID")
        Dim eventTime As Date = DateTime.ParseExact(json("Event_Time"), TimeFormat, Nothing)
        Dim order_number As Integer = Convert.ToInt32(json("Order_Number"))
        Dim order_date As Date = DateTime.ParseExact(json("Order_Date"), DateFormat, Nothing)
        Dim ui_type As AggregationType = Convert.ToInt32(json("UI_Type"))
        Dim upUIs As String() = json.Item("upUIs").ToObject(Of String())
        Dim aUIs As String() = json.Item("aUIs").ToObject(Of String())
        Dim comment As String = json("Comments")
        Dim recallCode As String = json("Code")

        'Put variables into structure
        Dim output As New EPOStruct With
            {
                .EO_ID = EO_ID,
                .EventTime = eventTime,
                .Order_Number = order_number,
                .Order_Date = order_date,
                .Ui_type = ui_type,
                .UpUIs = upUIs,
                .AUIs = aUIs,
                .Comment = comment,
                .RecallCode = recallCode
            }
        Return output
    End Function
    Shared Function EPO(json As String) As EPOStruct
        Dim j As JObject = JObject.Parse(json)
        Return EPO(j)
    End Function

    ''' <summary>
    ''' Recalls of requests, operational and transactional messages
    ''' </summary>
    ''' <returns></returns>
    Shared Function RCL(json As JObject) As RCLStruct
        Dim EO_ID As String = json("EO_ID")
        Dim recall_code As String = json("Recall_CODE")
        Dim recall_reason1 As RecallReasonType = Convert.ToInt32(json("Recall_Reason1"))
        Dim recall_reason2 As String = json("Recall_Reason2")
        Dim comment As String = json("Recall_Reason3")
        Dim recallCode As String = json("Code")

        'Put variables into structure
        Dim output As New RCLStruct With
            {
                .EO_ID = EO_ID,
                .TargetCode = recall_code,
                .Recall_reason1 = recall_reason1,
                .Recall_reason2 = recall_reason2,
                .Comment = comment,
                .RecallCode = recallCode
            }
        Return output
    End Function
    Shared Function RCL(json As String) As RCLStruct
        Dim j As JObject = JObject.Parse(json)
        Return RCL(j)
    End Function
#End Region

#Region "Custom"
    Public Function STA(json As JObject) As String
        Dim jObj As JObject = JObject.Parse(json)
        Throw New NotImplementedException()
    End Function
#End Region
End Class

#Region "Enums"
Public Enum AggregationType
    Unit_Packets_Only = 1
    Aggregated_Only = 2
    Both = 3
End Enum

Public Enum DestinationType
    Non_EU_dest = 1
    EU_Dest_Other_Than_VM_Fixed_Quantity = 2
    EU_VMs = 3
    Eu_Dest_Other_Than_VM_VV_Delivery = 4
End Enum

Public Enum DeactivationType
    Product_destroyed = 1
    Product_stolen = 2
    UI_destroyed = 3
    UI_stolen = 4
    UI_unused = 5
    Other = 6
End Enum

Public Enum InvoiceType
    Original = 1
    Correction = 2
    Other = 3
End Enum

Public Enum RecallReasonType
    Reported_Event_did_Not_materialise
    Message_contained_erroneous_information
    Other
End Enum

Public Enum TransportMode
    Other = 0
    Sea_Transport = 1
    Rail_transport = 2
    Road_transport = 3
    Air_transport = 4
    Postal_consignment = 5
    Fixed_transport_installations = 6
    Inland_waterway_transport = 7
End Enum
#End Region

#Region "Structures"
Public Structure EUAStruct
    Public Property EO_ID As String
    Public Property F_ID As String
    Public Property EventTime As Date
    Public Property UpUI_1 As String()
    Public Property UpUI_2 As String()
    Public Property Comment As String
    Public Property RecallCode As String
End Structure

Public Structure EPAStruct
    Public Property EO_ID As String
    Public Property F_ID As String
    Public Property EventTime As Date
    Public Property AUI As String
    Public Property AggregationType As AggregationType
    Public Property Aggregated_UIs1 As String()
    Public Property Aggregated_UIs2 As String()
    Public Property Comment As String
    Public Property RecallCode As String
End Structure

Public Structure EDPStruct
    Public Property EO_ID As String
    Public Property F_ID As String
    Public Property EventTime As Date
    Public Property DestinationID1 As Integer
    Public Property DestinationID2 As String
    Public Property DestinationID3 As String()
    Public Property DestinationID4 As String()
    Public Property DestinationAddress As String
    Public Property Transport_mode As TransportMode
    Public Property TransportVehicle As String
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
    Public Property Ui_type As AggregationType
    Public Property UpUIs As String()
    Public Property AUIs As String()
    Public Property Comment As String
    Public Property RecallCode As String
End Structure

Public Structure ERPStruct
    Public Property EO_ID As String
    Public Property F_ID As String
    Public Property EventTime As Date
    Public Property Product_Return As Integer
    Public Property Ui_type As AggregationType
    Public Property UpUIs As String()
    Public Property AUIs As String()
    Public Property Comment As String
    Public Property RecallCode As String
End Structure

Public Structure ETLStruct
    Public Property EO_ID As String
    Public Property EventTime As Date
    Public Property DestinationID1 As Integer
    Public Property DestinationID2 As String
    Public Property DestinationAddress As String
    Public Property Transport_mode As TransportMode
    Public Property TransportVehicle As String
    Public Property Transport_cont1 As Integer
    Public Property Transport_cont2 As String
    Public Property EMCS As Integer
    Public Property EMCS_ARC As String
    Public Property Ui_type As AggregationType
    Public Property UpUIs As String()
    Public Property AUIs As String()
    Public Property Comment As String
    Public Property RecallCode As String
End Structure

Public Structure EUDStruct
    Public Property EO_ID As String
    Public Property F_ID As String
    Public Property EventTime As Date
    Public Property AUI As String
    Public Property Comment As String
    Public Property RecallCode As String
End Structure

Public Structure EVRStruct
    Public Property EO_ID As String
    Public Property F_ID As String
    Public Property EventTime As Date
    Public Property Ui_type As AggregationType
    Public Property UpUIs As String()
    Public Property AUIs As String()
    Public Property Comment As String
    Public Property RecallCode As String
End Structure

Public Structure IDAStruct
    Public Property EO_ID As String
    Public Property EventTime As Date
    Public Property Deact_Reason1 As DeactivationType
    Public Property Deact_Reason2 As String
    Public Property Deact_Reason3 As String
    Public Property Deact_Type As AggregationType
    Public Property Deact_upUI As String()
    Public Property Deact_aUI As String()
    Public Property RecallCode As String
End Structure

Public Structure EIVStruct
    Public Property EO_ID As String
    Public Property EventTime As Date
    Public Property Invoice_type1 As InvoiceType
    Public Property Invoice_type2 As String
    Public Property Invoice_number As String
    Public Property Invoice_date As Date
    Public Property Invoice_seller As String
    Public Property Invoice_buyer1 As Integer
    Public Property Invoice_buyer2 As String
    Public Property Buyer_name As String
    Public Property Buyer_countryreg As String
    Public Property Buyer_address As String
    Public Property Buyer_tax_n As String
    Public Property First_seller_eu As Integer
    Public Property Product_items1 As String()
    Public Property Product_items2 As Integer()
    Public Property Product_price As Decimal()
    Public Property Invoice_net As String
    Public Property Invoice_currency As String
    Public Property Ui_type As AggregationType
    Public Property UpUIs As String()
    Public Property AUIs As String()
    Public Property Comment As String
    Public Property RecallCode As String
End Structure

Public Structure EPRStruct
    Public Property EO_ID As String
    Public Property EventTime As Date
    Public Property Payment_date As Date
    Public Property Payment_type As Integer
    Public Property Payment_amount As Double
    Public Property Payment_currency As String
    Public Property Payment_payer1 As Integer
    Public Property Payment_payer2 As String
    Public Property Payer_name As String
    Public Property Payer_address As String
    Public Property Payer_countryreg As String
    Public Property Payer_tax_n As String
    Public Property Payment_recipient As String
    Public Property Payment_invoice As Integer
    Public Property Invoice_paid As String
    Public Property Ui_type As AggregationType
    Public Property UpUIs As String()
    Public Property AUIs As String()
    Public Property Comment As String
    Public Property RecallCode As String
End Structure

Public Structure EPOStruct
    Public Property EO_ID As String
    Public Property EventTime As Date
    Public Property Order_Number As Integer
    Public Property Order_Date As Date
    Public Property Ui_type As AggregationType
    Public Property UpUIs As String()
    Public Property AUIs As String()
    Public Property Comment As String
    Public Property RecallCode As String
End Structure

Public Structure RCLStruct
    Public Property EO_ID As String
    Public Property TargetCode As String
    Public Property Recall_reason1 As RecallReasonType
    Public Property Recall_reason2 As String
    Public Property Comment As String
    Public Property RecallCode As String
End Structure

Public Structure IRUStruct
    Public Property EO_ID As String
    Public Property F_ID As String
    Public Property EventTime As Date
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
    Public Property UpUIs As String()
    Public Property RecallCode As String
End Structure
#End Region
