Imports Newtonsoft.Json.Linq

Public Class EIV
    Inherits Message

    Public Property EO_ID As String
    Public Property Event_Time As String
    Public Property Invoice_Type1 As InvoiceType
    Public Property Invoice_Type2 As String
    Public Property Invoice_Number As String
    Public Property Invoice_Date As String
    Public Property Invoice_Seller As String
    Public Property Invoice_Buyer1 As Integer
    Public Property Invoice_Buyer2 As String
    Public Property Buyer_Name As String
    Public Property Buyer_CountryReg As String
    Public Property Buyer_Address As String
    Public Property Buyer_Address_StreetOne As String
    Public Property Buyer_Address_StreetTwo As String
    Public Property Buyer_Address_City As String
    Public Property Buyer_Address_PostCode As String
    Public Property Buyer_TAX_N As String
    Public Property First_Seller_EU As Integer
    Public Property Product_Items_1 As String()
    Public Property Product_Items_2 As Integer()
    Public Property Product_Price As Decimal()
    Public Property Invoice_Net As String
    Public Property Invoice_Currency As String
    Public Property UI_Type As AggregationType
    Public Property upUIs As String()
    Public Property aUIs As String()
    Public Property Invoice_comment As String

    Public Overrides Function GetSqlStatement() As String
        Dim output As String = ""
        output += $"INSERT INTO `{DBBase.DBName}`.`tblinvoices` "
        output += "(fldEvent_Time,fldEO_ID,fldType,fldOtherType,fldInvoiceNumber,fldDate,"
        output += "fldSellerID,fldEUBuyer,fldBuyerID,fldBuyer_Name,fldBuyer_Address,fldBuyerStreet1,fldBuyerStreet2,fldBuyerCity,fldDestPostCode,fldBuyer_CountryReg,fldBuyer_TAX_N,fldFirstSellerEU,"
        output += "fldProduct_Items_TPIDs,fldProduct_Items_N,fldProduct_Items_Price,fldValue,fldCurrency,fldComment,fldJsonID) "
        output += $"VALUES ('{JsonDatetime.ParseTime(Event_Time).ToMySQL()}','{EO_ID}','{CInt(Invoice_Type1)}','{Invoice_Type2}','{Invoice_Number}','{JsonDatetime.ParseDate(Invoice_Date).ToMySQL()}',"
        output += $"'{Invoice_Seller}','{Invoice_Buyer1}','{Invoice_Buyer2}','{Buyer_Name}','{Buyer_Address}','{Buyer_Address_StreetOne}','{Buyer_Address_StreetTwo}','{Buyer_Address_City}','{Buyer_Address_PostCode}','{Buyer_CountryReg}','{Buyer_TAX_N}','{First_Seller_EU}',"
        output += $"'{String.Join(",", If(Product_Items_1 Is Nothing, New String() {}, Product_Items_1))}','{String.Join(",", If(IsDBNull(Product_Items_2), New String() {}, Product_Items_2))}','{String.Join(",", If(IsDBNull(Product_Price), New String() {}, Product_Price))}','{Invoice_Net}','{Invoice_Currency}',"
        output += $"'{Invoice_comment}','{GetJsonIndex}'); "
        output = output.Replace("''", "null")
        'TODO Finish
        'Relate all UIs to the json
        Select Case UI_Type
            Case AggregationType.Unit_Packets_Only
                output += $"UPDATE `{DBBase.DBName}`.`tblprimarycodes` SET fldEIV = '{GetJsonIndex}' "
                output += $"WHERE fldPrintCode in ('{String.Join("','", upUIs)}');"
            Case AggregationType.Aggregated_Only
                output += $"UPDATE `{DBBase.DBName}`.`tblaggregatedcodes` SET fldEIV = '{GetJsonIndex}' "
                output += $"WHERE fldPrintCode in ('{String.Join("','", aUIs)}');"
            Case AggregationType.Both
                output += $"UPDATE `{DBBase.DBName}`.`tblprimarycodes` AS P, `{DBBase.DBName}`.`tblaggregatedcodes` AS A "
                output += $"SET P.fldEIV = '{GetJsonIndex}', A.fldEIV = '{GetJsonIndex}' "
                output += $"WHERE P.fldPrintCode in ('{String.Join("','", upUIs)}') "
                output += $"AND A.fldPrintCode in ('{String.Join("','", aUIs)}');"
            Case Else
                Throw New NotImplementedException($"Ui_type '{UI_Type}' does not exist.")
        End Select
        Return output
    End Function

    Public Overrides Function GetReport() As String
        Return $"{Message_Type} message unpacked. JSON ID: '{GetJsonIndex}'"
    End Function
End Class

