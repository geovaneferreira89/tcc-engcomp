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

'''<summary>A collection of INeurons </summary>
Public Class NeuronCollection
    Inherits ArrayList

    Public Shadows Function Add(ByRef obj As INeuron) As INeuron
        MyBase.Add(obj)
        Add = obj
    End Function

    Public Shadows Function Add() As INeuron
        Dim obj As New Neuron()
        obj.BiasValue = Utility.Rand()

        MyBase.Add(obj)
        Add = obj
    End Function

    Public Shadows Sub Insert(ByVal index As Integer, ByVal obj As INeuron)
        MyBase.Insert(index, obj)
    End Sub

    Public Shadows Sub Remove(ByVal obj As INeuron)
        MyBase.Remove(obj)
    End Sub

    Default Public Shadows Property Item(ByVal index As Integer) As INeuron
        Get
            Item = DirectCast(MyBase.Item(index), INeuron)
        End Get
        Set(ByVal Value As INeuron)
            MyBase.Item(index) = Value
        End Set
    End Property
End Class