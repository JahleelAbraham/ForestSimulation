Namespace Trees

    Public Class NordmanFir
        Inherits Tree
    
        Dim ReadOnly _hMinAge = 25
        Dim ReadOnly _hMaxAge = 70
    
        Public Overrides Function CanHarvest As Boolean
            If Age < _hMaxAge And Age > _hMinAge
                Return True
            Else
                Return False
            End If
        End Function
    End Class
End NameSpace