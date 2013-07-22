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

Public Module Utility

    '''<summary>Function used to generate a random number </summary>
    Public Function Rand() As Single
        Randomize()

        Return Rnd() * 2 - 1
    End Function


    '''<summary>Print an array </summary>
    Public Sub PrintArr(ByVal msg As String, ByVal arr As ArrayList)
        Dim ar As Long
        Dim str As String = ""
        For ar = 0 To arr.Count - 1
            str = str & arr(ar)
        Next
        Debug.WriteLine(msg & " - " & str)

    End Sub



    '''<summary>This function can be used to report the status of a neural network to a listview </summary>
    Public Sub Report(ByVal l As ListView, ByVal n As INeuralNetwork)

        Try
            '''Setup the listview

            l.Items.Clear()
            l.Columns.Clear()

            l.Columns.Add("Neuron", 100, HorizontalAlignment.Left)
            l.Columns.Add("Bias", 60, HorizontalAlignment.Left)
            l.Columns.Add("Input Weights", 120, HorizontalAlignment.Left)
            l.Columns.Add("Delta", 60, HorizontalAlignment.Left)
            l.Columns.Add("Output", 160, HorizontalAlignment.Left)


            l.View = View.Details

            Dim myNeuron As INeuron
            Dim con As INeuron
            Dim Inputs As String

            '''Step 1: Connect input layer neurons to first hidden layer neurons

            Dim Layer As NeuronLayer
            Layer = n.Layers(0)

            Dim i As Long = 0, j As Long = 0

            For Each myNeuron In Layer
                Inputs = ""
                For Each con In myNeuron.Inputs.Neurons
                    Inputs = Inputs & Format(myNeuron.Inputs(con), "0.00") & ", "
                Next

                Dim litem As ListViewItem = l.Items.Add("Input" & i)
                litem.SubItems.Add(Format(myNeuron.BiasValue, "0.00"))
                litem.SubItems.Add(Inputs)
                litem.SubItems.add(Format(myNeuron.DeltaValue, "0.00"))
                litem.SubItems.Add(Format(myNeuron.OutputValue, "0.00"))
                i = i + 1

            Next

            '''Step 2: Connect each hidden layer neuron to the next hidden layer neuron

            i = 0 : j = 0

            Dim layercount As Long = 1

            For layercount = 1 To n.Layers.Count - 2
                Dim nl As NeuronLayer
                nl = n.Layers(layercount)

                For Each myNeuron In nl
                    Inputs = ""
                    For Each con In myNeuron.Inputs.Neurons
                        Inputs = Inputs & Format(myNeuron.Inputs(con), "0.00") & ", "
                    Next



                    Dim litem As ListViewItem = l.Items.Add("Hidden" & j & i)
                    litem.SubItems.Add(Format(myNeuron.BiasValue, "0.00"))
                    litem.SubItems.Add(Inputs)
                    litem.SubItems.add(Format(myNeuron.DeltaValue, "0.00"))
                    litem.SubItems.Add(Format(myNeuron.OutputValue, "0.00"))
                    i = i + 1

                Next
                j = j + 1
            Next

            '''Step 3: Output layer

            i = 0


            For Each myNeuron In n.Layers(n.Layers.Count - 1)
                Inputs = ""
                For Each con In myNeuron.Inputs.Neurons
                    Inputs = Inputs & Format(myNeuron.Inputs(con), "0.00") & ", "
                Next

                Dim litem As ListViewItem = l.Items.Add("Output" & i)
                litem.SubItems.Add(Format(myNeuron.BiasValue, "0.00"))
                litem.SubItems.Add(Inputs)
                litem.SubItems.add(Format(myNeuron.DeltaValue, "0.00"))
                litem.SubItems.Add(Format(myNeuron.OutputValue, "0.00"))
                i = i + 1

            Next

        Catch e As Exception
            Throw New NeuralNetworkException("Unable to complete reporting. Error in Report method", e)
        End Try

    End Sub

End Module

