
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


Module NeuronConstants
    Public Const LEARNING_RATE = 0.5
End Module



'''<summary>The interface for defining a neuron </summary>
Public Interface INeuron

    '''Properties

    '''<summary> Gets the current bias this neuron</summary>
    Property BiasValue() As Single
    '''<summary> Gets the current output this neuron</summary>
    Property OutputValue() As Single
    '''<summary> Gets the current delta value this neuron</summary>
    Property DeltaValue() As Single
    '''<summary> Gets a list of neurons to which this neuron is connected</summary>
    ReadOnly Property ForwardConnections() As NeuronCollection
    '''<summary> Gets a list of neurons connected to this neuron</summary>
    ReadOnly Property Inputs() As NeuronConnections
    '''<summary> Gets or sets the strategy of this neuron</summary>
    Property Strategy() As INeuronStrategy
    '''<summary> Method to update the output of a neuron</summary>
    Sub UpdateOutput()
    '''<summary> Method to find new delta value</summary>
    Sub UpdateDelta(ByVal errorFactor As Single)
    '''<summary> Method to update free parameters</summary>
    Sub UpdateFreeParams()

End Interface

