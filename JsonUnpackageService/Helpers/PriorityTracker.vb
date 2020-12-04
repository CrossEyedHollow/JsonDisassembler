Public Class PriorityTracker
    Public Shared Property PriorityList As String() = New String() {"IRU", "EUA", "EPA"}
    Private Shared Property Counter As Integer = 0


    ''' <summary>
    ''' Each time this function is called, it returns the current item and jumps to the next one,
    ''' after the last items, returns string.Empty once and resets
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetJsonType() As String
        Dim output As String = ""
        'Check if the counter is overflowing
        If Counter > (PriorityList.Length - 1) Then
            Reset()
            output = String.Empty
        Else
            output = PriorityList(Counter)
            NextType()
        End If
        Return output
    End Function

    Public Shared Sub NextType()
        Counter += 1
    End Sub

    Public Shared Sub Reset()
        Counter = 0
    End Sub
End Class
