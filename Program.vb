Imports System.Threading

Module Module1
    Public Dim Speed = 1000

    Sub Main()
        Const running = True
        
        While running
            If Console.KeyAvailable
                Dim key = Console.ReadKey(True)
                
                If key.Key = ConsoleKey.P And speed - 100 >= 0
                    speed -= 100
                Else If key.Key = ConsoleKey.O
                    speed += 100
                End If
            End If
            
            Manager.Update()
            Thread.Sleep(Speed) ' Controls the Tick time
        End While
    End Sub
End Module
