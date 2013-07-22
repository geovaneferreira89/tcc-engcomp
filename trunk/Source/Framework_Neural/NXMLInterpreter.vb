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

Imports System.Xml.Serialization
Imports System.IO
Imports System.Xml
Imports System.Text

Namespace NeuralXML


    '''<summary> Exception thrown when there is a problem in interpreter </summary>
    Public Class InterpreterException
        Inherits NeuralFrameworkException

        Sub New(ByVal Message As String, ByVal e As Exception)
            MyBase.New(Message, e)
        End Sub

    End Class

    '''<summary>Neural XML Interpreter </summary>
    Public Class NXMLInterpreter

        '''<summary>Interpret a neural xml file</summary>
        Private Function Load(ByVal file As String) As NeuralXML.DataModel.NXML


            Try
                ''' Create an instance of the XmlSerializer specifying type and namespace.
                Dim serializer As New XmlSerializer(GetType(NeuralXML.DataModel.NXML))

                ''' A FileStream is needed to read the XML document.
                Dim fs As New FileStream(file, FileMode.Open)
                Dim reader As New XmlTextReader(fs)

                ''' Declare an object variable of the type to be deserialized.
                Dim nxmlDoc As NeuralXML.DataModel.NXML

                ''' Use the Deserialize method to restore the object'''s state.
                nxmlDoc = serializer.Deserialize(reader)
                reader.Close()

                Return nxmlDoc


            Catch ex As Exception
                Throw New InterpreterException("Unable to load file. " & ex.Message, ex)
            End Try

        End Function

        '''<summary>Save the nxml file</summary>
        Private Sub Save(ByVal file As String, ByVal model As NeuralXML.DataModel.NXML)


            Try
                ''' Create an instance of the XmlSerializer specifying type and namespace.
                Dim serializer As New XmlSerializer(GetType(NeuralXML.DataModel.NXML))

                ''' To write to a file, create a StreamWriter object.
                Dim myWriter As StreamWriter = New StreamWriter(file)
                serializer.Serialize(myWriter, model)

                myWriter.Close()

            Catch ex As Exception
                Throw New InterpreterException("Unable to save file. " & ex.Message, ex)
            End Try

        End Sub

        '''<summary>Start Interpretation of the document</summary>
        Public Sub Interpret(ByVal file As String)

            '''Load the nxml document
            Dim nxmlDoc As NeuralXML.DataModel.NXML = Load(file)

            Dim serializer As NetworkSerializer = New NetworkSerializer()
            Dim patternHelper As PatternProcessingHelper = New PatternProcessingHelper()
            Dim imageHelper As ImageProcessingHelper = New ImageProcessingHelper()




            Dim network As DataModel.Network
            Dim datablock As DataModel.DataBlock
            Dim pdata As DataModel.PatternData
            Dim idata As DataModel.ImageData

            Try

                For Each network In nxmlDoc.NetworkCollection

                    Dim mynn As NeuralNetwork = New NeuralNetwork()
                    Dim helper As NetworkHelper = New NetworkHelper(mynn)


                    '''Loading the network
                    Dim filePath As String
                    serializer.LoadNetwork(network.LoadPath, mynn)


                    '''Iterate each datablock
                    For Each datablock In network.DataBlockCollection

                        '''Load the inputs
                        Dim input As ArrayList
                        Dim output As ArrayList

                        '''Process all pattern data

                        '''Loop to train the network
                        For Each pdata In datablock.PatternDataCollection
                            input = New ArrayList()
                            output = New ArrayList()

                            '''Let us start the training
                            If datablock.Type = DataModel.BlockType.Train Then

                                '''Get the input
                                Select Case pdata.InputType
                                    Case DataModel.DataType.Array
                                        '''Split this string to arraylist
                                        Dim arraystr() As String = Split(pdata.InputValue.Trim(), ",")
                                        Dim onestr As String

                                        For Each onestr In arraystr
                                            input.Add(CType(onestr, Single))
                                        Next
                                    Case DataModel.DataType.Number
                                        input = patternHelper.ArrayListFromNumber(CType(pdata.InputValue.Trim(), Single), mynn.InputLayer.Count)
                                    Case DataModel.DataType.Pattern
                                        input = patternHelper.ArrayListFromPattern(pdata.InputValue.Trim)
                                    Case DataModel.DataType.Char
                                        input = patternHelper.ArrayListFromChar(pdata.InputValue.Trim)
                                End Select
                                '''Get the output
                                Select Case pdata.OutputType
                                    Case DataModel.DataType.Array
                                        '''Split this string to arraylist
                                        Dim arraystr() As String = Split(pdata.OutputValue.Trim(), ",")
                                        Dim onestr As String

                                        For Each onestr In arraystr
                                            output.Add(CType(onestr, Single))
                                        Next
                                    Case DataModel.DataType.Number
                                        output = patternHelper.ArrayListFromNumber(CType(pdata.OutputValue.Trim, Long), mynn.OutputLayer.Count)
                                    Case DataModel.DataType.Pattern
                                        output = patternHelper.ArrayListFromPattern(pdata.OutputValue.Trim)
                                    Case DataModel.DataType.Char
                                        output = patternHelper.ArrayListFromChar(pdata.OutputValue.Trim)
                                End Select

                                PrintArr("Train: Input: ", input)
                                PrintArr("Train: Output: ", output)
                                helper.AddTrainingData(input, output)

                            End If

                        Next pdata


                        '''Loop all image data

                        '''Loop to train the network
                        For Each idata In datablock.ImageDataCollection
                            input = New ArrayList()
                            output = New ArrayList()

                            '''Let us start the training
                            If datablock.Type = DataModel.BlockType.Train Then

                                '''Get the input

                                Dim bmapInput As New Bitmap(idata.InputFile)

                                If Not (bmapInput.Width = idata.InputWidth And bmapInput.Height = idata.InputHeight) Then
                                    bmapInput = imageHelper.ShrinkImage(bmapInput, idata.InputWidth, idata.InputHeight, True)
                                End If

                                input = imageHelper.ArrayListFromImage(bmapInput)

                                '''Get the output
                                If idata.OutputFile <> "" Then
                                    Dim bmapOutput As New Bitmap(idata.OutputFile)

                                    If Not (bmapOutput.Width = idata.OutputWidth And bmapOutput.Height = idata.OutputHeight) Then
                                        bmapOutput = imageHelper.ShrinkImage(bmapOutput, idata.OutputWidth, idata.OutputHeight, True)
                                    End If

                                    output = imageHelper.ArrayListFromImage(bmapOutput)
                                Else

                                    '''Get the output
                                    Select Case idata.OutputType
                                        Case DataModel.DataType.Array
                                            '''Split this string to arraylist
                                            Dim arraystr() As String = Split(idata.OutputValue.Trim(), ",")
                                            Dim onestr As String

                                            For Each onestr In arraystr
                                                output.Add(CType(onestr, Single))
                                            Next
                                        Case DataModel.DataType.Number
                                            output = patternHelper.ArrayListFromNumber(CType(idata.OutputValue.Trim(), Long), mynn.OutputLayer.Count)
                                        Case DataModel.DataType.Pattern
                                            output = patternHelper.ArrayListFromPattern(idata.OutputValue.Trim)
                                        Case DataModel.DataType.Char
                                            output = patternHelper.ArrayListFromChar(idata.OutputValue.Trim)
                                    End Select

                                    PrintArr("Train: Input: ", input)
                                    PrintArr("Train: Output: ", output)

                                End If

                                helper.AddTrainingData(input, output)

                            End If

                        Next idata

                        '''Train the network
                        Console.WriteLine("Training Or Running Network...")
                        AddHandler helper.TrainingProgress, AddressOf Me.TrainingProgress
                        helper.Train(datablock.TrainCount)

                        '''Loop to run the network
                        For Each pdata In datablock.PatternDataCollection
                            input = New ArrayList()
                            output = New ArrayList()

                            If datablock.Type = DataModel.BlockType.Run Then
                                '''Get the input
                                Select Case pdata.InputType
                                    Case DataModel.DataType.Array
                                        '''Split this string to arraylist
                                        Dim arraystr() As String = Split(pdata.InputValue.Trim(), ",")
                                        Dim onestr As String

                                        For Each onestr In arraystr
                                            input.Add(CType(onestr, Single))
                                        Next
                                    Case DataModel.DataType.Number
                                        input = patternHelper.ArrayListFromNumber(CType(pdata.InputValue.Trim(), Single), mynn.InputLayer.Count)
                                    Case DataModel.DataType.Pattern
                                        input = patternHelper.ArrayListFromPattern(pdata.InputValue.Trim)
                                    Case DataModel.DataType.Char
                                        input = patternHelper.ArrayListFromChar(pdata.InputValue.Trim)
                                End Select

                                mynn.RunNetwork(input)
                                PrintArr("Run: Input:", input)

                                '''Show the output
                                output = mynn.GetOutput()

                                PrintArr("Run: Output:", output)

                                Dim outstr As String = ""

                                Select Case pdata.OutputType
                                    Case DataModel.DataType.Array
                                        '''Split this string to arraylist
                                        Dim acount As Long

                                        For acount = 0 To output.Count - 1
                                            outstr = outstr & CType(output(acount), String)
                                            If acount < output.Count - 1 Then outstr = outstr & ","
                                        Next
                                    Case DataModel.DataType.Number
                                        outstr = CType(patternHelper.NumberFromArraylist(output), String)
                                    Case DataModel.DataType.Pattern
                                        outstr = patternHelper.PatternFromArraylist(output)
                                    Case DataModel.DataType.Char
                                        outstr = patternHelper.CharFromArraylist(output)
                                End Select

                                pdata.OutputValue = outstr

                            End If

                        Next pdata

                        '''Loop to run the network
                        For Each idata In datablock.ImageDataCollection
                            input = New ArrayList()
                            output = New ArrayList()

                            If datablock.Type = DataModel.BlockType.Run Then

                                '''Get the input

                                Dim bmapInput As New Bitmap(idata.InputFile)

                                If Not (bmapInput.Width = idata.InputWidth And bmapInput.Height = idata.InputHeight) Then
                                    bmapInput = imageHelper.ShrinkImage(bmapInput, idata.InputWidth, idata.InputHeight, True)
                                End If

                                input = imageHelper.ArrayListFromImage(bmapInput)

                                mynn.RunNetwork(input)


                                '''Show the output
                                output = mynn.GetOutput()

                                PrintArr("Run: Output:", output)

                                Dim outstr As String = ""

                                '''Save the output as an image file if required
                                If idata.OutputFile <> "" Then
                                    Dim bmapOutput As Bitmap = imageHelper.ImageFromArraylist(output, idata.OutputWidth, idata.OutputHeight)
                                    bmapoutput.Save(idata.OutputFile)
                                End If

                                Select Case idata.OutputType
                                    Case DataModel.DataType.Array
                                        '''Split this string to arraylist
                                        Dim acount As Long

                                        For acount = 0 To output.Count - 1
                                            outstr = outstr & CType(output(acount), String)
                                            If acount < output.Count - 1 Then outstr = outstr & ","
                                        Next
                                    Case DataModel.DataType.Number
                                        outstr = CType(patternHelper.NumberFromArraylist(output), String)
                                    Case DataModel.DataType.Pattern
                                        outstr = patternHelper.PatternFromArraylist(output)
                                    Case DataModel.DataType.Char
                                        outstr = patternHelper.CharFromArraylist(output)
                                End Select

                                idata.OutputValue = outstr
                            End If


                        Next idata

                    Next datablock

                    '''Save the network
                    If network.SavePath.Trim = "" Then network.SavePath = network.LoadPath
                    serializer.SaveNetwork(network.SavePath, mynn)

                Next network

            Catch ex As Exception
                Throw New InterpreterException("Unable to interpret. Invalid file path provided for image data? " & ex.Message, ex)
            End Try

            '''Update this nxml file
            Save(file, nxmlDoc)

        End Sub

        Private Sub TrainingProgress(ByVal Current As Long, ByVal Max As Long, ByRef cancel As Boolean)
            Console.Write(".")
        End Sub

    End Class

End Namespace