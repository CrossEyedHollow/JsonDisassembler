Imports System.Runtime.CompilerServices

Module Extenders
    <Extension()>
    Public Function ToMySQL(ByVal d As Date) As String
        Return d.ToString(DBBase.DateTimeFormat)
    End Function
End Module
