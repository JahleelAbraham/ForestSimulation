Namespace Trees

    Public Class Maple
        Inherits Tree
        
        Dim ReadOnly _tMinAge = 90
        Dim ReadOnly _tAmount = 1.5
        
        Public Function Tap As Integer
            Return _tAmount
        End Function
    
        Public Function CanBeTapped As Boolean
            If Age > _tMinAge
                Return True
            Else
                Return False
            End If
        End Function
    End Class
End NameSpace