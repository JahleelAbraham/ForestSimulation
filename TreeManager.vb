Imports ForestSimulation.Trees
Imports ForestSimulation.Utils

Module TreeManager
    Public ReadOnly Trees As List(Of Tree) = New List(Of Tree)()
    Public Dim Syrup As Integer = 0

    Public Sub Update()
        Dim n = Int((6 * Rnd) + 1)
        BirthdayCheck()
        'TapMaple()
        PlantTrees(n, n * 4)
    End Sub
    
    Private Sub BirthdayCheck()
        For Each tree As Tree In Trees
            If tree.Birthday.Equals(Month)
                tree.Age += 1
            End If
        Next
    End Sub
    
    Private Sub TapMaple
        If Trees.FindAll(Function(t) TypeOf t Is Maple).Count = 0 
            Return
        End If
        
        Dim tapped As Integer
        Dim maples =
                TryCast(CObj(Trees.FindAll(Function(t) TypeOf t Is Maple)), List(Of Maple)).Where(
                    Function(t) t.CanBeTapped())
        
        Dim collection As IEnumerable(Of Maple) = maples.ToList()
        Shuffle(collection)
        
        For i = 0 To (maples.Count * Rnd) + 1
            tapped += collection.ElementAt(i).Tap()
        Next
        
        Syrup += tapped
    End Sub
    
    
    Private Sub PlantTrees(norway As Integer, nordmann As Integer)
        'TODO: Calculate no of Maple using %
        Dim maple = (norway + nordmann) Mod 3
        
        For i = 0 To norway
            Trees.Add(new NorwaySpruce With { .Birthday = Month })
        Next
        
        For i = 0 To nordmann
            Trees.Add(new NordmanFir With { .Birthday = Month })
        Next
        
        For i = 0 To maple
            Trees.Add(new Maple With { .Birthday = Month })
        Next
    End Sub
End Module