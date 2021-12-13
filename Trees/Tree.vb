Namespace Trees
    Public Class Tree
        Public Dim Age as Integer
        Public Dim Birthday as Month
        
        Public Overridable Function CanHarvest() As Boolean
            Return False
        End Function
    End Class

    Public Enum Month
        January
        February
        March
        April
        May
        June
        July
        August
        September
        October
        November
        December
    End Enum
End NameSpace