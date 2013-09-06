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

'''<summary>The interface for defining the strategy of a neuron </summary>
Public Interface INeuronStrategy


    '''<summary>Function to find the delta or error rate of this INeuron </summary>
    Function FindDelta(ByVal output As Single, ByVal errorFactor As Single) As Single

    '''<summary>Função Hiperbolica </summary>
    Function HiperbolicaFunc(ByVal value As Single) As Double

    '''<summary>Activation Function, or ThreshHold function</summary>
    Function Activation(ByVal value As Single) As Single

    '''<summary>Summation Function for finding the net value</summary>
    Function FindNetValue(ByVal inputs As NeuronConnections, ByVal bias As Single) As Single

    '''<summary>Function for calculating new bias</summary>
    Function FindNewBias(ByVal bias As Single, ByVal delta As Single) As Single

    '''<summary>Function for updating weights</summary>
    Sub UpdateWeights(ByRef connections As NeuronConnections, ByVal delta As Single)

End Interface

