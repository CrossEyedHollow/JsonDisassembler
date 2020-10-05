Imports Newtonsoft.Json.Linq

Module Module1

    Public Property Settings As DataSet
    Private Property db As DBManager

    Private Property T As Stopwatch

    Sub Main()
        Intitialize()

        While True
            Dim result As DataTable

            'Check IRUs
            result = db.CheckTable(Tables.tbljsonsecondary, "IRU")
            'Process them
            ProcessMessages(result, Tables.tbljsonsecondary.ToString())

            '2nd EUA
            result = db.CheckTable(Tables.tbljson, "EUA")
            'Process them
            ProcessMessages(result, Tables.tbljson.ToString())

            '3rd EPA
            result = db.CheckTable(Tables.tbljson, "EPA")
            'Process them
            ProcessMessages(result, Tables.tbljson.ToString())

            'Check the rest of the messages from the router
            result = db.CheckSecondaryTable()
            'Process them
            ProcessMessages(result, Tables.tbljsonsecondary.ToString())

            'Check all else from facility
            result = db.CheckPrimaryTable()
            'Process them
            ProcessMessages(result, Tables.tbljson.ToString())

            'Disconnect from the db
            db.Disconnect()

            'Report job finished
            ReportTools.Output.ToConsole("All message types proccessed, taking a short break.")
            Threading.Thread.Sleep(TimeSpan.FromSeconds(30))
        End While
    End Sub

    Private Sub ProcessMessages(messages As DataTable, sourceTable As String)
        If messages.Rows.Count > 0 Then
            For Each row As DataRow In messages.Rows
                'Get the Json Index
                Dim index = Convert.ToInt32(row("fldIndex"))

                'Try to process the idividual message
                Try
                    'Start timer
                    T.Restart()
                    'Deserializer JSON
                    Dim strJson As JObject = JObject.Parse(row("fldJson"))
                    Dim msg As Message = JsonUnpackager.Unpack(strJson)
                    msg.GetJsonIndex = index
                    'Save the time it took to process message
                    Dim proccessTime As TimeSpan = T.Elapsed()
                    T.Restart()
                    'Insert into database
                    Dim query As String = msg.GetSqlStatement()
                    db.Execute(query)
                    'Save the query execution time
                    T.Stop()
                    Dim queryTime As TimeSpan = T.Elapsed
                    'Mark JSON as Upacked
                    db.UpdateJsonStatus(msg.GetJsonIndex, sourceTable)
                    'Report success
                    ReportTools.Output.ToConsole(msg.GetReport() & $" Proccess time: {proccessTime.TotalSeconds.ToString("N3")}s, SQL time: {queryTime.TotalSeconds.ToString("N3")}s.")
                Catch ex As Exception
                    ReportTools.Output.Report($"Failed to process JSON with id: {index}, reason: {ex.Message}")
                End Try
            Next
        End If
    End Sub

    Private Sub FillMessageType(table As String)
        Dim query As String = $"SELECT * FROM {DBBase.DBName}.{table} WHERE fldType = '' LIMIT 10000;"

        While True
            Dim result As DataTable = db.ReadDatabase(query)
            If result.Rows.Count > 0 Then

                Dim resultQuery As String = $"UPDATE {DBBase.DBName}.{table} SET fldType = (CASE "

                For Each row As DataRow In result.Rows
                    Dim fldIndex As Integer = Convert.ToInt32(row("fldIndex"))
                    Try
                        Dim json As JObject = JObject.Parse(row("fldJson"))
                        Dim type As String = json("Message_Type")

                        resultQuery += $"WHEN fldIndex = {fldIndex} THEN '{type}' "
                    Catch ex As Exception
                        ReportTools.Output.Report($"Failed to process IRU with index: {fldIndex}")
                    End Try
                Next
                resultQuery += "end) "
                resultQuery += $"WHERE fldType = '';"

                db.Execute(resultQuery)
            Else
                ReportTools.Output.ToConsole($"Table '{table}' update finished. ")
                Exit While
            End If

        End While
    End Sub

    Private Sub Intitialize()
        T = New Stopwatch()
        'Read the Settings file and save to memory
        Settings = New DataSet()
        Settings.ReadXml($"{AppDomain.CurrentDomain.BaseDirectory}Settings.xml")

        'Initialize the DBManager objects
        Dim dbSetting As DataRow = Settings.Tables("tblDBSettings").Rows(0)
        DBBase.DBName = dbSetting("fldDBName")
        DBBase.DBIP = dbSetting("fldServer")
        DBBase.DBUser = dbSetting("fldAccount")
        DBBase.DBPass = dbSetting("fldPassword")
        DBBase.DBPort = Convert.ToInt32(dbSetting("fldPort"))
        db = New DBManager()

        'DBBase db = New DBBase()
    End Sub
End Module

Public Enum Tables
    tbljson
    tbljsonsecondary
End Enum
