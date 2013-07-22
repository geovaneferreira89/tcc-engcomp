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

'''<summary> A Factory for creating a backward propagation neural network</summary>
Public Class BackPropNetworkFactory
    Implements INetworkFactory

    '''<summary> Method to create a network. The input is a list of long values that represent the number
    '''of neurons in each layer</summary>
    Public Function CreateNetwork(ByVal neuronsInLayers As ArrayList) As BrainNet.NeuralFramework.INeuralNetwork
        Dim bnn As New NeuralNetwork()
        Dim neurons As Long

        Dim strategy As New BackPropNeuronStrategy()

        For Each neurons In neuronsInLayers
            Dim layer As NeuronLayer
            Dim i As Long

            layer = New NeuronLayer()

            For i = 0 To neurons - 1
                layer.Add(New Neuron(strategy))
            Next

            bnn.Layers.Add(layer)
        Next

        '''Connect all layers together
        bnn.ConnectLayers()
        Return bnn

    End Function

    '''<summary> Build a simple back prop neural network</summary>
    Public Function CreateNetwork(ByVal inputneurons As Long, ByVal outputneurons As Long) As BrainNet.NeuralFramework.INeuralNetwork Implements BrainNet.NeuralFramework.INetworkFactory.CreateNetwork

        Dim arr As ArrayList = New ArrayList()
        '''Add input layer
        arr.Add(inputneurons)
        '''Add a hidden layer
        arr.Add(inputneurons)
        '''Add the output layer
        arr.Add(outputneurons)

        Return CreateNetwork(arr)

    End Function

End Class
