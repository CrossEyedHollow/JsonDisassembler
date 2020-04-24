Public Class PriorityTracker
    Public Shared Property PriorityList As String() = New String() {"IRU", "EUA", "EPA"}
    Private Shared Property Counter As Integer = 0

    Public Shared Function GetJsonType() As String
        If Counter > (PriorityList.Length - 1) Then
            Return String.Empty
        End If
        Return PriorityList(Counter)
    End Function

    Public Shared Sub NextType()
        Counter += 1
    End Sub

    Public Shared Sub Reset()
        Counter = 0
    End Sub
End Class
