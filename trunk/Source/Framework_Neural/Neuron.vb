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

'''<summary> Exception that may be thrown when the strategy is not initialized </summary>
Public Class StrategyNotInitializedException
    Inherits NeuralFrameworkException

    Sub New(ByVal Message As String, ByVal e As Exception)
        MyBase.New(Message, e)
    End Sub


End Class


'''<summary>A concrete implementation of INeuron </summary>
Public Class Neuron
    Implements INeuron


    Dim _bias As Single = Utility.Rand2

    Dim _output As Single
    Dim _delta As Single
    Dim _forwardConnections As New NeuronCollection()


    Dim _inputs As NeuronConnections = New NeuronConnections()
    Dim _strategy As INeuronStrategy = Nothing



    '''<summary> Default constructor</summary>
    Public Sub New()
    End Sub

    '''<summary> A constructor to initialize a neuron with its strategy </summary>
    Public Sub New(ByVal strategy As INeuronStrategy)
        _strategy = strategy
    End Sub


    '''<summary> Gets the current bias this neuron</summary>
    Public Property BiasValue() As Single Implements NeuralFramework.INeuron.BiasValue
        Get
            Return _bias
        End Get
        Set(ByVal Value As Single)
            _bias = Value
        End Set
    End Property

    '''<summary> Gets the current output of this neuron</summary>
    Public Property OutputValue() As Single Implements NeuralFramework.INeuron.OutputValue
        Get
            Return _output
        End Get
        Set(ByVal Value As Single)
            _output = Value

        End Set
    End Property

    '''<summary> Gets the current delta value of this neuron</summary>
    Public Property DeltaValue() As Single Implements NeuralFramework.INeuron.DeltaValue
        Get
            Return _delta
        End Get
        Set(ByVal Value As Single)
            _delta = Value
        End Set
    End Property

    '''<summary> Gets a list of neurons connected to this neuron </summary>
    Public ReadOnly Property Inputs() As NeuralFramework.NeuronConnections Implements NeuralFramework.INeuron.Inputs
        Get
            Return _inputs
        End Get
    End Property

    '''<summary> Gets or Sets the strategy of this neuron </summary>
    Public Property Strategy() As NeuralFramework.INeuronStrategy Implements NeuralFramework.INeuron.Strategy
        Get
            Return _strategy
        End Get
        Set(ByVal Value As NeuralFramework.INeuronStrategy)
            _strategy = Value
        End Set
    End Property

    '''Methods

    '''<summary> Calculate the error value </summary>
    Public Sub UpdateDelta(ByVal errorFactor As Single) Implements NeuralFramework.INeuron.UpdateDelta

        If _strategy Is Nothing Then Throw New StrategyNotInitializedException("Strategy of the neuron not initialized. Assign a proper strategy", Nothing)

        '''Error factor can be target - output for output layer
        DeltaValue = Strategy.FindDelta(OutputValue, errorFactor)
    End Sub

    '''<summary> Calculate the output </summary>
    Public Sub UpdateOutput() Implements NeuralFramework.INeuron.UpdateOutput

        If _strategy Is Nothing Then Throw New StrategyNotInitializedException("Strategy of the neuron not initialized. Assign a proper strategy", Nothing)


        Dim netValue As Single = Strategy.FindNetValue(Inputs, BiasValue)
        ''Aqui definimos a sigmoide se é mais suave ou não... 
        ''If Inputs.Count <= 10 Then
        OutputValue = Strategy.Activation(netValue)
        '' Else
        ''OutputValue = Strategy.HiperbolicaFunc(netValue)
        'End If
    End Sub

    '''<summary> Calculate the free parameters </summary>
    Public Sub UpdateFreeParams() Implements NeuralFramework.INeuron.UpdateFreeParams

        If _strategy Is Nothing Then Throw New StrategyNotInitializedException("Strategy of the neuron not initialized. Assign a proper strategy", Nothing)


        BiasValue = Strategy.FindNewBias(BiasValue, DeltaValue)
        Strategy.UpdateWeights(Inputs, DeltaValue)

    End Sub


    '''<summary> Returns a list of all neurons to which this neuron is connected </summary>
    Public ReadOnly Property ForwardConnections() As NeuralFramework.NeuronCollection Implements NeuralFramework.INeuron.ForwardConnections
        Get
            Return _forwardConnections
        End Get
    End Property
End Class