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

Public Interface INeuralNetwork

    '''<summary>Method to train a network </summary>    
    Sub TrainNetwork(ByVal t As TrainingData)
    '''<summary>This function can be used for connecting two neurons together </summary>
    Sub ConnectNeurons(ByVal source As INeuron, ByVal destination As INeuron, ByVal weight As Single)
    '''<summary>This function can be used for connecting two neurons together with random weight </summary>
    Sub ConnectNeurons(ByVal source As INeuron, ByVal destination As INeuron)
    '''<summary>This function can be used for connecting neurons in two layers together with random weights </summary>
    Sub ConnectLayers(ByVal layer1 As NeuronLayer, ByVal layer2 As NeuronLayer)
    '''<summary>This function can be used for connecting all layers together </summary>
    Sub ConnectLayers()
    '''<summary>This function may be used for running the network </summary>
    Function RunNetwork(ByVal inputs As ArrayList) As ArrayList
    '''<summary>This function may be used to obtain the output list </summary>
    Function GetOutput() As ArrayList
    ReadOnly Property Layers() As NeuronLayerCollection
    '''<summary>Gets the first (input) layer</summary>
    ReadOnly Property InputLayer() As NeuronLayer
    '''<summary>Gets the last (output) layer</summary>
    ReadOnly Property OutputLayer() As NeuronLayer

End Interface
