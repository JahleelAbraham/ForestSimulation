Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports ForestSimulation.Trees

Namespace Utils
    
    <Serializable()> _
    Public Class State
        Implements ICloneable
        
        Public Dim Month As Month
        Public Dim TreeAmount As Integer
        Public Dim NorwaySpruce As Integer
        Public Dim NordmannFir As Integer
        Public Dim Maple As Integer
        Public Dim Syrup As Double
        Public Dim Harvested As Integer
        Public Function Clone() As Object Implements ICloneable.Clone
            Dim m As New MemoryStream()
            Dim f As New BinaryFormatter()
            f.Serialize(m, Me)
            m.Seek(0, SeekOrigin.Begin)
            Return f.Deserialize(m)
        End Function
    End Class
End NameSpace