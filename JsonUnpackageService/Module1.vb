Imports Newtonsoft.Json.Linq

Module Module1

    Public Property Settings As DataSet
    Private Property db As DBManager

    Sub Main()
        Intitialize()
        Dim t As Stopwatch = New Stopwatch()

        'TEST ZONE

        'END TEST

        While True
            While True
                'Check for message types in order specified in the PriorityTracker
                Dim currType As String = PriorityTracker.GetJsonType()
                Dim dtJSONs As DataTable = db.CheckForType(currType)

                'If there are any message of this type
                If dtJSONs.Rows.Count > 0 Then
                    For Each row As DataRow In dtJSONs.Rows
                        'Get the Json Index
                        Dim index = Convert.ToInt32(row("fldIndex"))

                        'Try to process the idividual message
                        Try
                            'Start timer
                            t.Restart()
                            'Deserializer JSON
                            Dim strJson As JObject = JObject.Parse(row("fldJson"))
                            Dim msg As Message = JsonUnpackager.Unpack(strJson)
                            msg.GetJsonIndex = index
                            'Save the time it took to process message
                            Dim proccessTime As TimeSpan = t.Elapsed()
                            t.Restart()
                            'Insert into database
                            Dim query As String = msg.GetSqlStatement()
                            db.Execute(query)
                            'Save the query execution time
                            t.Stop()
                            Dim queryTime As TimeSpan = t.Elapsed
                            'Mark JSON as Upacked
                            db.UpdateJsonType(msg.GetJsonIndex, msg.Message_Type)
                            'Report success
                            ReportTools.Output.ToConsole(msg.GetReport() & $" Proccess time: {proccessTime.TotalSeconds.ToString("N3")}s, SQL time: {queryTime.TotalSeconds.ToString("N3")}s.")
                        Catch ex As Exception
                            ReportTools.Output.Report($"Failed to process JSON with id: {index}, reason: {ex.Message}")
                        End Try
                    Next
                End If

                'Next JSON type
                If (currType = String.Empty) Then
                    PriorityTracker.Reset()
                    Exit While
                Else
                    PriorityTracker.NextType()
                End If
            End While
            ReportTools.Output.ToConsole("All message types proccessed, taking a short break.")
            Threading.Thread.Sleep(TimeSpan.FromSeconds(30))
        End While

        'Disconnect from the database
        db.Disconnect()

    End Sub

    Private Sub UnpackIRUs()

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
