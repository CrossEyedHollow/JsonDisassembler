Imports Newtonsoft.Json.Linq

Public Class EPR
    Inherits Message

    Public Property EO_ID As String
    Public Property Event_Time As String
    Public Property Payment_Date As String
    Public Property Payment_Type As Integer
    Public Property Payment_Amount As Double
    Public Property Payment_Currency As String
    Public Property Payment_Payer1 As Integer
    Public Property Payment_Payer2 As String
    Public Property Payer_Name As String
    Public Property Payer_Address As String
    Public Property Payer_Address_StreetOne As String
    Public Property Payer_Address_StreetTwo As String
    Public Property Payer_Address_City As String
    Public Property Payer_Address_PostCode As String
    Public Property Payer_CountryReg As String
    Public Property Payer_TAX_N As String
    Public Property Payment_Recipient As String
    Public Property Payment_Invoice As Integer
    Public Property Invoice_Paid As String
    Public Property UI_Type As AggregationType
    Public Property upUIs As String()
    Public Property aUIs As String()
    Public Property Payment_comment As String

    Public Overrides Function GetSqlStatement() As String
        Dim output As String = ""
        output += $"INSERT INTO `{DBBase.DBName}`.`tblpayments` (fldEvent_Time,fldEO_ID,fldPaymentDate,fldPaymentType,fldPaymentAmount,"
        output += "fldCurrency,fldPaymentPayer1,fldPaymentPayer2,fldPayerName,fldPayerAddress,fldPayerStreet1,fldPayerStreet2,fldPayerCity,fldDestPostCode,fldPayerCoutryReg,fldPayer_TAX_N,"
        output += "fldPaymentRecipient,fldPaymentInvoice,fldInvoiceNumber,fldComment,fldJsonID) "
        output += $"VALUES ('{ParseTime(Event_Time).ToMySQL()}','{EO_ID}','{ParseDate(Payment_Date).ToMySQL()}',"
        output += $"'{Payment_Type}','{Payment_Amount}','{Payment_Currency}','{Payment_Payer1}','{Payment_Payer2}','{Payer_Name}',"
        output += $"'{Payer_Address}','{Payer_Address_StreetOne}','{Payer_Address_StreetTwo}','{Payer_Address_City}','{Payer_Address_PostCode}','{Payer_CountryReg}','{Payer_TAX_N}','{Payment_Recipient}','{Payment_Invoice}','{Invoice_Paid}',"
        output += $"'{Payment_comment}','{Code}');"
        output = output.Replace("''", "null")

        Select Case UI_Type
            Case AggregationType.Unit_Packets_Only
                output += $"UPDATE `{DBBase.DBName}`.`tblprimarycodes` SET fldEPR = '{Code}' "
                output += $"WHERE fldPrintCode in ('{String.Join("','", upUIs)}');"
            Case AggregationType.Aggregated_Only
                output += $"UPDATE `{DBBase.DBName}`.`tblaggregatedcodes` SET fldEPR = '{Code}' "
                output += $"WHERE fldPrintCode in ('{String.Join("','", aUIs)}');"
            Case AggregationType.Both
                output += $"UPDATE `{DBBase.DBName}`.`tblprimarycodes` AS P, `{DBBase.DBName}`.`tblaggregatedcodes` AS A "
                output += $"SET P.fldEPR = '{Code}', A.fldEPR = '{Code}' "
                output += $"WHERE P.fldPrintCode in ('{String.Join("','", upUIs)}') "
                output += $"AND A.fldPrintCode in ('{String.Join("','", aUIs)}');"
            Case Else
                Throw New NotImplementedException($"Ui_type '{UI_Type}' does not exist.")
        End Select
        Return output
    End Function

    Public Overrides Function GetReport() As String
        Return $"{Message_Type} message unpacked. JSON ID: '{Code}'"
    End Function

End Class

