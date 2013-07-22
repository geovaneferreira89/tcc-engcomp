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

'''<summary>A collection of Neuron Layers </summary>
Public Class NeuronLayerCollection
    Inherits ArrayList

    Public Shadows Function Add(ByVal obj As NeuronLayer) As NeuronLayer
        MyBase.Add(obj)
        Add = obj
    End Function

    Public Shadows Function Add() As NeuronLayer
        Dim nl As New NeuronLayer()
        MyBase.Add(nl)
        Add = nl
    End Function

    Public Shadows Sub Insert(ByVal index As Integer, ByVal obj As NeuronLayer)
        MyBase.Insert(index, obj)
    End Sub

    Public Shadows Sub Remove(ByVal obj As NeuronLayer)
        MyBase.Remove(obj)
    End Sub

    Default Public Shadows Property Item(ByVal index As Integer) As NeuronLayer
        Get
            Item = DirectCast(MyBase.Item(index), NeuronLayer)
        End Get
        Set(ByVal Value As NeuronLayer)
            MyBase.Item(index) = Value
        End Set
    End Property
End Class