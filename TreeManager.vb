Imports ForestSimulation.Trees
Imports ForestSimulation.Utils

Module TreeManager
    Public ReadOnly Trees As List(Of Tree) = New List(Of Tree)()
    Public Dim Syrup As Double = 0
    Public Dim Harvested As Integer = 0
    Public Dim HarvestMonth As Month = Month.May
    
    '-> Animals
    Public Deer As Integer = 57
    
    Public Dim Diseased As Integer = 0
    Public Dim DestroyedInFire As Integer = 0
    
    Public Sub Update()
        Dim n = Int((3 * Rnd) + 1)
        BirthdayCheck()
        TapMaple()
        
        If Month = HarvestMonth
            Harvest()
        End If
        
        RNG()
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
        
        Dim tapped As Double
        Dim maples = Trees.Where(Function(t) TypeOf t Is Maple).Cast(Of Maple)
        
        Dim collection = maples.ToList().FindAll(Function(t) t.CanBeTapped()).ToList()
        Shuffle(collection)
        
        If collection.Count = 0
            Return
        End If
        
        Dim a = Int(((collection.Count / 4) * Rnd) + 1) - 1
        For i = 0 To a
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
    
    Private Sub Harvest()
            For a = 0 To 30
                Dim hTrees = Trees.FindAll(function(tree) tree.CanHarvest())
                
                If hTrees.Count = 0
                    Return
                End If
                
                Dim nFir = hTrees.FindAll(function(tree) TypeOf tree Is NordmanFir)
                Dim nSpruce = hTrees.FindAll(function(tree) TypeOf tree Is NorwaySpruce)
                
                Shuffle(nFir)
                Shuffle(nSpruce)
            
            
                Dim nFirA = Int((If(nFir.Count > 10, 10, nFir.Count) * Rnd) + 1) - 1
                Dim nSpruceA = Int((If(nSpruce.Count > 4, 4, nSpruce.Count) * Rnd) + 1) - 1
            
                If nFirA > 0 And nFir.Count > 0
                    For i = 0 To nFirA
                        Trees.Remove(nFir.ElementAt(i))
                        Harvested += 1
                    Next
                End If
            
                If nSpruceA > 0 And nSpruce.Count > 0
                    For i = 0 To nSpruceA
                        Trees.Remove(nSpruce.ElementAt(i))
                        Harvested += 1
                    Next
                End If
            Next
    End Sub
    
    ''' <summary>
    ''' Calculates anything random
    ''' </summary>
    Private Sub RNG()
        Dim chance = Int((10000 * Rnd) + 1)

        
        '-> Forest Fires
        If Month < Month.September And Month > Month.May
            If chance < 400 And chance > 367
                Randomize()
                
                Dim TTD = Trees
                Dim ATD = Int((300 * Rnd) + 1) - 1
                
                If ATD > TTD.Count
                    ATD = TTD.Count
                End If
                
                Shuffle(TTD)
                
                For i = 0 To ATD - 1 
                    Trees.Remove(TTD.ElementAt(0))
                    DestroyedInFire += 1
                Next
            End If
        End If
        
        '-> Deer Damage
        If chance < 200 And chance > 100
            Randomize()
            
            Dim TTD = Trees
            Dim ATD = Int((Deer * Rnd) + 1) - 1
            
            If ATD > TTD.Count
                ATD = TTD.Count
            End If
            
            Shuffle(TTD)
            If chance > 185
                For i = 0 To ATD - 1 
                    TTD.ElementAt(0).Health -= Int((15 * Rnd) + 1) - 1
                    If TTD.ElementAt(0).Health <= 0
                        Trees.Remove(TTD.ElementAt(0))
                        Diseased += 1
                    End If
                Next
            End If
        End If
    End Sub
End Module