Namespace Trees
    Public Class NorwaySpruce
        Inherits Tree
    
        Dim ReadOnly _hMinAge = 90
        Dim ReadOnly _hMaxAge = 150
    
        Public Function CanHarvest As Boolean
            If Age < _hMaxAge And Age > _hMinAge
                Return True
            Else
                Return False
            End If
        End Function
    End Class
End NameSpace