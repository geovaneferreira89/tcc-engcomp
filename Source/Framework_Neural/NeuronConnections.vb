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

'''<summary>This is a hashtable to keep track of all neurons connected to a neuron,
''' and its related weights</summary>
Public Class NeuronConnections
    Inherits Hashtable


    '''<summary>This class wraps a weight value holded by a neuron </summary>
    Private Class WeightMapping
        Public Weight As Single
        Public Sub New(ByVal weight As Single)
            Me.Weight = weight
        End Sub
    End Class

    Public Shadows Function Add(ByRef input As INeuron, ByVal weight As Single) As INeuron
        MyBase.Add(input, New WeightMapping(weight))
        Add = input
    End Function

    Public Shadows Function Add(ByRef input As INeuron) As INeuron
        MyBase.Add(input, New WeightMapping(Utility.Rand))
        Add = input
    End Function


    Public Shadows Sub Remove(ByVal obj As INeuron)
        MyBase.Remove(obj)
    End Sub

    Public Function Neurons() As ICollection
        Return MyBase.Keys
    End Function


    Default Public Shadows Property Weight(ByVal obj As INeuron) As Single
        Get
            Return CType(MyBase.Item(obj), WeightMapping).Weight
        End Get

        Set(ByVal val As Single)
            CType(MyBase.Item(obj), WeightMapping).Weight = val
        End Set

    End Property

End Class

