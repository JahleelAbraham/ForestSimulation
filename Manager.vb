Imports System.Runtime.Remoting.Messaging
Imports ForestSimulation.Trees
Imports ForestSimulation.Utils
Imports Spectre.Console
Imports Spectre.Console.Rendering

Module Manager
    Public Dim Month as Month = Month.December
    Public Dim Year as Integer = 2020
    
    Public Dim State as State = New State()
    Public Dim OldState as State = New State()
    Public Sub Update()
        OldState = State.Clone()
        
        Month = If(Int(Month) + 1 > 11, 0, Int(Month) + 1)
        If Month = Month.January
            Year += 1
            HarvestMonth = Int((Month.December * Rnd) + 1)
        End If
        TreeManager.Update()
        
        UpdateState()
        DebugOutput()
    End Sub
    
    Public Sub UpdateState()
        State.Month = Month
        State.TreeAmount = TreeManager.Trees.Count
        State.NorwaySpruce = TreeManager.Trees.FindAll(Function(t) TypeOf t Is NorwaySpruce).Count
        State.NordmannFir = TreeManager.Trees.FindAll(Function(t) TypeOf t Is NordmanFir).Count
        State.Maple = TreeManager.Trees.FindAll(Function(t) TypeOf t Is Maple).Count
        State.Syrup = Syrup
        State.Harvested = Harvested
        State.DestroyedInFire = DestroyedInFire
    End Sub
    
    Public Sub DebugOutput()
        AnsiConsole.Clear()
        
        AnsiConsole.MarkupLine($"=============== {Month.ToString()} {Year} ===============")
        AnsiConsole.MarkupLine(
            $"Amount of Trees: {State.TreeAmount} {CalculateDifference(State.TreeAmount, OldState.TreeAmount)}")
        AnsiConsole.MarkupLine(
            $"Norway Spruce: {State.NorwaySpruce} {CalculateDifference(State.NorwaySpruce, OldState.NorwaySpruce)}")
        AnsiConsole.MarkupLine(
            $"Nordmann Fir: {State.NordmannFir} {CalculateDifference(State.NordmannFir, OldState.NordmannFir)}")
        AnsiConsole.MarkupLine($"Maple: {State.Maple} {CalculateDifference(State.Maple, OldState.Maple)}")
        AnsiConsole.WriteLine()
        AnsiConsole.MarkupLine($"Syrup: {State.Syrup}L {CalculateDifference(State.Syrup, OldState.Syrup)}")
        AnsiConsole.MarkupLine($"Harvested: {State.Harvested} Trees {CalculateDifference(State.Harvested, OldState.Harvested)}")
        AnsiConsole.WriteLine()
        AnsiConsole.MarkupLine($"Destroyed In Fire: {State.DestroyedInFire} Trees {CalculateDifference(State.DestroyedInFire, OldState.DestroyedInFire)}")
        AnsiConsole.WriteLine()
        AnsiConsole.WriteLine()

        
        AnsiConsole.WriteLine()
        AnsiConsole.MarkupLine($"Press '[yellow]P[/]' To increase the simulation speed. '[yellow]O[/]' To Slowdown           Current Speed: [yellow]{Speed}[/]")
    End Sub
    
    Public Function CalculateDifference(a as Integer, b as Integer) As String
        If a = 0 Or b = 0
            Return "[grey]+0%[/]"
        End If
        
        Dim c As Double = ((a - b) / b) * 100
        c = Math.Round(c, 2)
        
        If c < 0
            Return "[red]" & c & "%[/]"
        Else If c > 0
            Return "[green]+" & c & "%[/]"
        Else If c.Equals(0)
            Return "[grey]+" & c & "%[/]"
        Else 
            Return "[grey]+0%[/]"
        End If
    End Function
End Module