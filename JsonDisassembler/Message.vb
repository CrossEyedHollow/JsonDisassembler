Imports Newtonsoft.Json.Linq

Public Class Message
    Public Property JSON As JObject

    Public Sub New(json As JObject, jIndex As Integer)
        Me.JSON = json
        jsonIndex = jIndex
    End Sub

    Private jsonIndex As Integer
    Public ReadOnly Property GetJsonIndex() As Integer
        Get
            Return jsonIndex
        End Get
    End Property

    Public Overridable Function InsertIntoDB() As String
        Throw New InvalidOperationException()
    End Function

End Class
