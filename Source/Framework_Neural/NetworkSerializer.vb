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

'''<summary> 
''' Exception that may be thrown by NeuronStrategy class 
''' </summary>
Public Class NetworkSerializerException
    Inherits NeuralFrameworkException

    Sub New(ByVal Message As String, ByVal e As Exception)
        MyBase.New(Message, e)
    End Sub


End Class

'''<summary> 
''' The class can serialize and deserialize a neural network 
''' </summary>
Public Class NetworkSerializer

    '''<summary> The method will serialize a network to a given file as xml</summary>
    Public Sub SaveNetwork(ByVal file As String, ByVal network As NeuralFramework.INeuralNetwork)

        Try
            Dim networkModel As New DataModel.Network()

            Dim layer As NeuronLayer
            Dim neuron As INeuron


            Dim layerCount As Long = 0, neuronCount As Long = 0


            '''Fill the data model from the network

            For Each layer In network.Layers
                Dim layerModel As New DataModel.Layer()
                neuronCount = 0

                layerModel.Name = "Layer" & layerCount

                '''Add each neuron'''s definition
                For Each neuron In layer

                    Dim neuronModel As New DataModel.Neuron()

                    neuronModel.Bias = neuron.BiasValue
                    neuronModel.Name = "L" & layerCount & "N" & neuronCount
                    neuronModel.Output = neuron.OutputValue
                    neuronModel.Delta = neuron.DeltaValue

                    Dim con As INeuron
                    '''Add the inputs connected to each neuron
                    For Each con In neuron.Inputs.Keys
                        Dim inputModel As New DataModel.Input()
                        Dim pos As Point = FindNeuronPosition(con, network)
                        inputModel.Weight = neuron.Inputs(con)
                        inputModel.Layer = pos.X
                        inputModel.Neuron = pos.Y
                        neuronModel.Connections.Add(inputModel)
                    Next

                    layerModel.Add(neuronModel)
                    neuronCount = neuronCount + 1

                Next

                layerCount = layerCount + 1
                networkModel.Add(layerModel)

            Next

            ''' Insert code to set properties and fields of the object.
            Dim mySerializer As XmlSerializer = New XmlSerializer(GetType(DataModel.Network))
            ''' To write to a file, create a StreamWriter object.
            Dim myWriter As StreamWriter = New StreamWriter(file)
            mySerializer.Serialize(myWriter, networkModel)

            myWriter.Close()
        Catch ex As Exception
            Throw New NetworkSerializerException("Error while saving the network. " & ex.Message, ex)

        End Try



    End Sub

    Public Function GetERROR(ByVal network As NeuralFramework.INeuralNetwork) As Single
        Try
            Dim networkModel As New DataModel.Network()

            Dim layer As NeuronLayer
            Dim neuron As INeuron


            Dim layerCount As Long = 0, neuronCount As Long = 0

            Dim erro As Single = 0

            '''Fill the data model from the network

            For Each layer In network.Layers
                Dim layerModel As New DataModel.Layer()
                neuronCount = 0
                layerModel.Name = "Layer" & layerCount
                '''Add each neuron'''s definition
                For Each neuron In layer
                    Dim neuronModel As New DataModel.Neuron()
                    neuronModel.Bias = neuron.BiasValue
                    neuronModel.Name = "L" & layerCount & "N" & neuronCount
                    neuronModel.Output = neuron.OutputValue
                    neuronModel.Delta = neuron.DeltaValue
                    erro = neuron.DeltaValue
                Next
            Next
            Return erro
        Catch ex As Exception
            Throw New NetworkSerializerException("Error na busca do erro. " & ex.Message, ex)

        End Try

    End Function
    '''<summary> The method will find a neuron'''s position from the layer</summary>
    Private Function FindNeuronPosition(ByVal neuron As INeuron, ByVal network As INeuralNetwork) As Point
        Dim layer As NeuronLayer
        Dim layerCount As Long = 0
        For Each layer In network.Layers
            Try
                Dim index As Long = layer.IndexOf(neuron)
                If index >= 0 Then Return New Point(layerCount, index)
            Catch
            End Try
            layerCount = layerCount + 1
        Next
        Return New Point(-1, -1)
    End Function

    '''<summary> The method will dserialize a network from a given xml file</summary>
    Public Sub LoadNetwork(ByVal file As String, ByRef network As NeuralFramework.INeuralNetwork)

        Try
            ''' Create an instance of the XmlSerializer specifying type and namespace.
            Dim serializer As New XmlSerializer(GetType(DataModel.Network))

            network.Layers.Clear()


            ''' A FileStream is needed to read the XML document.
            Dim fs As New FileStream(file, FileMode.Open)
            Dim reader As New XmlTextReader(fs)

            ''' Declare an object variable of the type to be deserialized.
            Dim networkModel As DataModel.Network

            ''' Use the Deserialize method to restore the object'''s state.
            networkModel = serializer.Deserialize(reader)

            '''Load this to the network

            reader.Close()


            Dim layerModel As DataModel.Layer
            Dim neuronModel As DataModel.Neuron
            Dim inputModel As DataModel.Input

            Dim strategy As New BackPropNeuronStrategy()

            '''Add each layer
            For Each layerModel In networkModel.LayerCollection
                Dim layer As New NeuronLayer()

                layer = network.Layers.Add(layer)


                '''Add each neuron
                For Each neuronModel In layerModel
                    Dim nr As New Neuron(strategy)
                    nr.BiasValue = neuronModel.Bias
                    nr.DeltaValue = neuronModel.Delta
                    nr.OutputValue = neuronModel.Output
                    nr = layer.Add(nr)

                    For Each inputModel In neuronModel.Connections
                        Dim inpNeuron As INeuron = network.Layers(inputModel.Layer)(inputModel.Neuron)
                        network.ConnectNeurons(inpNeuron, nr, inputModel.Weight)
                    Next

                Next

            Next
        Catch ex As Exception
            Throw New NetworkSerializerException("Error while loading the network. " & ex.Message, ex)

        End Try


    End Sub

End Class
