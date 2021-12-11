Namespace Utils
    Public Module Lists
        Public Function Shuffle(Of T)(collection As IEnumerable(Of T)) As List(Of T)
            Dim r As Random = New Random()
            Shuffle = collection.OrderBy(Function(a) r.Next()).ToList()
        End Function
    End Module
End NameSpace