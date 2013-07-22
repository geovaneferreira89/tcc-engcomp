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

'''<summary> Exception thrown when a function is called with out intializing
'''the helper </summary>
Public Class NotInitializedException
    Inherits NeuralFrameworkException

    Sub New(ByVal Message As String, ByVal e As Exception)
        MyBase.New(Message, e)
    End Sub

End Class

'''<summary> Exception thrown when a helper error occurs </summary>
Public Class NetworkHelperException
    Inherits NeuralFrameworkException

    Sub New(ByVal Message As String, ByVal e As Exception)
        MyBase.New(Message, e)
    End Sub

End Class
'''<summary> The class is to help you to initialize,train and run the network. It maintains
'''a list of training data elements. </summary>
Public Class NetworkHelper

    '''<summary> This event will be raised after each training </summary>
    Public Event TrainingProgress(ByVal CurrentRound As Long, ByVal MaxRound As Long, ByRef Cancel As Boolean)

#Region "Private Variables"
    Private _network As INeuralNetwork
    Private trainingQueue As New TrainigDataCollection()
    Private _iftraining As Boolean = False
#End Region

    '''<summary> Initialize with an existing neural network </summary>
    Public Sub New(ByVal network As INeuralNetwork)
        _network = network
    End Sub

    '''<summary> Default constructor </summary>
    Public Sub New()
    End Sub

    '''<summary> Re-Initialize this network manager with a network </summary>
    Public Sub Initialize(ByVal network As INeuralNetwork)
        _network = network
        trainingQueue.Clear()
    End Sub

    '''<summary> This function takes a training data object  </summary>
    Public Sub AddTrainingData(ByVal data As TrainingData)
        If _network Is Nothing Then Throw New NotInitializedException("Helper not yet initialized. Initialize the helper by calling the Initialize function first", Nothing)
        Me.TrainingDataQueue.Add(data)
    End Sub

    '''<summary> This function takes a list of Single values as input and output </summary>
    Public Sub AddTrainingData(ByVal input As ArrayList, ByVal output As ArrayList)

        If _network Is Nothing Then Throw New NotInitializedException("Helper not yet initialized. Initialize the helper by calling the Initialize function first", Nothing)

        If input.Count <> _network.InputLayer.Count Then
            Throw New InvalidInputException("The number of pixels in input image doesn'''t match the number of input layer neurons", Nothing)
        End If

        If output.Count <> _network.OutputLayer.Count Then
            Throw New InvalidOutputException("The number of pixels in output image doesn'''t match the number of output layer neurons", Nothing)
        End If

        Dim td As New TrainingData(input, output)
        AddTrainingData(td)
    End Sub

    '''<summary> This function takes a string pattern consists of 1s and 0s
    ''' as input and output </summary>
    Public Sub AddTrainingData(ByVal input As String, ByVal output As String)

        Dim inp As ArrayList, out As ArrayList
        Dim ppHelper As New PatternProcessingHelper()
        inp = ppHelper.ArrayListFromPattern(input)
        out = ppHelper.ArrayListFromPattern(output)

        '''Add this to the queue
        AddTrainingData(inp, out)
    End Sub

    '''<summary> This function takes numbers as inputs and outputs, convert it to binary strig 
    '''pattern, and add it to the training queue. Eg. 2 will be converted to 10 </summary>
    Public Sub AddTrainingData(ByVal input As Long, ByVal output As Long)

        If _network Is Nothing Then Throw New NotInitializedException("Helper not yet initialized. Initialize the helper by calling the Initialize function first", Nothing)

        Dim ppHelper As New PatternProcessingHelper()
        Dim inputPattern As String = ppHelper.PatternFromNumber(input, _network.InputLayer.Count)
        Dim outputPattern As String = ppHelper.PatternFromNumber(output, _network.OutputLayer.Count)

        AddTrainingData(inputPattern, outputPattern)


    End Sub

    '''<summary> This function takes images as inputs and outputs. The images will be
    '''resized based on the number of inputs and outputs </summary>
    Public Sub AddTrainingData(ByVal input As Image, ByVal output As Image)


        If _network Is Nothing Then Throw New NotInitializedException("Helper not yet initialized. Initialize the helper by calling the Initialize function first", Nothing)

        If input.Width * input.Height <> _network.InputLayer.Count Then
            Throw New InvalidInputException("The number of pixels in input image doesn'''t match the number of input layer neurons", Nothing)
        End If

        If output.Width * output.Height <> _network.OutputLayer.Count Then
            Throw New InvalidOutputException("The number of pixels in output image doesn'''t match the number of output layer neurons", Nothing)
        End If

        Dim imgHelper As New ImageProcessingHelper()

        Dim inArray As ArrayList = imgHelper.ArrayListFromImage(input)
        Dim outArray As ArrayList = imgHelper.ArrayListFromImage(output)

        AddTrainingData(inArray, outArray)

    End Sub

    '''<summary> This function takes an image as input and arraylist as output </summary>
    Public Sub AddTrainingData(ByVal input As Image, ByVal output As ArrayList)

        If _network Is Nothing Then Throw New NotInitializedException("Helper not yet initialized. Initialize the helper by calling the Initialize function first", Nothing)


        If input.Width * input.Height <> _network.InputLayer.Count Then
            Throw New InvalidInputException("The number of pixels in input image doesn'''t match the number of input layer neurons", Nothing)
        End If

        Dim imgHelper As New ImageProcessingHelper()
        Dim inImage As Bitmap

        Dim inArray As ArrayList = imgHelper.ArrayListFromImage(inImage)
        AddTrainingData(inArray, output)

    End Sub

    '''<summary> This function takes an image as input and a pattern as output </summary>
    Public Sub AddTrainingData(ByVal input As Image, ByVal output As String)


        If _network Is Nothing Then Throw New NotInitializedException("Helper not yet initialized. Initialize the helper by calling the Initialize function first", Nothing)


        If input.Width * input.Height <> _network.InputLayer.Count Then
            Throw New InvalidInputException("The number of pixels in input image doesn'''t match the number of input layer neurons", Nothing)
        End If

        Dim imgHelper As New ImageProcessingHelper()
        Dim ppHelper As New PatternProcessingHelper()

        Dim inArray As ArrayList = imgHelper.ArrayListFromImage(input)
        Dim outArray As ArrayList = ppHelper.ArrayListFromPattern(output)
        AddTrainingData(inArray, outArray)

    End Sub

    '''<summary> This function takes an image as input and a value as output </summary>
    Public Sub AddTrainingData(ByVal input As Image, ByVal output As Long)


        If _network Is Nothing Then Throw New NotInitializedException("Helper not yet initialized. Initialize the helper by calling the Initialize function first", Nothing)


        If input.Width * input.Height <> _network.InputLayer.Count Then
            Throw New InvalidInputException("The number of pixels in input image doesn'''t match the number of input layer neurons", Nothing)
        End If

        Dim imgHelper As New ImageProcessingHelper()
        Dim ppHelper As New PatternProcessingHelper()

        Dim inArray As ArrayList = imgHelper.ArrayListFromImage(input)
        Dim outArray As ArrayList = ppHelper.ArrayListFromNumber(output, _network.OutputLayer.Count)
        AddTrainingData(inArray, outArray)

    End Sub

    '''<summary> This function trains the network using the training data queue the 
    ''' specified number of rounds </summary>
    Public Sub Train(ByVal rounds As Long, Optional ByVal breakOnError As Boolean = True)

        Dim tdc As TrainingData

        For Each tdc In Me.TrainingDataQueue
            Utility.PrintArr("Data:", tdc.Inputs)
        Next

        If _network Is Nothing Then Throw New NotInitializedException("Helper not yet initialized. Initialize the helper by calling the Initialize function first", Nothing)
        If _iftraining Then Throw New NetworkHelperException("Training is already going on", Nothing)

        Dim i As Integer
        _iftraining = True
        For i = 0 To rounds - 1

            Dim tempStates As ArrayList = Me.TrainingDataQueue.Clone()

            Do While (tempStates.Count > 0)
                Try
                    Randomize()

                    Dim itemno As Long = Rnd() * (tempStates.Count - 1)

                    Dim td As TrainingData = tempStates(itemno)


                    _network.TrainNetwork(td)
                    tempStates.Remove(td)
                    Application.DoEvents()
                Catch e As Exception
                    If breakOnError Then
                        _iftraining = False
                        Throw New NetworkHelperException("An error occurred while training", e)
                    End If
                End Try
            Loop

            Dim cancel As Boolean = False
            RaiseEvent TrainingProgress(i + 1, rounds, cancel)
            If cancel = True Then GoTo StopTraining

        Next
StopTraining:
        _iftraining = False

    End Sub

    '''<summary> This function will clear the training data queue  </summary>
    Public Sub ClearTrainingData()
        Me.trainingQueue.Clear()
    End Sub

    '''<summary> Training data queue </summary>
    Public ReadOnly Property TrainingDataQueue() As TrainigDataCollection
        Get
            Return Me.trainingQueue
        End Get
    End Property



End Class
