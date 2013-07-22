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

'''<summary> Exception that may be thrown by INeuralNetwork class </summary>
Public Class NeuralNetworkException
    Inherits NeuralFrameworkException

    Sub New(ByVal Message As String, ByVal e As Exception)
        MyBase.New(Message, e)
    End Sub

End Class


'''<summary> Exception that may be thrown when there are not enough layers </summary>
Public Class NotEnoughLayersException
    Inherits NeuralNetworkException

    Sub New(ByVal Message As String, ByVal e As Exception)
        MyBase.New(Message, e)
    End Sub

End Class

'''<summary> Exception that may be thrown when training function fails </summary>
Public Class TrainingException
    Inherits NeuralNetworkException

    Sub New(ByVal Message As String, ByVal e As Exception)
        MyBase.New(Message, e)
    End Sub

End Class

'''<summary> Exception that may be thrown when the number of inputs doesn'''t match number of input neurons </summary>
Public Class InvalidInputException
    Inherits NeuralNetworkException

    Sub New(ByVal Message As String, ByVal e As Exception)
        MyBase.New(Message, e)
    End Sub

End Class

'''<summary> Exception that may be thrown when the number of outputs doesn'''t match number of output neurons </summary>
Public Class InvalidOutputException
    Inherits NeuralNetworkException

    Sub New(ByVal Message As String, ByVal e As Exception)
        MyBase.New(Message, e)
    End Sub

End Class


'''<summary> Exception that may be thrown when we running the neural network fails </summary>
Public Class RunningException
    Inherits NeuralNetworkException

    Sub New(ByVal Message As String, ByVal e As Exception)
        MyBase.New(Message, e)
    End Sub

End Class



'''<summary>A generic neural network </summary>
Public Class NeuralNetwork
    Implements INeuralNetwork

    '''Layer Collections
    Private _layers As New NeuronLayerCollection()


    '''<summary>Method to train a network </summary>
    Public Sub TrainNetwork(ByVal t As TrainingData) Implements INeuralNetwork.TrainNetwork

        If _layers.Count < 2 Then
            Throw New NotEnoughLayersException("You should have atleast two layers in your neural network to train it", Nothing)
        End If

        If t.Inputs.Count <> InputLayer.Count Then
            Throw New InvalidInputException("Number of inputs doesn'''t match number of neurons in input layer", Nothing)
        End If

        If t.Outputs.Count <> OutputLayer.Count Then
            Throw New InvalidOutputException("Number of outputs doesn'''t match number of neurons in output layer", Nothing)
        End If

        Dim counter As Long

        '''Ensure that all inputs and outputs can be converted to Single
        For counter = 0 To t.Inputs.Count - 1
            Try
                t.Inputs(counter) = CType(t.Inputs(counter), Single)
            Catch
                Throw New InvalidInputException("Unable to convert the input value at location " & counter + 1 & " to Single", Nothing)
            End Try
        Next

        For counter = 0 To t.Outputs.Count - 1
            Try
                t.Outputs(counter) = CType(t.Outputs(counter), Single)
            Catch
                Throw New InvalidOutputException("Unable to convert the output value at location " & counter + 1 & " to Single", Nothing)
            End Try
        Next


        Try
            Dim i As Long
            Dim someNeuron As INeuron

            i = 0
            For Each someNeuron In InputLayer
                someNeuron.OutputValue = t.Inputs(i)
                i = i + 1
            Next

            '''Step1: Find the output of hidden layer neurons and output layer neurons

            Dim nl As NeuronLayer
            Dim count As Long = 1

            For count = 1 To _layers.Count - 1
                nl = _layers(count)
                For Each someNeuron In nl
                    someNeuron.UpdateOutput()
                Next
            Next

            '''Step2: Finding Delta


            '''2.1) Find the delta (error rate) of output layer



            i = 0
            For Each someNeuron In OutputLayer
                '''Find the target-output value and pass it
                someNeuron.UpdateDelta(t.Outputs(i) - someNeuron.OutputValue)
                i = i + 1
            Next

            '''2.2) Calculate delta of all the hidden layers, backwards

            Dim layer As Long
            Dim currentLayer As NeuronLayer

            For i = _layers.Count - 2 To 1 Step -1

                '''MsgBox(_hiddenLayers.Count())

                currentLayer = _layers(i)

                For Each someNeuron In currentLayer
                    Dim errorFactor As Single = 0
                    Dim connectedNeuron As INeuron

                    For Each connectedNeuron In someNeuron.ForwardConnections
                        '''Sum up all the delta * weight
                        errorFactor = errorFactor + (connectedNeuron.DeltaValue * _
                                    connectedNeuron.Inputs.Weight(someNeuron))
                    Next

                    someNeuron.UpdateDelta(errorFactor)
                Next

            Next


            '''Step3: Update the free parameters of hidden and output layers

            For i = 1 To _layers.Count - 1
                For Each someNeuron In _layers(i)
                    someNeuron.UpdateFreeParams()
                Next
            Next


        Catch e As Exception
            Throw New TrainingException("Error occurred while training network. ", e)
        End Try

    End Sub



    '''<summary>Gets the first (input) layer</summary>
    Public ReadOnly Property InputLayer() As NeuronLayer Implements INeuralNetwork.InputLayer
        Get
            If _layers.Count < 2 Then
                Throw New NotEnoughLayersException("You should have atleast two layers in your neural network to train it", Nothing)
            End If
            Return _layers(0)
        End Get
    End Property

    '''<summary>Gets the last (output) layer</summary>
    Public ReadOnly Property OutputLayer() As NeuronLayer Implements INeuralNetwork.OutputLayer
        Get
            If _layers.Count < 2 Then
                Throw New NotEnoughLayersException("You should have atleast two layers in your neural network to train it", Nothing)
            End If
            Return _layers(_layers.Count - 1)
        End Get
    End Property



    '''<summary>This function can be used for connecting two neurons together </summary>
    Public Sub ConnectNeurons(ByVal source As INeuron, ByVal destination As INeuron, ByVal weight As Single) Implements INeuralNetwork.ConnectNeurons
        If _layers.Count < 2 Then
            Throw New NotEnoughLayersException("You should have atleast two layers in your neural network to train it", Nothing)
        End If
        destination.Inputs.Add(source, weight)
        source.ForwardConnections.Add(destination)
    End Sub


    '''<summary>This function can be used for connecting two neurons together with random weight </summary>
    Public Sub ConnectNeurons(ByVal source As INeuron, ByVal destination As INeuron) Implements INeuralNetwork.ConnectNeurons
        If _layers.Count < 2 Then
            Throw New NotEnoughLayersException("You should have atleast two layers in your neural network to train it", Nothing)
        End If
        ConnectNeurons(source, destination, Utility.Rand())
    End Sub

    '''<summary>This function can be used for connecting neurons in two layers together with random weights </summary>
    Public Sub ConnectLayers(ByVal layer1 As NeuronLayer, ByVal layer2 As NeuronLayer) Implements INeuralNetwork.ConnectLayers
        '''Connect layers in between and assign random weights
        Dim inputNeuron As INeuron
        Dim targetNeuron As INeuron

        If _layers.Count < 2 Then
            Throw New NotEnoughLayersException("You should have atleast two layers in your neural network to train it", Nothing)
        End If

        '''Step 1: Connect input layer neurons to first hidden layer neurons

        For Each inputNeuron In layer1
            For Each targetNeuron In layer2
                ConnectNeurons(inputNeuron, targetNeuron)
            Next
        Next

    End Sub


    '''<summary>This function can be used for connecting all neurons in all layers together </summary>

    Public Sub ConnectLayers() Implements INeuralNetwork.ConnectLayers
        '''Connect layers in between and assign random weights

        Try

            Dim prevLayer As NeuronLayer, nextLayer As NeuronLayer
            Dim i As Long

            For i = 1 To _layers.Count - 1
                ConnectLayers(_layers(i - 1), _layers(i))
            Next

        Catch e As Exception
            Throw New NeuralNetworkException("Error occurred while trying to connect neuron layers. See stack trace for details", e)
        End Try

    End Sub


    '''<summary>This function may be used for running the network. It returns the output list </summary>

    Function RunNetwork(ByVal inputs As ArrayList) As ArrayList Implements INeuralNetwork.RunNetwork

        If inputs.Count <> InputLayer.Count Then
            Throw New InvalidInputException("Number of inputs doesn'''t match number of neurons in input layer", Nothing)
        End If

        Dim counter As Long
        For counter = 0 To inputs.Count - 1
            Try
                inputs(counter) = CType(inputs(counter), Single)
            Catch
                Throw New InvalidInputException("Unable to convert the  input value at location " & counter + 1 & " to Single", Nothing)
            End Try
        Next



        Try
            Dim someNeuron As INeuron

            Dim i As Long = 0
            For Each someNeuron In InputLayer
                someNeuron.OutputValue = CType(inputs(i), System.Single)
                i += 1
            Next

            '''Step1: Find the output of each hidden neuron layer


            Dim nl As NeuronLayer

            For i = 1 To _layers.Count - 1

                nl = _layers(i)
                For Each someNeuron In nl
                    someNeuron.UpdateOutput()
                Next
            Next

            Return GetOutput()


        Catch e As Exception
            Throw New RunningException("Error occurred while running the network. ", e)
        End Try

    End Function

    '''<summary>This function may be used to obtain the output vector </summary>
    Public Function GetOutput() As ArrayList Implements INeuralNetwork.GetOutput
        Dim arr As ArrayList

        arr = New ArrayList()

        Dim someNeuron As INeuron
        For Each someNeuron In OutputLayer
            arr.Add(someNeuron.OutputValue)
        Next
        Return arr

    End Function


    '''<summary>This property returns the Output layer </summary>
    Public ReadOnly Property Layers() As NeuronLayerCollection Implements INeuralNetwork.Layers
        Get
            Return _layers
        End Get
    End Property



End Class