Namespace Trees
    ' The Nordmann Fir Tree Type
    Public Class NordmanFir
        Inherits Tree ' Derives from the base Tree class
    
        Dim ReadOnly _hMinAge = 25 ' Minimum harvest age
        Dim ReadOnly _hMaxAge = 70 ' Maximum harvest age
    
        Public Overrides Function CanHarvest As Boolean
            If Age < _hMaxAge And Age > _hMinAge
                Return True
            Else
                Return False
            End If
        End Function
    End Class
End NameSpace