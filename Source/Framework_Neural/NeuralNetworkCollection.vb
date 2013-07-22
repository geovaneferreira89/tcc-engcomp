'------------------------------------------------------------------
' License Notice:
'------------------------------------------------------------------
' All Rights Reserved - Anoop Madhusudanan, 
' Mail: amazedsaint@gmail.com
' Website: http://amazedsaint.blogspot.com

' See my articles about BrainNet at 
' http://amazedsaint-articles.blogspot.com for details
'
' You can use this code (or part of it), for non 
' commercial and academic uses, as long as 
'   - You are keeping this notice along with it
'   - You are not making any profit out of this
'------------------------------------------------------------------

'''<summary>A collection of neural networks </summary>
Public Class NeuralNetworkCollection
    Inherits ArrayList

    Public Shadows Function Add(ByVal obj As INeuralNetwork) As INeuralNetwork
        MyBase.Add(obj)
        Add = obj
    End Function

    Public Shadows Sub Insert(ByVal index As Integer, ByVal obj As INeuralNetwork)
        MyBase.Insert(index, obj)
    End Sub

    Public Shadows Sub Remove(ByVal obj As INeuralNetwork)
        MyBase.Remove(obj)
    End Sub

    Default Public Shadows Property Item(ByVal index As Integer) As INeuralNetwork
        Get
            Item = DirectCast(MyBase.Item(index), INeuralNetwork)
        End Get
        Set(ByVal Value As INeuralNetwork)
            MyBase.Item(index) = Value
        End Set
    End Property


End Class