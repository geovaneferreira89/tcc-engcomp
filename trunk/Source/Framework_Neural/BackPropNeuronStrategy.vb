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

Imports System.Math

'''<summary> Exception that may be thrown by NeuronStrategy class </summary>
Public Class NeuronStrategyException
    Inherits NeuralFrameworkException

    Sub New(ByVal Message As String, ByVal e As Exception)
        MyBase.New(Message, e)
    End Sub


End Class


'''<summary> A backward propagation neuron strategy. This is a concrete implementation of INeuronStrategy </summary>
Public Class BackPropNeuronStrategy
    Implements INeuronStrategy

    '''Major Methods


    '''<summary> Implementation of Find Delta </summary>
    Public Overridable Function FindDelta(ByVal output As Single, ByVal errorFactor As Single) As Single Implements NeuralFramework.INeuronStrategy.FindDelta
        Try
            Return output * (1 - output) * errorFactor
        Catch e As Exception
            Throw New NeuronStrategyException("Exception in Finding Delta", e)
        End Try
    End Function
    '''<summary> Implementação da tangente hiperbolica </summary>
    Public Overridable Function HiperbolicaFunc(ByVal value As Single) As Double Implements NeuralFramework.INeuronStrategy.HiperbolicaFunc
        Try
            Return ((Exp(value) - Exp(value * -1)) / (Exp(value) + Exp(value * -1)))
        Catch e As Exception
            Throw New NeuronStrategyException("Exception in Hiperbolic function", e)
        End Try

    End Function
    '''<summary> Implementation of activation function </summary>
    Public Overridable Function Activation(ByVal value As Single) As Single Implements NeuralFramework.INeuronStrategy.Activation
        Try
            Dim alpha As Integer = 2
            Return (1 / (1 + Exp(-value * alpha)))
            ' Return (1 / (1 + Exp(value * -1)))
        Catch e As Exception
            Throw New NeuronStrategyException("Exception in Activation function", e)
        End Try

    End Function


    '''<summary> Implementation of finding net value </summary>
    Public Overridable Function FindNetValue(ByVal Inputs As NeuronConnections, ByVal bias As Single) As Single Implements NeuralFramework.INeuronStrategy.FindNetValue
        Try
            Dim nur As INeuron
            Dim sum As Single = bias

            For Each nur In Inputs.Neurons
                sum = sum + (Inputs.Weight(nur) * nur.OutputValue)
            Next
            Return sum
        Catch e As Exception
            Throw New NeuronStrategyException("Exception in Finding Net Value", e)
        End Try



    End Function

    '''<summary> Implementation of Finding new bias value</summary>
    Public Function FindNewBias(ByVal bias As Single, ByVal delta As Single) As Single Implements BrainNet.NeuralFramework.INeuronStrategy.FindNewBias
        Try
            Return bias + LEARNING_RATE * 1 * delta

        Catch e As Exception
            Throw New NeuronStrategyException("Exception in Finding New Bias Value", e)
        End Try
    End Function

    '''<summary> Calculating the new weight values</summary>
    Public Sub UpdateWeights(ByRef connections As NeuronConnections, ByVal delta As Single) Implements BrainNet.NeuralFramework.INeuronStrategy.UpdateWeights

        Try
            Dim nur As INeuron
            For Each nur In connections.Neurons
                '''InputNeuron'''s weights = inp neurons'''s Weight + LEARNING_RATE * InputNeuron'''s.Output * Delta
                connections.Weight(nur) = connections.Weight(nur) + LEARNING_RATE * nur.OutputValue * delta
            Next

        Catch e As Exception
            Throw New NeuronStrategyException("Exception while updating the weight values", e)
        End Try

    End Sub
End Class



