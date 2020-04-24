Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class JsonUnpackager
    Private Sub New()
    End Sub

    Shared Function Unpack(json As JObject) As Message
        Dim type As String = json("Message_Type")
        Select Case type.ToUpper()
            Case "EDP"
                Return EDP(json)
            Case "EIV"
                Return EIV(json)
            Case "EPA"
                Return EPA(json)
            Case "EPO"
                Return EPO(json)
            Case "EPR"
                Return EPR(json)
            Case "ERP"
                Return ERP(json)
            Case "ETL"
                Return ETL(json)
            Case "EUA"
                Return EUA(json)
            Case "EUD"
                Return EUD(json)
            Case "EVR"
                Return EVR(json)
            Case "IDA"
                Return IDA(json)
            Case "IRU"
                Return IRU(json)
            Case "RCL"
                Return RCL(json)
            Case Else
                Throw New NotImplementedException($"JSON with recallCode: '{json("Code")}' failed to process. Type: {type} not implemented.")
        End Select
    End Function

#Region "Operationals"
    ''' <summary>
    ''' Application of unit level UIs on unit packets event
    ''' </summary>
    ''' <returns></returns>
    Shared Function EUA(json As JObject) As EUA

        ''Get variables
        'Dim EO_ID As String = json("EO_ID")
        'Dim F_ID As String = json("F_ID")
        'Dim eventTime As Date = DateTime.ParseExact(json("Event_Time"), TimeFormat, Nothing)
        'Dim upUI_1 As String() = json.Item("upUI_1").ToObject(Of String())
        'Dim upUI_2 As String() = json.Item("upUI_2").ToObject(Of String())
        'Dim comment As String = json("upUI_comment")
        'Dim recallCode As String = json("Code")

        ''Put variables into structure
        'Dim output As New EUA() With
        '{
        '    .EO_ID = EO_ID,
        '    .F_ID = F_ID,
        '    .Event_Time = eventTime,
        '    .upUI_1 = upUI_1,
        '    .upUI_2 = upUI_2,
        '    .upUI_comment = comment,
        '    .Code = recallCode
        '}
        Return EUA(json.ToString())
    End Function
    Shared Function EUA(json As String) As EUA
        'Dim j As JObject = JObject.Parse(json)
        Return JsonConvert.DeserializeObject(Of EUA)(json)
    End Function

    ''' <summary>
    ''' Message to report an aggregation event
    ''' </summary>
    ''' <returns></returns>
    Shared Function EPA(json As JObject) As EPA
        ''Get variables
        'Dim EO_ID As String = json("EO_ID")
        'Dim F_ID As String = json("F_ID")
        'Dim eventTime As Date = DateTime.ParseExact(json("Event_Time"), TimeFormat, Nothing)
        'Dim aUI As String = json("aUI")
        'Dim aggregationType As AggregationType = Convert.ToInt32(json("Aggregation_Type"))
        'Dim aggregatedUIs1 As String() = json.Item("Aggregated_UIs1").ToObject(Of String())
        'Dim aggregatedUIs2 As String() = json.Item("Aggregated_UIs2").ToObject(Of String())
        'Dim comment As String = json("aUI_comment")
        'Dim recallCode As String = json("Code")

        ''Put variables into structure
        'Dim output As New EPA() With
        '{
        '    .EO_ID = EO_ID,
        '    .F_ID = F_ID,
        '    .Event_Time = eventTime,
        '    .Aggregation_Type = aggregationType,
        '    .Aggregated_UIs1 = aggregatedUIs1,
        '    .Aggregated_UIs2 = aggregatedUIs2,
        '    .aUI = aUI,
        '    .aUI_comment = comment,
        '    .Code = recallCode
        '}
        Return EPA(json.ToString())
    End Function
    Shared Function EPA(json As String) As EPA
        'Dim j As JObject = JObject.Parse(json)
        Return JsonConvert.DeserializeObject(Of EPA)(json)
    End Function

    ''' <summary>
    '''  Message to report a dispatch event
    ''' </summary>
    ''' <returns></returns>
    Shared Function EDP(json As JObject) As EDP
        'Dim EO_ID As String = json("EO_ID")
        'Dim F_ID As String = json("F_ID")
        'Dim eventTime As Date = DateTime.ParseExact(json("Event_Time"), TimeFormat, Nothing)
        'Dim destinationID1 As Integer = Convert.ToInt32(json("Destination_ID1"))
        'Dim destinationID2 As String = json("Destination_ID2")
        'Dim destinationID3 As String() = json.Item("Destination_ID3").ToObject(Of String())
        'Dim destinationID4 As String() = json.Item("Destination_ID4").ToObject(Of String())
        'Dim destinationAddress As String = json("Destination_ID5")
        'Dim transport_mode As TransportMode = Convert.ToInt32(json("Transport_mode"))
        'Dim transportVehicle As String = json("Transport_vehicle")
        'Dim transport_cont1 As Integer = Convert.ToInt32(json("Transport_cont1"))
        'Dim transport_cont2 As String = json("Transport_cont2")
        'Dim transport_s1 As Integer = Convert.ToInt32(json("Transport_s1"))
        'Dim transport_s2 As String = json("Transport_s2")
        'Dim EMCS As Integer = Convert.ToInt32(json("EMCS"))
        'Dim EMCS_ARC As String = json("EMCS_ARC")
        'Dim SAAD As Integer = Convert.ToInt32(json("SAAD"))
        'Dim SAAD_number As String = json("SAAD_number")
        'Dim Exp_Declaration As Integer = Convert.ToInt32(json("Exp_Declaration"))
        'Dim Exp_DeclarationNumber As String = json("Exp_DeclarationNumber")
        'Dim ui_type As AggregationType = Convert.ToInt32(json("UI_Type"))
        'Dim upUIs As String() = json.Item("upUIs").ToObject(Of String())
        'Dim aUIs As String() = json.Item("aUIs").ToObject(Of String())
        'Dim comment As String = json("Dispatch_comment")
        'Dim recallCode As String = json("Code")

        ''Put variables into structure
        'Dim output As New EDP() With
        '    {
        '        .EO_ID = EO_ID,
        '        .F_ID = F_ID,
        '        .Event_Time = eventTime,
        '        .Destination_ID1 = destinationID1,
        '        .Destination_ID2 = destinationID2,
        '        .Destination_ID3 = destinationID3,
        '        .Destination_ID4 = destinationID4,
        '        .Destination_ID5 = destinationAddress,
        '        .Transport_mode = transport_mode,
        '        .Transport_vehicle = transportVehicle,
        '        .Transport_cont1 = transport_cont1,
        '        .Transport_cont2 = transport_cont2,
        '        .Transport_s1 = transport_s1,
        '        .Transport_s2 = transport_s2,
        '        .EMCS = EMCS,
        '        .EMCS_ARC = EMCS_ARC,
        '        .SAAD = SAAD,
        '        .SAAD_number = SAAD_number,
        '        .Exp_Declaration = Exp_Declaration,
        '        .Exp_DeclarationNumber = Exp_DeclarationNumber,
        '        .UI_Type = ui_type,
        '        .upUIs = upUIs,
        '        .aUIs = aUIs,
        '        .Dispatch_comment = comment,
        '        .Code = recallCode
        '    }
        Return EDP(json.ToString())
    End Function
    Shared Function EDP(json As String) As EDP
        'Dim j As JObject = JObject.Parse(json)
        Return JsonConvert.DeserializeObject(Of EDP)(json)
    End Function

    ''' <summary>
    ''' Message to report a reception event
    ''' </summary>
    ''' <returns></returns>
    Shared Function ERP(json As JObject) As ERP
        'Dim EO_ID As String = json("EO_ID")
        'Dim F_ID As String = json("F_ID")
        'Dim eventTime As Date = DateTime.ParseExact(json("Event_Time"), TimeFormat, Nothing)
        'Dim product_return As Integer = Convert.ToInt32(json("Product_Return"))
        'Dim ui_type As AggregationType = Convert.ToInt32(json("UI_Type"))
        'Dim upUIs As String() = json.Item("upUIs").ToObject(Of String())
        'Dim aUIs As String() = json.Item("aUIs").ToObject(Of String())
        'Dim comment As String = json("Arrival_comment")
        'Dim recallCode As String = json("Code")

        ''Put variables into structure
        'Dim output As New ERP() With
        '{
        '    .EO_ID = EO_ID,
        '    .F_ID = F_ID,
        '    .Event_Time = eventTime,
        '    .Product_Return = product_return,
        '    .UI_Type = ui_type,
        '    .upUIs = upUIs,
        '    .aUIs = aUIs,
        '    .Arrival_comment = comment,
        '    .Code = recallCode
        '}
        Return ERP(json.ToString())
    End Function
    Shared Function ERP(json As String) As ERP
        'Dim j As JObject = JObject.Parse(json)
        Return JsonConvert.DeserializeObject(Of ERP)(json)
    End Function

    ''' <summary>
    ''' Message to report a trans-loading event
    ''' </summary>
    ''' <returns></returns>
    Shared Function ETL(json As JObject) As ETL
        'Dim EO_ID As String = json("EO_ID")
        'Dim eventTime As Date = DateTime.ParseExact(json("Event_Time"), TimeFormat, Nothing)
        'Dim destinationID1 As Integer = Convert.ToInt32(json("Destination_ID1"))
        'Dim destinationID2 As String = json("Destination_ID2")
        'Dim destinationAddress As String = json("Destination_ID3")
        'Dim transport_mode As TransportMode = Convert.ToInt32(json("Transport_mode"))
        'Dim transportVehicle As String = json("Transport_vehicle")
        'Dim transport_cont1 As Integer = Convert.ToInt32(json("Transport_cont1"))
        'Dim transport_cont2 As String = json("Transport_cont2")
        'Dim EMCS As Integer = Convert.ToInt32(json("EMCS"))
        'Dim EMCS_ARC As String = json("EMCS_ARC")
        'Dim ui_type As AggregationType = Convert.ToInt32(json("UI_Type"))
        'Dim upUIs As String() = json.Item("upUIs").ToObject(Of String())
        'Dim aUIs As String() = json.Item("aUIs").ToObject(Of String())
        'Dim comment As String = json("Transloading_comment")
        'Dim recallCode As String = json("Code")

        ''Put variables into structure
        'Dim output As New ETL() With
        '    {
        '        .EO_ID = EO_ID,
        '        .Event_Time = eventTime,
        '        .Destination_ID1 = destinationID1,
        '        .Destination_ID2 = destinationID2,
        '        .Destination_ID3 = destinationAddress,
        '        .Transport_mode = transport_mode,
        '        .Transport_vehicle = transportVehicle,
        '        .Transport_cont1 = transport_cont1,
        '        .Transport_cont2 = transport_cont2,
        '        .EMCS = EMCS,
        '        .EMCS_ARC = EMCS_ARC,
        '        .UI_Type = ui_type,
        '        .upUIs = upUIs,
        '        .aUIs = aUIs,
        '        .Transloading_comment = comment,
        '        .Code = recallCode
        '    }
        Return ETL(json.ToString())
    End Function
    Shared Function ETL(json As String) As ETL
        'Dim j As JObject = JObject.Parse(json)
        Return JsonConvert.DeserializeObject(Of ETL)(json)
    End Function

    ''' <summary>
    ''' Message to report an UID disaggregation
    ''' </summary>
    ''' <returns></returns>
    Shared Function EUD(json As JObject) As EUD
        'Dim EO_ID As String = json("EO_ID")
        'Dim F_ID As String = json("F_ID")
        'Dim eventTime As Date = DateTime.ParseExact(json("Event_Time"), TimeFormat, Nothing)
        'Dim aUI As String = json("aUI")
        'Dim comment As String = json("disaUI_Comment")
        'Dim recallCode As String = json("Code")

        ''Put variables into structure
        'Dim output As New EUD() With
        '    {
        '        .EO_ID = EO_ID,
        '        .F_ID = F_ID,
        '        .Event_Time = eventTime,
        '        .aUI = aUI,
        '        .disaUI_Comment = comment,
        '        .Code = recallCode
        '    }
        Return EUD(json.ToString())
    End Function
    Shared Function EUD(json As String) As EUD
        'Dim j As JObject = JObject.Parse(json)
        Return JsonConvert.DeserializeObject(Of EUD)(json)
    End Function

    ''' <summary>
    ''' Message to report the delivery carried out with a vending van to retail outlet
    ''' </summary>
    ''' <returns></returns>
    Shared Function EVR(json As JObject) As EVR
        'Dim EO_ID As String = json("EO_ID")
        'Dim F_ID As String = json("F_ID")
        'Dim eventTime As Date = DateTime.ParseExact(json("Event_Time"), TimeFormat, Nothing)
        'Dim ui_type As AggregationType = Convert.ToInt32(json("UI_Type"))
        'Dim upUIs As String() = json.Item("upUIs").ToObject(Of String())
        'Dim aUIs As String() = json.Item("aUIs").ToObject(Of String())
        'Dim comment As String = json("Delivery_comment")
        'Dim recallCode As String = json("Code")

        ''Put variables into structure
        'Dim output As New EVR() With
        '    {
        '        .EO_ID = EO_ID,
        '        .F_ID = F_ID,
        '        .Event_Time = eventTime,
        '        .UI_Type = ui_type,
        '        .upUIs = upUIs,
        '        .aUIs = aUIs,
        '        .Delivery_comment = comment,
        '        .Code = recallCode
        '    }
        Return EVR(json.ToString())
    End Function
    Shared Function EVR(json As String) As EVR
        'Dim j As JObject = JObject.Parse(json)
        Return JsonConvert.DeserializeObject(Of EVR)(json)
    End Function

    ''' <summary>
    ''' Message to request a UID deactivation
    ''' </summary>
    ''' <returns></returns>
    Shared Function IDA(json As JObject) As IDA
        'Dim EO_ID As String = json("EO_ID")
        'Dim eventTime As Date = DateTime.ParseExact(json("Event_Time"), TimeFormat, Nothing)
        'Dim deact_reason1 As DeactivationType = Convert.ToInt32(json("Deact_Reason1"))
        'Dim deact_reason2 As String = json("Deact_Reason2")
        'Dim deact_reason3 As String = json("Deact_Reason3")
        'Dim deact_type As AggregationType = Convert.ToInt32(json("Deact_Type"))
        'Dim upUIs As String() = json.Item("Deact_upUI").ToObject(Of String())
        'Dim aUIs As String() = json.Item("Deact_aUI").ToObject(Of String())
        'Dim recallCode As String = json("Code")

        ''Put variables into structure
        'Dim output As New IDA() With
        '    {
        '        .EO_ID = EO_ID,
        '        .Event_Time = eventTime,
        '        .Deact_Reason1 = deact_reason1,
        '        .Deact_Reason2 = deact_reason2,
        '        .Deact_Reason3 = deact_reason3,
        '        .Deact_Type = deact_type,
        '        .Deact_upUI = upUIs,
        '        .Deact_aUI = aUIs,
        '        .Code = recallCode
        '    }
        Return IDA(json.ToString())
    End Function
    Shared Function IDA(json As String) As IDA
        'Dim j As JObject = JObject.Parse(json)
        Return JsonConvert.DeserializeObject(Of IDA)(json)
    End Function

    Shared Function IRU(json As JObject) As IRU
        'Dim EO_ID As String = json("EO_ID")
        'Dim F_ID As String = json("F_ID")
        'Dim eventTime As Date = DateTime.ParseExact(json("Event_Time"), TimeFormat, Nothing)
        'Dim Process_Type As Integer = Convert.ToInt32(json("Process_Type"))
        'Dim M_ID As String = json("M_ID")
        'Dim P_Type As String = Convert.ToInt32(json("P_Type"))
        'Dim P_OtherType As String = json("P_OtherType")
        'Dim P_CN As String = json("P_CN")
        'Dim P_Brand As String = json("P_Brand")
        'Dim TP_ID As String = json("TP_ID")
        'Dim TP_PN As String = json("TP_PN")
        'Dim Intended_Market As String = json("Intended_Market")
        'Dim Intended_Route1 As Integer = Convert.ToInt32(json("Intended_Route1"))
        'Dim Intended_Route2 As String = json("Intended_Route2")
        'Dim Import As Integer = Convert.ToInt32(json("Import"))
        'Dim Req_Quantity As Integer = Convert.ToInt32(json("Req_Quantity"))
        'Dim P_OtherID As String = json("P_OtherID")
        'Dim upUIs As String() = json("upUI").ToObject(Of String())
        'Dim recallCode As String = json("Code")

        'Dim output As New IRU() With
        '    {
        '        .EO_ID = EO_ID,
        '        .F_ID = F_ID,
        '        .Event_Time = eventTime,
        '        .Process_Type = Process_Type,
        '        .M_ID = M_ID,
        '        .P_Type = P_Type,
        '        .P_OtherType = P_OtherType,
        '        .P_CN = P_CN,
        '        .P_Brand = P_Brand,
        '        .TP_ID = TP_ID,
        '        .TP_PN = TP_PN,
        '        .Intended_Market = Intended_Market,
        '        .Intended_Route1 = Intended_Route1,
        '        .Intended_Route2 = Intended_Route2,
        '        .Import = Import,
        '        .Req_Quantity = Req_Quantity,
        '        .P_OtherID = P_OtherID,
        '        .upUI = upUIs,
        '        .Code = recallCode
        '    }
        Return IRU(json.ToString())
    End Function
    Shared Function IRU(json As String) As IRU
        'Dim j As JObject = JObject.Parse(json)
        Return JsonConvert.DeserializeObject(Of IRU)(json)
    End Function
#End Region
#Region "Transactionals"
    ''' <summary>
    ''' Message to report an invoice
    ''' </summary>
    ''' <returns></returns>
    Shared Function EIV(json As JObject) As EIV
        'Dim EO_ID As String = json("EO_ID")
        'Dim eventTime As Date = DateTime.ParseExact(json("Event_Time"), TimeFormat, Nothing)
        'Dim invoice_type1 As InvoiceType = Convert.ToInt32(json("Invoice_Type1"))
        'Dim invoice_type2 As String = json("Invoice_Type2")
        'Dim invoice_number As String = json("Invoice_Number")
        'Dim invoice_date As Date = DateTime.ParseExact(json("Invoice_Date"), DateFormat, Nothing)
        'Dim invoice_seller As String = json("Invoice_Seller")
        'Dim invoice_buyer1 As Integer = Convert.ToInt32(json("Invoice_Buyer1"))
        'Dim invoice_buyer2 As String = json("Invoice_Buyer2")
        'Dim buyer_name As String = json("Buyer_Name")
        'Dim buyer_countryreg As String = json("Buyer_CountryReg")
        'Dim buyer_address As String = json("Buyer_Address")
        'Dim buyer_tax_n As String = json("Buyer_TAX_N")
        'Dim first_seller_eu As Integer = Convert.ToInt32(json("First_Seller_EU"))
        'Dim product_items1 As String() = json.Item("Product_Items_1").ToObject(Of String())
        'Dim product_items2 As Integer() = json.Item("Product_Items_2").ToObject(Of Integer())
        'Dim product_price As Decimal() = json.Item("Product_Price").ToObject(Of Decimal())
        'Dim invoice_net As String = json("Invoice_Net")
        'Dim invoice_currency As String = json("Invoice_Currency")
        'Dim ui_type As AggregationType = Convert.ToInt32(json("UI_Type"))
        'Dim upUIs As String() = json.Item("upUIs").ToObject(Of String())
        'Dim aUIs As String() = json.Item("aUIs").ToObject(Of String())
        'Dim comment As String = json("Invoice_comment")
        'Dim recallCode As String = json("Code")

        ''Put variables into structure
        'Dim output As New EIV() With
        '    {
        '        .EO_ID = EO_ID,
        '        .Event_Time = eventTime,
        '        .Invoice_Type1 = invoice_type1,
        '        .Invoice_Type2 = invoice_type2,
        '        .Invoice_Number = invoice_number,
        '        .Invoice_Date = invoice_date,
        '        .Invoice_Seller = invoice_seller,
        '        .Invoice_Buyer1 = invoice_buyer1,
        '        .Invoice_Buyer2 = invoice_buyer2,
        '        .Buyer_Name = buyer_name,
        '        .Buyer_CountryReg = buyer_countryreg,
        '        .Buyer_Address = buyer_address,
        '        .Buyer_TAX_N = buyer_tax_n,
        '        .First_Seller_EU = first_seller_eu,
        '        .Product_Items_1 = product_items1,
        '        .Product_Items_2 = product_items2,
        '        .Product_Price = product_price,
        '        .Invoice_Net = invoice_net,
        '        .Invoice_Currency = invoice_currency,
        '        .UI_Type = ui_type,
        '        .upUIs = upUIs,
        '        .aUIs = aUIs,
        '        .Invoice_comment = comment,
        '        .Code = recallCode
        '    }
        Return EIV(json.ToString())
    End Function
    Shared Function EIV(json As String) As EIV
        'Dim j As JObject = JObject.Parse(json)
        Return JsonConvert.DeserializeObject(Of EIV)(json)
    End Function

    ''' <summary>
    ''' Receipt of the payment
    ''' </summary>
    ''' <returns></returns>
    Shared Function EPR(json As JObject) As EPR
        'Dim EO_ID As String = json("EO_ID")
        'Dim eventTime As Date = DateTime.ParseExact(json("Event_Time"), TimeFormat, Nothing)
        'Dim payment_date As Date = DateTime.ParseExact(json("Payment_Date"), DateFormat, Nothing)
        'Dim payment_type As Integer = Convert.ToInt32(json("Payment_Type"))
        'Dim payment_amount As Double = Convert.ToDouble(json("Payment_Amount"))
        'Dim payment_currency As String = json("Payment_Currency")
        'Dim payment_payer1 As Integer = Convert.ToInt32(json("Payment_Payer1"))
        'Dim payment_payer2 As String = json("Payment_Payer2")
        'Dim payer_name As String = json("Payer_Name")
        'Dim payer_address As String = json("Payer_Address")
        'Dim payer_countryreg As String = json("Payer_CountryReg")
        'Dim payer_tax_n As String = json("Payer_TAX_N")
        'Dim payment_recipient As String = json("Payment_Recipient")
        'Dim payment_invoice As Integer = Convert.ToInt32(json("Payment_Invoice"))
        'Dim invoice_paid As String = json("Invoice_Paid")
        'Dim ui_type As AggregationType = Convert.ToInt32(json("UI_Type"))
        'Dim upUIs As String() = json.Item("upUIs").ToObject(Of String())
        'Dim aUIs As String() = json.Item("aUIs").ToObject(Of String())
        'Dim comment As String = json("Payment_comment")
        'Dim recallCode As String = json("Code")

        ''Put variables into structure
        'Dim output As New EPR() With
        '    {
        '        .EO_ID = EO_ID,
        '        .Event_Time = eventTime,
        '        .Payment_Date = payment_date,
        '        .Payment_Type = payment_type,
        '        .Payment_Amount = payment_amount,
        '        .Payment_Currency = payment_currency,
        '        .Payment_Payer1 = payment_payer1,
        '        .Payment_Payer2 = payment_payer2,
        '        .Payer_Name = payer_name,
        '        .Payer_Address = payer_address,
        '        .Payer_CountryReg = payer_countryreg,
        '        .Payer_TAX_N = payer_tax_n,
        '        .Payment_Recipient = payment_recipient,
        '        .Payment_Invoice = payment_invoice,
        '        .Invoice_Paid = invoice_paid,
        '        .UI_Type = ui_type,
        '        .upUIs = upUIs,
        '        .aUIs = aUIs,
        '        .Payment_comment = comment,
        '        .Code = recallCode
        '    }
        Return EPR(json.ToString())
    End Function
    Shared Function EPR(json As String) As EPR
        'Dim j As JObject = JObject.Parse(json)
        Return JsonConvert.DeserializeObject(Of EPR)(json)
    End Function

    ''' <summary>
    ''' Issuing of the order number
    ''' </summary>
    ''' <returns></returns>
    Shared Function EPO(json As JObject) As EPO
        'Dim EO_ID As String = json("EO_ID")
        'Dim eventTime As Date = DateTime.ParseExact(json("Event_Time"), TimeFormat, Nothing)
        'Dim order_number As Integer = Convert.ToInt32(json("Order_Number"))
        'Dim order_date As Date = DateTime.ParseExact(json("Order_Date"), DateFormat, Nothing)
        'Dim ui_type As AggregationType = Convert.ToInt32(json("UI_Type"))
        'Dim upUIs As String() = json.Item("upUIs").ToObject(Of String())
        'Dim aUIs As String() = json.Item("aUIs").ToObject(Of String())
        'Dim comment As String = json("Comments")
        'Dim recallCode As String = json("Code")

        ''Put variables into structure
        'Dim output As New EPO() With
        '    {
        '        .EO_ID = EO_ID,
        '        .Event_Time = eventTime,
        '        .Order_Number = order_number,
        '        .Order_Date = order_date,
        '        .UI_Type = ui_type,
        '        .upUIs = upUIs,
        '        .aUIs = aUIs,
        '        .Comments = comment,
        '        .Code = recallCode
        '    }
        Return EPO(json.ToString())
    End Function
    Shared Function EPO(json As String) As EPO
        'Dim j As JObject = JObject.Parse(json)
        Return JsonConvert.DeserializeObject(Of EPO)(json)
    End Function

    ''' <summary>
    ''' Recalls of requests, operational and transactional messages
    ''' </summary>
    ''' <returns></returns>
    Shared Function RCL(json As JObject) As RCL
        'Dim EO_ID As String = json("EO_ID")
        'Dim recall_code As String = json("Recall_CODE")
        'Dim recall_reason1 As RecallReasonType = Convert.ToInt32(json("Recall_Reason1"))
        'Dim recall_reason2 As String = json("Recall_Reason2")
        'Dim comment As String = json("Recall_Reason3")
        'Dim recallCode As String = json("Code")

        ''Put variables into structure
        'Dim output As New RCL() With
        '    {
        '        .EO_ID = EO_ID,
        '        .Recall_CODE = recall_code,
        '        .Recall_Reason1 = recall_reason1,
        '        .Recall_Reason2 = recall_reason2,
        '        .Recall_Reason3 = comment,
        '        .Code = recallCode
        '    }
        Return RCL(json.ToString())
    End Function
    Shared Function RCL(json As String) As RCL
        'Dim j As JObject = JObject.Parse(json)
        Return JsonConvert.DeserializeObject(Of RCL)(json)
    End Function
#End Region

#Region "Custom"
    Public Function STA(json As JObject) As String
        Dim jObj As JObject = JObject.Parse(json)
        Throw New NotImplementedException()
    End Function
#End Region
#Region "Helpers"
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

